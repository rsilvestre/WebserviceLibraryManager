using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class BibliothequeDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public BibliothequeDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[Bibliotheque.SelectAll]")]
		public ISingleResult<BibliothequeBO> BibliothequeDAL_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()));
			return ((ISingleResult<BibliothequeBO>)result.ReturnValue);
		}
		
		[Function(Name="[dbo].[Bibliotheque.SelectByAdministrateurId]")]
		public ISingleResult<BibliothequeBO> BibliothequeDAL_SelectByAdministrateurId([Parameter(DbType="int")]Int32 AdministrateurId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), AdministrateurId);
			return ((ISingleResult<BibliothequeBO>)result.ReturnValue);
		}
		
		[Function(Name="[dbo].[Bibliotheque.SelectById]")]
		public ISingleResult<BibliothequeBO> BibliothequeDAL_SelectById([Parameter(DbType="int")]Int32 BibliothequeId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), BibliothequeId);
			return ((ISingleResult<BibliothequeBO>)result.ReturnValue);
		}
	}
}
