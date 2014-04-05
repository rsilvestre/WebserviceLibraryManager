using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class ClientDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public ClientDAL(String ConnString) : base(ConnString, mappingSource) { }

		[Function(Name = "[dbo].[Client.SelectAll]")]
		public ISingleResult<ClientBO> ClientBO_SelectAll() { 
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<ClientBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Client.SelectClientById]")]
		public ISingleResult<ClientBO> ClientBO_SelectById([Parameter(DbType="int")] int pId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pId);
			return ((ISingleResult<ClientBO>)(result.ReturnValue));
		}
	}
}
