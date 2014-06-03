using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class EmpruntDAL : System.Data.Linq.DataContext {

		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public EmpruntDAL(String ConnString) : base(ConnString, mappingSource) { }

		[Function(Name="[dbo].[Emprunt.SelectAll]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Emprunt.SelectById]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectById([Parameter(DbType = "int")] Int32 EmpruntId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), EmpruntId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.SelectForUserByLivreId]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_SelectForUserByLivreId([Parameter(DbType = "int")] Int32 ClientId, [Parameter(DbType = "int")] Int32 LivreId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ClientId, LivreId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.InsertEmpruntFromReservation]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_InsertEmpruntFromReservation([Parameter(DbType = "int")]Int32 pReservationId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pReservationId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
		
		[Function(Name="[dbo].[Emprunt.InsertEmprunt]")]
		public ISingleResult<EmpruntBO> EmpruntDAL_InsertEmprunt([Parameter(DbType = "int")]Int32 pBibliothequeId, [Parameter(DbType = "int")]Int32 pPersonneId, [Parameter(DbType = "int")]Int32 pLivreId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pBibliothequeId, pPersonneId, pLivreId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}
	}
}
