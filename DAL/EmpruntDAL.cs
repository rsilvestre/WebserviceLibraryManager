using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class EmpruntDAL : DataContext {

		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public EmpruntDAL(String ConnString) : base(ConnString, mappingSource) { }

		[Function(Name="[dbo].[Emprunt.SelectAll]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Emprunt.SelectById]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectById([Parameter(DbType = "int")] Int32 EmpruntId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), EmpruntId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.SelectForUserByLivreId]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectForUserByLivreId([Parameter(DbType = "int")] Int32 ClientId, [Parameter(DbType = "int")] Int32 LivreId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), ClientId, LivreId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.InsertEmpruntFromReservation]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_InsertEmpruntFromReservation([Parameter(DbType = "int")]Int32 pAdministrateurId, [Parameter(DbType = "int")]Int32 pReservationId) {
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
		public ISingleResult<EmpruntBO> EmpruntDAL_InsertAnnul([Parameter(DbType = "int")]Int32 pAdministrateurId, [Parameter(DbType = "int")]Int32 pLivreId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pAdministrateurId, pLivreId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
	}
}
