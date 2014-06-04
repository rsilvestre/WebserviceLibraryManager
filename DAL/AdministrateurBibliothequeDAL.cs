using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class AdministrateurBibliothequeDAL : DataContext {
		private static readonly MappingSource MappingSource = new AttributeMappingSource();

		public AdministrateurBibliothequeDAL(String connString) : base(connString, MappingSource) { }

		[Function(Name="[dbo].[AdministrateutBibliotheque.SelectByAdminId]")]
		public ISingleResult<AdministrateurBibliothequeBO> AministrateurBibliothequeDAL_SelectByAdminId([Parameter(DbType = "int")] Int32 AdministrateurId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), AdministrateurId);
			return ((ISingleResult<AdministrateurBibliothequeBO>)result.ReturnValue);
		}

		[Function(Name = "[dbo].[AdministrateutBibliotheque.SelectByBiblioId]")]
		public ISingleResult<AdministrateurBibliothequeBO> AministrateurBibliothequeDAL_SelectByBiblioId([Parameter(DbType = "int")] Int32 BibliothequeId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), BibliothequeId);
			return ((ISingleResult<AdministrateurBibliothequeBO>)result.ReturnValue);
		}

	}
}
