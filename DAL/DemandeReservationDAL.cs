using System;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class DemandeReservationDAL : DataContext {

		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public DemandeReservationDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[DemandeReservation.SelectById]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectById([Parameter(DbType = "int")] Int32 pDemandeReservationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), pDemandeReservationId);
			return ((ISingleResult<DemandeReservationBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[DemandeReservation.SelectForUserByRefLivreId]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectForUserByRefLivreId([Parameter(DbType = "int")] Int32 ClientId,  [Parameter(DbType = "int")] Int32 RefLivreId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), ClientId, RefLivreId);
			return ((ISingleResult<DemandeReservationBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[DemandeReservation.SelectAll]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()));
			return ((ISingleResult<DemandeReservationBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[DemandeReservation.SelectNewByClientId]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectNewByClientId([Parameter(DbType="int")] Int32 ClientId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), ClientId);
			return ((ISingleResult<DemandeReservationBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[DemandeReservation.SelectOldByClientId]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectOldByClientId([Parameter(DbType="int")] Int32 ClientId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), ClientId);
			return ((ISingleResult<DemandeReservationBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[DemandeReservation.InsertDemandeReservation]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_InsertDemandeReservation([Parameter(DbType="int")] Int32 ClientId, [Parameter(DbType="int")] Int32 RefLivreId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), ClientId, RefLivreId);
			return ((ISingleResult<DemandeReservationBO>)result.ReturnValue);
		}

		
		[Function(Name="[dbo].[DemandeReservation.SelectByEmpruntId]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectByEmpruntId([Parameter(DbType = "int")] Int32 pEmpruntId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), pEmpruntId);
			return ((ISingleResult<DemandeReservationBO>)result.ReturnValue);
		}
	}
}
