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
			return demandeAnnulationIFac.InsertDemandeAnnulationByAdmininistrateur(CGlobalCache.SessionManager.Token, pAdministrateurBo.AdministrateurId, pDemandeReservationBo.DemandeReservationId);
		}

		public EmpruntBO SaveAnnuleReservation(AdministrateurBO pAdministrateurBo, ReservationBO pReservationBo) {
			var empruntIFac = new EmpruntIFACClient();
			//throw new NotImplementedException();
			return empruntIFac.InsertAnnul(CGlobalCache.SessionManager.Token, pAdministrateurBo.AdministrateurId, pReservationBo.ReservationId);
		}

		public ItemBO SelectItemByEmpruntId(EmpruntBO pEmprunt){
			var itemIFacClient = new ItemIFACClient();
			return itemIFacClient.SelectByEmpruntId(CGlobalCache.SessionManager.Token, pEmprunt.EmpruntId);
		}

		#region private method

		private void LoadDecoration() {
			var personne = CGlobalCache.SessionManager.Personne;
			lblName.Text = personne.ToString();
			cmbBibliotheque.SelectedItem = CGlobalCache.ActualBibliotheque;
		}

		private void InitComponent() {
			cmbBibliotheque.Items.AddRange(CGlobalCache.SessionManager.Personne.Administrateur.LstBibliotheque.ToArray());
			CGlobalCache.ActualBibliothequeChangeEventHandler += ActualBibliothequeChange;
			CGlobalCache.LstLivreSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			CGlobalCache.LstDemandeReservationSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			CGlobalCache.LstReservationSelectAll.CollectionChanged += LstSelectAll_CollectionChanged;
			CGlobalCache.LstEmpruntSelectAll.CollectionChanged += Lst_CollectionChanged;
			CGlobalCache.LstItemSelectByAministrateurId.CollectionChanged += Lst_CollectionChanged;
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
			result += "Emprunt:\n" + StatEmprunt(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Réservation:\n" + StatReservation(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Demande de Réservation:\n" + StatDemandeReservation(lstBibliotheque, objActualBibliotheque) + "\n\n";
			result += "Chiffre d'affaire:\n" + StatItem(objActualBibliotheque) + "\n\n";
			result += "Référence:\n" + StatRefLivre(lstBibliotheque, objActualBibliotheque) + "\n\n";

			txtStat.Text = result;
		}

		private static string StatItem(BibliothequeBO objActualBibliotheque) {
			var lstItem = CGlobalCache.LstItemSelectByAministrateurId;
			String refItemManaged = "", refItemBibliotheque = "";

			var lstItemTotal = lstItem.GroupBy(xx => xx.AdministrateurId).Select(yy => new {yy.Key, Count = yy.Sum(d => d.Montant)}).ToList();
			var firstOrDefault = lstItemTotal.FirstOrDefault(xx => true);
			refItemManaged += string.Format("dans vos bibliothèques: {0:C}", ((null == firstOrDefault) ? 0 : firstOrDefault.Count));


			if (objActualBibliotheque != null) {
				var lstItemByBibliotheque = lstItem.GroupBy(xx => xx.Livre.BibliothequeId).Select(yy => new{yy.Key, Count = yy.Sum(d => d.Montant)});
				var result = lstItemByBibliotheque.FirstOrDefault(xx => xx.Key == objActualBibliotheque.BibliothequeId);
				refItemBibliotheque += String.Format("dans la bibliothèque {0}: {1:C}",  objActualBibliotheque.BibliothequeName, ((null == result)? 0 : result.Count));
			} else {
				refItemBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}
			
			return refItemManaged + "\n" + refItemBibliotheque + "\n";
		}

		private static string StatRefLivre(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Référence de livre
			var lstLivre = CGlobalCache.LstLivreSelectAll;
			String refLivreAll = "", refLivreManaged = "", refLivreBibliotheque = "";
			var reflivreUniq = lstLivre.GroupBy(xx => xx.RefLivreId).Select(grp => grp.First()).ToList();
			refLivreAll += "Toutes les références: " + reflivreUniq.Count().ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = reflivreUniq.GroupBy(yy => yy.BibliothequeId).Select(grp => new { bibliothequeId = grp.Key, Count = grp.Count() }).ToList();
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, biblio2.Count });

			refLivreManaged += string.Format("dans vos bibliothèques: {0}", query.Sum(result => result.Count));
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				refLivreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.Count : 0).ToString(CultureInfo.InvariantCulture) ;
			} else {
				refLivreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return refLivreAll + "\n" + refLivreManaged + "\n" + refLivreBibliotheque + "\n";
		}

		private static string StatEmprunt(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Réservation
			var lstEmprunt = CGlobalCache.LstEmpruntSelectAll;
			
			var maxActionId = lstEmprunt.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId)});

			var clientEmpruntEnCours = maxActionId.Select(dataInMaxActionResult => CGlobalCache.LstEmpruntSelectAll.ToList().Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)).Where(result => result != null && result.State == "emp").ToList();
			
			String empruntAll = "", empruntManaged = "", empruntBibliotheque = "";

			empruntAll += "Tous les emprunts: " + clientEmpruntEnCours.Count.ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = clientEmpruntEnCours.GroupBy(xx => xx.Livre.BibliothequeId).Select(group => new { bibliothequeId = group.Key, Count = group.Count() }).ToList();
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, biblio2.Count });
			
			empruntManaged += string.Format("dans vos bibliothèques: {0}", query.Sum(result => result.Count));
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				empruntBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.Count : 0).ToString(CultureInfo.InvariantCulture) ;
			} else {
				empruntBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return empruntAll + "\n" + empruntManaged + "\n" + empruntBibliotheque + "\n";
		}

		private static string StatReservation(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Réservation
			String reservationAll = "", reservationManagedValid = "", reservationManagedUnValid = "", reservationBibliothequeValid = "", reservationBibliothequeUnValid = "";
			var lstEmprunt = CGlobalCache.LstEmpruntSelectAll;
			var bibliothequeBos = lstBibliotheque as IList<BibliothequeBO> ?? lstBibliotheque.ToList();
			
			var maxActionId = lstEmprunt.GroupBy(xx => xx.LivreId).Select(dd => new{LivreId = dd.Key, ActionId = dd.Max(qq => qq.ActionId)});
			var clientEmpruntEnCours = maxActionId.Select(dataInMaxActionResult => CGlobalCache.LstEmpruntSelectAll.ToList().Find(xx => xx.ActionId == dataInMaxActionResult.ActionId && xx.LivreId == dataInMaxActionResult.LivreId)).Where(result => result != null && result.State == "res").ToList();
			
			reservationAll += "Toutes les réservations: " + clientEmpruntEnCours.Count.ToString(CultureInfo.InvariantCulture);
			var grpAllBibliothequeValid = clientEmpruntEnCours.FindAll(xx => (DateTime.Now - xx.CreatedAt).Days <= 15).GroupBy(xx => xx.Livre.BibliothequeId).Select(group => new { bibliothequeId = group.Key, Count = group.Count() }).ToList();
			
			var queryValid = bibliothequeBos.Join(grpAllBibliothequeValid, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, biblio2.Count });
			
			var grpAllBibliothequeUnValid = clientEmpruntEnCours.FindAll(xx => (DateTime.Now - xx.CreatedAt).Days > 15).GroupBy(xx => xx.Livre.BibliothequeId).Select(group => new { bibliothequeId = group.Key, Count = group.Count() }).ToList();
			var queryUnValid = bibliothequeBos.Join(grpAllBibliothequeUnValid, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, biblio2.Count });

			reservationManagedValid += string.Format("dans vos bibliothèques: {0}", queryValid.Sum(result => result.Count));
			
			reservationManagedUnValid += string.Format("dans vos bibliothèques: {0}", queryUnValid.Sum(result => result.Count));
			
			if (objActualBibliotheque != null) {
				var resultValid = grpAllBibliothequeValid.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				reservationBibliothequeValid += String.Format("dans la bibliothèque {0}: {1}", objActualBibliotheque.BibliothequeName, ((resultValid != null)?resultValid.Count : 0).ToString(CultureInfo.InvariantCulture));
				
				var resultUnValid = grpAllBibliothequeUnValid.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				reservationBibliothequeUnValid += String.Format("dans la bibliothèque {0}: {1}", objActualBibliotheque.BibliothequeName, ((resultUnValid != null)?resultUnValid.Count : 0).ToString(CultureInfo.InvariantCulture));
			} else {
				reservationBibliothequeValid += "Vous n'avez pas choisi de bibliothèque à gérer";
				reservationBibliothequeUnValid += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return String.Format("{0}\n\nValide:\n{1}\n{2}\n\nHors délais:\n{3}\n{4}\n",reservationAll, reservationManagedValid, reservationBibliothequeValid, reservationManagedUnValid, reservationBibliothequeUnValid);
		}

		private static string StatDemandeReservation(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) {
			// Demande de réservation
			var lstReservation = CGlobalCache.LstDemandeReservationSelectAll;
			String demandeReservationAll = "", demandeReservationManaged = "", demandeReservationBibliotheque = "";
			demandeReservationAll += "Toutes les demandes de réservation: " + lstReservation.Count(xx => xx.Valide == 1).ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = lstReservation.Where(condition => condition.Valide == 1).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, Count = group.Count() }).ToList();
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, biblio2.Count });

			demandeReservationManaged += string.Format("dans vos bibliothèques: {0}", query.Sum(result => result.Count));
			if (objActualBibliotheque != null) {
				//var lstOldReservation = CGlobalCache.LstOldDemandeReservationByClient;
				//var grpAllOldBibliotheque = lstOldReservation.Where(condition => condition.Valide == 1).GroupBy(xx => xx.Client.BibliothequeId).Select(group => new { bibliothequeId = group.Key, Count = group.Count() });

				var newReservation = grpAllBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				//var oldReservation = grpAllOldBibliotheque.FirstOrDefault(xx => xx.bibliothequeId == objActualBibliotheque.BibliothequeId);

				demandeReservationBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((newReservation != null)?newReservation.Count : 0).ToString(CultureInfo.InvariantCulture);
				//demandeReservationBibliothequeDepasse += "dépassée dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((oldReservation != null)?oldReservation.Count : 0).ToString(CultureInfo.InvariantCulture);
			} else {
				demandeReservationBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return String.Format("{0}\n{1}\n{2}\n", demandeReservationAll,  demandeReservationManaged, demandeReservationBibliotheque);
		}

		private static String StatLivre(IEnumerable<BibliothequeBO> lstBibliotheque, BibliothequeBO objActualBibliotheque) { 
			// Livre
			var lstLivre = CGlobalCache.LstLivreSelectAll;
			String livreAll = "", livreManaged = "", livreBibliotheque = "";
			livreAll += "Tous les livres disponibles: " + lstLivre.Count.ToString(CultureInfo.InvariantCulture);
			var grpAllBibliotheque = lstLivre.GroupBy(xx => xx.BibliothequeId).Select(group => new { bibliothequeId = group.Key, Count = group.Count() }).ToList();
			var query = lstBibliotheque.Join(grpAllBibliotheque, myBiblio => myBiblio.BibliothequeId, allBiblio => allBiblio.bibliothequeId, (biblio1, biblio2) => new { biblioId = biblio1.BibliothequeId, biblio2.Count });

			livreManaged += string.Format("dans vos bibliothèques: {0}", query.Sum(result => result.Count));
			if (objActualBibliotheque != null) {
				var result = grpAllBibliotheque.FirstOrDefault(xx =>xx.bibliothequeId == objActualBibliotheque.BibliothequeId);
				livreBibliotheque += "dans la bibliothèque " + objActualBibliotheque.BibliothequeName + ": " + ((result != null)?result.Count : 0).ToString(CultureInfo.InvariantCulture) ;
			} else {
				livreBibliotheque += "Vous n'avez pas choisi de bibliothèque à gérer";
			}

			return String.Format("{0}\n{1}\n{2}\n", livreAll, livreManaged, livreBibliotheque);
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
				if (_empruntManagement != null){
					Controls.Remove(_empruntManagement);
					Controls.Remove(_retourManagement);
				}
				if (_empruntManagement != null) {
					_empruntManagement.Dispose();
					_empruntManagement = null;
				}
				if (_retourManagement != null) {
					_retourManagement.Dispose();
					_retourManagement = null;
				}
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
				if (_reservationManagement != null){
					Controls.Remove(_reservationManagement);
					Controls.Remove(_retourManagement);
				}
				if (_reservationManagement != null) {
					_reservationManagement.Dispose();
					_reservationManagement = null;
				}
				if (_retourManagement != null) {
					_retourManagement.Dispose();
					_retourManagement = null;
				}
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
				if (_reservationManagement != null){
					Controls.Remove(_reservationManagement);
					Controls.Remove(_empruntManagement);
				}
				if (_reservationManagement != null) {
					_reservationManagement.Dispose();
					_reservationManagement = null;
				}
				if (_empruntManagement != null) {
					_empruntManagement.Dispose();
					_empruntManagement = null;
				}
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


			if (_reservationManagement != null || _retourManagement != null) {
				if (_reservationManagement != null){
					Controls.Remove(_reservationManagement);
					Controls.Remove(_retourManagement);
				}
				if (_reservationManagement != null) {
					_reservationManagement.Dispose();
					_reservationManagement = null;
				}
				if (_retourManagement != null) {
					_retourManagement.Dispose();
					_retourManagement = null;
				}
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

		void Lst_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
			LstSelectAll_CollectionChanged(sender, e);
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
			var frmCreateLivre = new CreateLivre(_frmMdi) {MdiParent = _frmMdi};
			frmCreateLivre.Show();
		}

		#endregion Callback
	}
}
