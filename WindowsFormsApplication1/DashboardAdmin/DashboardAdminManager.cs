using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;
using WebsBO;
using WCF.Proxies;

namespace WindowsFormsApplication1.DashboardAdmin {
	public partial class DashboardAdminManager : Form {
		private FrmMdi _frmMdi;
		private ReservationManagement _reservationManagement;

		private const int ADD_DASHBOARD_FICHE_DE_LIVRE = 596;
		private const int ADD_DASHBOARD_FICHE_DE_LIVRE_RESERVATION = 544;
		private int _dashboardWidth;
		private int _cmbBibliothequeLocationX;
		private int _lblBibliothequeTitleLocationX;
		private EmpruntManagement _empruntManagement;

		public DashboardAdminManager() {
			InitializeComponent();
		}

		public DashboardAdminManager(FrmMdi frmMdi) : this() {
			this._frmMdi = frmMdi;
		}

		public void switchToEmpruntManagement(DemandeReservationBO objDemandeReservation) {
			this.loadEmpruntManagement(objDemandeReservation);
		}

		internal void saveEmprunt(EmpruntManagement objEmpruntManagement, BibliothequeBO pBibliotheque, PersonneBO personneBO, LivreBO livreBO, DemandeReservationBO demandeReservationBO) {
			EmpruntIFACClient empruntIFac = new EmpruntIFACClient();
			
			throw new NotImplementedException();
		}

		#region private method

		private void loadDecoration() {
			PersonneBO personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = personne.ToString();
			cmbBibliotheque.SelectedItem = CGlobalCache.ActualBibliotheque;
		}

		private void initComponent() {
			cmbBibliotheque.Items.AddRange(CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
			CGlobalCache.actualBibliothequeChangeEventHandler += actualBibliothequeChange;
		}

		private void fixSize() {
			_dashboardWidth = this.Width;
			_cmbBibliothequeLocationX = cmbBibliotheque.Location.X ;
			_lblBibliothequeTitleLocationX = lblBibliothequeTitle.Location.X;
		}

		private void showStat() {
			BibliothequeBO objActualBibliotheque = CGlobalCache.ActualBibliotheque;
			List<BibliothequeBO> lstBibliotheque = CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque;
			String result = "";
			
			result += "Livre:\n" + statLivre(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Réservation:\n" + statReservation(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Référence:\n" + statRefLivre(lstBibliotheque, objActualBibliotheque) + "\n\n";

			lblStat.Text = result;
		}

		private string statRefLivre(List<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Référence de livre
			List<LivreBO> lstLivre = CGlobalCache.LstLivreSelectAll;
			String RefLivreAll = "", RefLivreManaged = "", RefLivreBibliotheque = "";
			var reflivreUniq = lstLivre.GroupBy(xx => xx.RefLivreId).Select(grp => grp.First());
			RefLivreAll += "Toutes les références: " + reflivreUniq.Count().ToString();
			var grpAllBibliotheque = reflivreUniq.GroupBy(yy => yy.BibliothequeId).Select(grp => new { bibliothequeId = grp.Key, count = grp.Count() });
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			int count = 0;
			foreach (var result in query) {
				count += result.count;
			}
			RefLivreManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				RefLivreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.count : 0).ToString() ;
			} else {
				RefLivreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return RefLivreAll + "\n" + RefLivreManaged + "\n" + RefLivreBibliotheque + "\n";
		}

		private string statReservation(List<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Demande de réservation
			List<DemandeReservationBO> lstNewReservation = CGlobalCache.LstNewDemandeReservationByClient;
			String ReservationAll = "", ReservationManaged = "", ReservationBibliotheque = "", ReservationBibliothequeDepasse = "";
			ReservationAll += "Toutes les réservations: " + lstNewReservation.Count.ToString();
			var grpAllNewBibliotheque = lstNewReservation.Where(condition => condition.Valide == 0).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			var query = lstBibliotheque.Join(grpAllNewBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			int count = 0;
			foreach (var result in query) {
				count += result.count;
			}
			ReservationManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				List<DemandeReservationBO> lstOldReservation = CGlobalCache.LstOldDemandeReservationByClient;
				var grpAllOldBibliotheque = lstOldReservation.Where(condition => condition.Valide == 0).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });

				var newReservation = grpAllNewBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				var oldReservation = grpAllOldBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);

				ReservationBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((newReservation != null)?newReservation.count : 0).ToString();
				ReservationBibliothequeDepasse += "dépassée dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((oldReservation != null)?oldReservation.count : 0).ToString();
			} else {
				ReservationBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return ReservationAll + "\n" + ReservationManaged + "\n" + ReservationBibliotheque + "\n" + ReservationBibliothequeDepasse + "\n";
		}

