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
	public class AdministrateurBibliothequeDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public AdministrateurBibliothequeDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[AdministrateutBibliotheque.SelectByAdminId]")]
		public ISingleResult<AdministrateurBibliothequeBO> AministrateurBibliothequeDAL_SelectByAdminId([Parameter(DbType = "int")] Int32 AdministrateurId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), AdministrateurId);
			return ((ISingleResult<AdministrateurBibliothequeBO>)result.ReturnValue);
		}

		[Function(Name = "[dbo].[AdministrateutBibliotheque.SelectByBiblioId]")]
		public ISingleResult<AdministrateurBibliothequeBO> AministrateurBibliothequeDAL_SelectByBiblioId([Parameter(DbType = "int")] Int32 BibliothequeId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), BibliothequeId);
			return ((ISingleResult<AdministrateurBibliothequeBO>)result.ReturnValue);
		}

	}
}
