using System;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class DemandeAnnulationDAL : DataContext {

		private static readonly MappingSource MappingSource = new AttributeMappingSource();

		public DemandeAnnulationDAL(String connString) : base(connString, MappingSource) { }

		[Function(Name="[dbo].[DemandeAnnulation.SelectById]")]
		public ISingleResult<DemandeAnnulationBO> DemandeAnnulationDAL_SelectById([Parameter(DbType = "int")] Int32 DemandeAnnulationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), DemandeAnnulationId);
			return ((ISingleResult<DemandeAnnulationBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[DemandeAnnulation.InsertDemandeAnnulationByAdmininistrateur]")]
		public ISingleResult<DemandeAnnulationBO> DemandeAnnulationDAL_InsertDemandeAnnulationByAdmininistrateur([Parameter(DbType = "int")] Int32 pAdministrateurId, [Parameter(DbType = "int")] Int32 pDemandeReservationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), pAdministrateurId, pDemandeReservationId);
			return ((ISingleResult<DemandeAnnulationBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[DemandeAnnulation.InsertDemandeAnnulationByClient]")]
		public ISingleResult<DemandeAnnulationBO> DemandeAnnulationDAL_InsertDemandeAnnulationByClient([Parameter(DbType = "int")] Int32 pClientId, [Parameter(DbType = "int")] Int32 pDemandeReservationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), pClientId, pDemandeReservationId);
			return ((ISingleResult<DemandeAnnulationBO>)result.ReturnValue);
		}
	}
}
