using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Livre;
using Transitions;
using WebsBO;
using WCF.Proxies;

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class DashboardAdminManager : Form {
		private readonly FrmMdi _frmMdi;
		private ReservationManagement _reservationManagement;

		private int _dashboardWidth;
		private int _cmbBibliothequeLocationX;
		private int _lblBibliothequeTitleLocationX;
		private EmpruntManagement _empruntManagement;
		private RetourManagement _retourManagement;

		public DashboardAdminManager() {
			InitializeComponent();
		}

		public DashboardAdminManager(FrmMdi frmMdi) : this() {
			_frmMdi = frmMdi;
		}

		public void SwitchToEmpruntManagement(ReservationBO objReservation) {
			LoadEmpruntManagement(objReservation);
		}

		internal EmpruntBO SaveEmprunt(AdministrateurBO pAdministrateurBo, PersonneBO pPersonneBo, LivreBO livreBo, ReservationBO pReservationBo) {
			var empruntIFac = new EmpruntIFACClient();
			return pReservationBo != null ? empruntIFac.ConvertReservation(CGlobalCache.SessionManager.Token, pAdministrateurBo.AdministrateurId, pReservationBo.ReservationId) : empruntIFac.InsertEmprunt(CGlobalCache.SessionManager.Token,pAdministrateurBo.AdministrateurId , pPersonneBo.PersonneId, livreBo.LivreId);
		}

		internal EmpruntBO SaveRetour(AdministrateurBO pAdministrateurBo, PersonneBO pPersonneBo, LivreBO livreBo) {
			var empruntIFac = new EmpruntIFACClient();
			return empruntIFac.InsertRetour(CGlobalCache.SessionManager.Token, pAdministrateurBo.AdministrateurId, livreBo.LivreId);
		}

		internal DemandeAnnulationBO SaveAnnuleReservation(AdministrateurBO pAdministrateurBo, DemandeReservationBO pDemandeReservationBo){
			var demandeAnnulationIFac = new DemandeAnnulationIFACClient();
			//throw new NotImplementedException();
			return demandeAnnulationIFac.InsertDemandeAnnulation(CGlobalCache.SessionManager.Token, pAdministrateurBo.AdministrateurId, pDemandeReservationBo.DemandeReservationId);
		}

		public EmpruntBO SaveAnnuleReservation(AdministrateurBO pAdministrateurBo, ReservationBO pReservationBo) {
			var empruntIFac = new EmpruntIFACClient();
			//throw new NotImplementedException();
			return empruntIFac.InsertAnnul(CGlobalCache.SessionManager.Token, pAdministrateurBo.AdministrateurId, pReservationBo.ReservationId);
		}

		#region private method

		private void LoadDecoration() {
			var personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = personne.ToString();
			cmbBibliotheque.SelectedItem = CGlobalCache.ActualBibliotheque;
		}

		private void InitComponent() {
			cmbBibliotheque.Items.AddRange(items: CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
			CGlobalCache.ActualBibliothequeChangeEventHandler += ActualBibliothequeChange;
			CGlobalCache.LstLivreSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			CGlobalCache.LstDemandeReservationSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			CGlobalCache.LstReservationSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			btnLivreManagement.Enabled = CGlobalCache.ActualBibliotheque != null;
		}

		private void FixSize() {
			_dashboardWidth = Width;
			_cmbBibliothequeLocationX = cmbBibliotheque.Location.X ;
			_lblBibliothequeTitleLocationX = lblBibliothequeTitle.Location.X;
		}

		private void ShowStat() {
			var objActualBibliotheque = CGlobalCache.ActualBibliotheque;
			var lstBibliotheque = CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque;
			var result = "";
			
			result += "Livre:\n" + StatLivre(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Réservation:\n" + StatReservation(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Demande de Réservation:\n" + StatDemandeReservation(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Référence:\n" + StatRefLivre(lstBibliotheque, objActualBibliotheque) + "\n\n";

			lblStat.Text = result;
		}

		private static string StatRefLivre(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Référence de livre
			var lstLivre = CGlobalCache.LstLivreSelectAll;
			String refLivreAll = "", refLivreManaged = "", refLivreBibliotheque = "";
			var reflivreUniq = lstLivre.GroupBy(xx => xx.RefLivreId).Select(grp => grp.First());
			refLivreAll += "Toutes les références: " + reflivreUniq.Count().ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = reflivreUniq.GroupBy(yy => yy.BibliothequeId).Select(grp => new { bibliothequeId = grp.Key, count = grp.Count() });
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			var count = query.Sum(result => result.count);
			refLivreManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				refLivreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.count : 0).ToString(CultureInfo.InvariantCulture) ;
			} else {
				refLivreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return refLivreAll + "\n" + refLivreManaged + "\n" + refLivreBibliotheque + "\n";
		}

		private static string StatReservation(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Réservation
			var lstEmprunt = CGlobalCache.LstEmpruntSelectAll;
			String reservationAll = "", reservationManaged = "", reservationBibliotheque = "";
			var lstAllReservation = lstEmprunt.GroupBy(xx => xx.LivreId).Select(yy => new{yy.Key, state = yy.Min(q => q.State)}).Where(zz => zz.state == "res").ToList();
			reservationAll += "Toutes les réservations: " + lstAllReservation.Count.ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = lstAllReservation.GroupBy(xx => xx.Key).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			var count = query.Sum(result => result.count);
			reservationManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				reservationBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.count : 0).ToString(CultureInfo.InvariantCulture) ;
			} else {
				reservationBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return reservationAll + "\n" + reservationManaged + "\n" + reservationBibliotheque + "\n";
		}

		private static string StatDemandeReservation(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Demande de réservation
			var lstReservation = CGlobalCache.LstDemandeReservationSelectAll;
			String reservationAll = "", reservationManaged = "", reservationBibliotheque = "", reservationBibliothequeDepasse = "";
			reservationAll += "Toutes les demandes de réservation: " + lstReservation.Count(xx => xx.Valide == 1).ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = lstReservation.Where(condition => condition.Valide == 1).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			var count = query.Sum(result => result.count);
			reservationManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var lstOldReservation = CGlobalCache.LstOldDemandeReservationByClient;
				var grpAllOldBibliotheque = lstOldReservation.Where(condition => condition.Valide == 1).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });

				var newReservation = grpAllBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				var oldReservation = grpAllOldBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);

				reservationBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((newReservation != null)?newReservation.count : 0).ToString(CultureInfo.InvariantCulture);
				reservationBibliothequeDepasse += "dépassée dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((oldReservation != null)?oldReservation.count : 0).ToString(CultureInfo.InvariantCulture);
			} else {
				reservationBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return reservationAll + "\n" + reservationManaged + "\n" + reservationBibliotheque + "\n" + reservationBibliothequeDepasse + "\n";
		}

		private static String StatLivre(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) { 
			// Livre
			var lstLivre = CGlobalCache.LstLivreSelectAll;
			String livreAll = "", livreManaged = "", livreBibliotheque = "";
			livreAll += "Tous les livres disponibles: " + lstLivre.Count.ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = lstLivre.GroupBy(xx => xx.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			var count = query.Sum(result => result.count);
			livreManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				livreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.count : 0).ToString(CultureInfo.InvariantCulture) ;
			} else {
				livreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return livreAll + "\n" + livreManaged + "\n" + livreBibliotheque + "\n";
		}

		private void LoadReservationManagement() {
			CreateReservationManagement();
			/*
			RefLivreIFACClient refLivreIFac = new RefLivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = refLivreIFac.SelectFicheLivreForClientByRefLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pDemandeReservation.RefLivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivreReservation.setFicheDeLivre(_actualFicheLivre);
					if (refLivreIFac != null) {
						refLivreIFac.Close();
					}
				}, null);
			} catch(Exception ex) {
				if (refLivreIFac != null) {
					refLivreIFac.Close();
				}
				MessageBox.Show("Erreur lors de la récupération des informations sur le livre demandé.");
			}
			*/
		}

		private void LoadEmpruntManagement() {
			CreateEmpruntManagement();
			/*
			RefLivreIFACClient refLivreIFac = new RefLivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = refLivreIFac.SelectFicheLivreForClientByRefLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pDemandeReservation.RefLivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivreReservation.setFicheDeLivre(_actualFicheLivre);
					if (refLivreIFac != null) {
						refLivreIFac.Close();
					}
				}, null);
			} catch(Exception ex) {
				if (refLivreIFac != null) {
					refLivreIFac.Close();
				}
				MessageBox.Show("Erreur lors de la récupération des informations sur le livre demandé.");
			}
			*/
		}

		private void LoadEmpruntManagement(ReservationBO objReservation) {
			CreateEmpruntManagement(objReservation);
			/*
			RefLivreIFACClient refLivreIFac = new RefLivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = refLivreIFac.SelectFicheLivreForClientByRefLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pDemandeReservation.RefLivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivreReservation.setFicheDeLivre(_actualFicheLivre);
					if (refLivreIFac != null) {
						refLivreIFac.Close();
					}
				}, null);
			} catch(Exception ex) {
				if (refLivreIFac != null) {
					refLivreIFac.Close();
				}
				MessageBox.Show("Erreur lors de la récupération des informations sur le livre demandé.");
			}
			*/
		}

		private void LoadRetourManagement() {
			CreateRetourManagement();
			/*
			RefLivreIFACClient refLivreIFac = new RefLivreIFACClient();
			
			AsyncGuiFicheDeLivreSelectForClientById asyncExecute = refLivreIFac.SelectFicheLivreForClientByRefLivreId;
			try {
				asyncExecute.BeginInvoke(CGlobalCache.SessionManager.Token, CGlobalCache.SessionManager.Personne.Client.ClientId, pDemandeReservation.RefLivreId, xx => {
					var samplePersDelegate = (AsyncGuiFicheDeLivreSelectForClientById)((AsyncResult)xx).AsyncDelegate;
					_actualFicheLivre = samplePersDelegate.EndInvoke(xx);
					_ficheDeLivreReservation.setFicheDeLivre(_actualFicheLivre);
					if (refLivreIFac != null) {
						refLivreIFac.Close();
					}
				}, null);
			} catch(Exception ex) {
				if (refLivreIFac != null) {
					refLivreIFac.Close();
				}
				MessageBox.Show("Erreur lors de la récupération des informations sur le livre demandé.");
			}
			*/
		}

		private void CreateReservationManagement() {
			if (_reservationManagement != null) {
				return;
			}

			if (_empruntManagement != null || _retourManagement != null) {
				Controls.Remove(_empruntManagement);
				Controls.Remove(_retourManagement);
				_empruntManagement = null;
				_retourManagement = null;
			}

			_reservationManagement = new ReservationManagement(this) {Location = new Point(panel1.Width + 20, 56)};

			var t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _reservationManagement.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _reservationManagement.Width + 10);
			t1.add(cmbBibliotheque, "Left", _cmbBibliothequeLocationX + _reservationManagement.Width + 10);

			Controls.Add(_reservationManagement);

			t1.run();
		}

		private void CreateEmpruntManagement() {
			if (_empruntManagement != null) {
				return;
			}

			if (_reservationManagement != null || _retourManagement != null) {
				Controls.Remove(_reservationManagement);
				Controls.Remove(_retourManagement);
				_reservationManagement = null;
				_retourManagement = null;
			}

			_empruntManagement = new EmpruntManagement(this) {Location = new Point(panel1.Width + 20, 56)};

			var t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _empruntManagement.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _empruntManagement.Width + 10);
			t1.add(cmbBibliotheque, "Left", _cmbBibliothequeLocationX + _empruntManagement.Width + 10);

			Controls.Add(_empruntManagement);

			t1.run();
		}

		private void CreateRetourManagement() {
			if (_retourManagement != null) {
				return;
			}

			if (_reservationManagement != null || _empruntManagement != null) {
				Controls.Remove(_reservationManagement);
				Controls.Remove(_empruntManagement);
				_reservationManagement = null;
				_empruntManagement = null;
			}

			_retourManagement = new RetourManagement(this) {Location = new Point(panel1.Width + 20, 56)};

			var t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _retourManagement.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _retourManagement.Width + 10);
			t1.add(cmbBibliotheque, "Left", _cmbBibliothequeLocationX + _retourManagement.Width + 10);

			Controls.Add(_retourManagement);

			t1.run();
		}

		private void CreateEmpruntManagement(ReservationBO objReservation) {
			if (_empruntManagement != null) {
				return;
			}

			_empruntManagement = new EmpruntManagement(this, objReservation) {Location = new Point(panel1.Width + 20, 56)};


			if (_reservationManagement != null) {
				Controls.Remove(_reservationManagement);
				_reservationManagement = null;
			}

			var t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _empruntManagement.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _empruntManagement.Width + 10);
			t1.add(cmbBibliotheque, "Left", _cmbBibliothequeLocationX + _empruntManagement.Width + 10);

			Controls.Add(_empruntManagement);

			t1.run();
		}



		#endregion private method

		#region Callback

		void LstSelectAll_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			ShowStat();
		}

		private void DashboardAdminManager_Load(object sender, EventArgs e) {
			FixSize();
			InitComponent();
			LoadDecoration();
			ShowStat();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			var objBibliotheque = (BibliothequeBO)((ComboBox)sender).SelectedItem;
			CGlobalCache.ActualBibliotheque = objBibliotheque;
			if (objBibliotheque != null && CGlobalCache.SessionManager.IsAdministrateur) {
			} 
		}

		private void ActualBibliothequeChange(object value, EventArgs e) {
			var objBibliothequeBo = (BibliothequeBO) value;
			cmbBibliotheque.SelectedItem = objBibliothequeBo;
			ShowStat();
			btnLivreManagement.Enabled = true;
		}

		private void DashboardAdminManager_FormClosed(object sender, FormClosedEventArgs e) {
			_frmMdi.ChildFormDecrement();
		}

		private void btReservationManagement_Click(object sender, EventArgs e) {
			LoadReservationManagement();
		}

		private void btnEmpruntManagement_Click(object sender, EventArgs e) {
			LoadEmpruntManagement();
		}

		private void btnRetourManagement_Click(object sender, EventArgs e) {
			LoadRetourManagement();
		}
		private void btnLivreManagement_Click(object sender, EventArgs e) {
			var frmCreateLivre = new CreateLivre(_frmMdi);
			frmCreateLivre.MdiParent = _frmMdi;
			frmCreateLivre.Show();
		}

		#endregion Callback
	}
}