		private String statLivre(List<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) { 
			// Livre
			List<LivreBO> lstLivre = CGlobalCache.LstLivreSelectAll;
			String LivreAll = "", LivreManaged = "", LivreBibliotheque = "";
			LivreAll += "Tous les livres disponibles: " + lstLivre.Count.ToString();
			var grpAllBibliotheque = lstLivre.GroupBy(xx => xx.BibliothequeId).Select(group => new { bibliothequeId = group.Key, count = group.Count() });
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, count = biblio2.count });
			int count = 0;
			foreach (var result in query) {
				count += result.count;
			}
			LivreManaged += "dans vos bibliothèques: " + count;
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				LivreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.count : 0).ToString() ;
			} else {
				LivreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return LivreAll + "\n" + LivreManaged + "\n" + LivreBibliotheque + "\n";
		}

		private void loadReservationManagement() {
			this.createReservationManagement();
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

		private void loadEmpruntManagement() {
			this.createEmpruntManagement();
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

		private void loadEmpruntManagement(DemandeReservationBO objDemandeReservation) {
			this.createEmpruntManagement(objDemandeReservation);
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

		private void createReservationManagement() {
			if (_reservationManagement != null) {
				return;
			}

			_reservationManagement = new ReservationManagement(this);
			_reservationManagement.Location = new Point(panel1.Width + 20, 56);

			
			if (_empruntManagement != null) {
				this.Controls.Remove(_empruntManagement);
				_empruntManagement = null;
			}

			Transition t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _reservationManagement.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _reservationManagement.Width + 10);
			t1.add(cmbBibliotheque, "Left", _cmbBibliothequeLocationX + _reservationManagement.Width + 10);

			this.Controls.Add(_reservationManagement);

			t1.run();
		}

		private void createEmpruntManagement() {
			if (_empruntManagement != null) {
				return;
			}

			_empruntManagement = new EmpruntManagement(this);
			_empruntManagement.Location = new Point(panel1.Width + 20, 56);

			
			if (_reservationManagement != null) {
				this.Controls.Remove(_reservationManagement);
				_reservationManagement = null;
			}

			Transition t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _empruntManagement.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _empruntManagement.Width + 10);
			t1.add(cmbBibliotheque, "Left", _cmbBibliothequeLocationX + _empruntManagement.Width + 10);

			this.Controls.Add(_empruntManagement);

			t1.run();
		}

		private void createEmpruntManagement(DemandeReservationBO objDemandeReservation) {
			if (_empruntManagement != null) {
				return;
			}

			_empruntManagement = new EmpruntManagement(this, objDemandeReservation);
			_empruntManagement.Location = new Point(panel1.Width + 20, 56);

			
			if (_reservationManagement != null) {
				this.Controls.Remove(_reservationManagement);
				_reservationManagement = null;
			}

			Transition t1 = new Transition(new TransitionType_EaseInEaseOut(1000));
			t1.add(this, "Width", _dashboardWidth + _empruntManagement.Width + 10);
			t1.add(lblBibliothequeTitle, "Left", _lblBibliothequeTitleLocationX + _empruntManagement.Width + 10);
			t1.add(cmbBibliotheque, "Left", _cmbBibliothequeLocationX + _empruntManagement.Width + 10);

			this.Controls.Add(_empruntManagement);

			t1.run();
		}



		#endregion private method

		#region Callback

		private void DashboardAdminManager_Load(object sender, EventArgs e) {
			this.fixSize();
			this.initComponent();
			this.loadDecoration();
			this.showStat();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			BibliothequeBO objBibliotheque = (BibliothequeBO)((ComboBox)sender).SelectedItem;
			CGlobalCache.ActualBibliotheque = objBibliotheque;
			if (objBibliotheque != null && CGlobalCache.SessionManager.IsAdministrateur) {
			} 
		}

		private void actualBibliothequeChange(object value, EventArgs e) {
			BibliothequeBO objBibliothequeBO = (BibliothequeBO) value;
			cmbBibliotheque.SelectedItem = objBibliothequeBO;
			this.showStat();
		}

		private void DashboardAdminManager_FormClosed(object sender, FormClosedEventArgs e) {
			this._frmMdi.ChildFormDecrement();
		}

		private void btReservationManagement_Click(object sender, EventArgs e) {
			this.loadReservationManagement();
		}

		private void btnEmpruntManagement_Click(object sender, EventArgs e) {
			this.loadEmpruntManagement();
		}

		#endregion Callback
	}
}
