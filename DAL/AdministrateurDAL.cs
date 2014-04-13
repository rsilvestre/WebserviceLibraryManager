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
	public class AdministrateurDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public AdministrateurDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[Aministrateur.SelectById]")]
		public ISingleResult<AdministrateurBO> AdministrateurDAL_SelectById([Parameter(DbType = "int")] Int32 AdministrateurId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), AdministrateurId);
			return ((ISingleResult<AdministrateurBO>)result.ReturnValue);
		}
	}
}
