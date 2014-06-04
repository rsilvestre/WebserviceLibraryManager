using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
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

		public DashboardAdminManager() {
			InitializeComponent();
		}

		public DashboardAdminManager(FrmMdi frmMdi) : this() {
			_frmMdi = frmMdi;
		}

		public void SwitchToEmpruntManagement(DemandeReservationBO objDemandeReservation) {
			LoadEmpruntManagement(objDemandeReservation);
		}

		internal void SaveEmprunt(EmpruntManagement objEmpruntManagement, BibliothequeBO pBibliotheque, PersonneBO personneBo, LivreBO livreBo, DemandeReservationBO demandeReservationBo) {
			var empruntIFac = new EmpruntIFACClient();
			
			throw new NotImplementedException();
		}

		#region private method

		private void LoadDecoration() {
			var personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = personne.ToString();
			cmbBibliotheque.SelectedItem = CGlobalCache.ActualBibliotheque;
		}

		private void InitComponent() {
			cmbBibliotheque.Items.AddRange(items: CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
			CGlobalCache.actualBibliothequeChangeEventHandler += ActualBibliothequeChange;
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
			
			result += "Livre:\n" + statLivre(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Réservation:\n" + statReservation(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Référence:\n" + statRefLivre(lstBibliotheque, objActualBibliotheque) + "\n\n";

			lblStat.Text = result;
		}

		private string statRefLivre(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
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
				refLivreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.count : 0).ToString() ;
			} else {
				refLivreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return refLivreAll + "\n" + refLivreManaged + "\n" + refLivreBibliotheque + "\n";
		}

		private string statReservation(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Demande de réservation
			var lstNewReservation = CGlobalCache.LstNewDemandeReservationByClient;
			String reservationAll = "", reservationManaged = "", reservationBibliotheque = "", reservationBibliothequeDepasse = "";
			reservationAll += "Toutes les réservations: " + lstNewReservation.Count.ToString();
			var grpAllNewBibliotheque = lstNewReservation.Where(condition => condition.Valide == 0).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			var query = lstBibliotheque.Join(grpAllNewBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			var count = query.Sum(result => result.count);
			reservationManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var lstOldReservation = CGlobalCache.LstOldDemandeReservationByClient;
				var grpAllOldBibliotheque = lstOldReservation.Where(condition => condition.Valide == 0).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });

				var newReservation = grpAllNewBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				var oldReservation = grpAllOldBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);

				reservationBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((newReservation != null)?newReservation.count : 0).ToString();
				reservationBibliothequeDepasse += "dépassée dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((oldReservation != null)?oldReservation.count : 0).ToString();
			} else {
				reservationBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return reservationAll + "\n" + reservationManaged + "\n" + reservationBibliotheque + "\n" + reservationBibliothequeDepasse + "\n";
		}

		private String statLivre(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) { 
			// Livre
			var lstLivre = CGlobalCache.LstLivreSelectAll;
			String LivreAll = "", livreManaged = "", livreBibliotheque = "";
			LivreAll += "Tous les livres disponibles: " + lstLivre.Count.ToString();
			var grpAllBibliotheque = lstLivre.GroupBy(xx => xx.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			var count = query.Sum(result => result.count);
			livreManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				livreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.count : 0).ToString() ;
			} else {
				livreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return LivreAll + "\n" + livreManaged + "\n" + livreBibliotheque + "\n";
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

		private void LoadEmpruntManagement(DemandeReservationBO objDemandeReservation) {
			CreateEmpruntManagement(objDemandeReservation);
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

			_reservationManagement = new ReservationManagement(this) {Location = new Point(panel1.Width + 20, 56)};


			if (_empruntManagement != null) {
				Controls.Remove(_empruntManagement);
				_empruntManagement = null;
			}

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

			_empruntManagement = new EmpruntManagement(this) {Location = new Point(panel1.Width + 20, 56)};


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

		private void CreateEmpruntManagement(DemandeReservationBO objDemandeReservation) {
			if (_empruntManagement != null) {
				return;
			}

			_empruntManagement = new EmpruntManagement(this, objDemandeReservation) {Location = new Point(panel1.Width + 20, 56)};


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

		#endregion Callback
	}
}
