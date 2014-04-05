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
		public ISingleResult<EmpruntBO> EmpruntBO_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Emprunt.SelectById]")]
		public ISingleResult<EmpruntBO> EmpruntBO_SelectById([Parameter(DbType = "int")] int pId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pId);
			return ((ISingleResult<EmpruntBO>)(result.ReturnValue));
		}

	}
}
