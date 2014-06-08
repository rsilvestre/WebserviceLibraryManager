using System;

namespace WindowsFormsApplication1.DashboardAdmin{

	public class DemandeReservationCombo {
		private readonly String _title;
		private readonly String _lstDemandeReservation;
		private readonly Action _actionDemandeReservation;

		public DemandeReservationCombo(string pTitle, String pLstDemandeReservation) {
			_title = pTitle;
			_lstDemandeReservation = pLstDemandeReservation;
		}

		public DemandeReservationCombo(string pTitle, Action pLstDemandeReservation){
			_title = pTitle;
			_actionDemandeReservation = pLstDemandeReservation;
		}

		public string Title {
			get {
				return _title;
			}
		}

		public Object LstDemandeReservation {
			get{
				return (object)_lstDemandeReservation ?? _actionDemandeReservation;
			}
		}

	}
}