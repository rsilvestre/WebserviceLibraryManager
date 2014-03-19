using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class PersonneDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public PersonneDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[Personne.SelectAll]")]
		public ISingleResult<PersonneBO> PersonneBO_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}

		public ISingleResult<PersonneBO> PersonneBO_SelectById([Parameter(DbType="int")] Int32 pId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pId);
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}

		public ISingleResult<PersonneBO> PersonneBO_SelectByName([Parameter(DbType="varchar(50)")] String pName) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pName);
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}
	}
}
