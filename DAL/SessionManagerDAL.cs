using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class SessionManagerDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public SessionManagerDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name = "[dbo].[SessionManager.ByToken]")]
		public ISingleResult<SessionManagerBO> SessionManagerDAL_ById([Parameter(DbType = "varchar(50)")]String Token) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), Token);
			return ((ISingleResult<SessionManagerBO>)result.ReturnValue);
		}

		[Function(Name = "[dbo].[SessionManager.CreateSession]")]
		public ISingleResult<SessionManagerBO> SessionManagerDAL_CreateSession([Parameter(DbType = "varchar(50)")] String Username, [Parameter(DbType = "varchar(50)")] String Password) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), Username, Password);
			return ((ISingleResult<SessionManagerBO>)result.ReturnValue);
		}
	}
}
