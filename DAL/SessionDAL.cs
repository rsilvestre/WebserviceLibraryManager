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
	public class SessionDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public SessionDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[Session.ById]")]
		public ISingleResult<SessionBO> SessionDAL_ById([Parameter(DbType = "varchar(100)")]String Token) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), Token);
			return ((ISingleResult<SessionBO>)result.ReturnValue);
		}

		[Function(Name="[dbo][Session.CreateSesion]")]
		public ISingleResult<SessionBO> SessionDAL_CreateSession([Parameter(DbType = "varchar(50)")] String Username, [Parameter(DbType = "varchar(50)")] String Password ) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), Username, Password);
			return ((ISingleResult<SessionBO>)result.ReturnValue);
		}
	}
}
