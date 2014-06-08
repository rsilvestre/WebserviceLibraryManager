using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class EmpruntDAL : DataContext {

		private static readonly MappingSource MappingSource = new AttributeMappingSource();

		public EmpruntDAL(String connString) : base(connString, MappingSource) { }

		[Function(Name="[dbo].[Emprunt.SelectAll]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Emprunt.SelectById]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectById([Parameter(DbType = "int")] Int32 pEmpruntId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pEmpruntId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Emprunt.SelectByClientId]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectByClientId([Parameter(DbType = "int")] Int32 pClientId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pClientId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.SelectForUserByLivreId]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectForUserByLivreId([Parameter(DbType = "int")] Int32 pClientId, [Parameter(DbType = "int")] Int32 pLivreId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pClientId, pLivreId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.ConvertReservation]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_ConvertReservation([Parameter(DbType = "int")]Int32 pAdministrateurId, [Parameter(DbType = "int")]Int32 pReservationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pAdministrateurId, pReservationId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.InsertEmprunt]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_InsertEmprunt([Parameter(DbType = "int")]Int32 pAdministrateurId, [Parameter(DbType = "int")]Int32 pPersonneId, [Parameter(DbType = "int")]Int32 pLivreId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pAdministrateurId, pPersonneId, pLivreId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[emprunt.InsertRetour]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_InsertRetour([Parameter(DbType = "int")]Int32 pAdministrateurId, [Parameter(DbType = "int")]Int32 pLivreId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pAdministrateurId, pLivreId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[emprunt.InsertAnnul]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_InsertAnnul([Parameter(DbType = "int")]Int32 pAdministrateurId, [Parameter(DbType = "int")]Int32 pReservationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pAdministrateurId, pReservationId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
	}
}
