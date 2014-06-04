using System;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class ClientDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public ClientDAL(String ConnString) : base(ConnString, mappingSource) { }

		[Function(Name = "[dbo].[Client.SelectAll]")]
		public ISingleResult<ClientBO> ClientBO_SelectAll() { 
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((ISingleResult<ClientBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Client.SelectClientById]")]
		public ISingleResult<ClientBO> ClientBO_SelectById([Parameter(DbType="int")] int pId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pId);
			return ((ISingleResult<ClientBO>)(result.ReturnValue));
		}
	}
}
