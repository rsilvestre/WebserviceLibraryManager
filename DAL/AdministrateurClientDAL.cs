using System;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class AdministrateurClientDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public AdministrateurClientDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[AdministrateurClient.SelectByAdminId]")]
		public ISingleResult<AdministrateurClientBO> AdministrateurClientDAL_SelectByAdminId([Parameter(DbType = "int")] Int32 AdministrateurId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), AdministrateurId);
			return ((ISingleResult<AdministrateurClientBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[AdministrateurClient.SelectByClientId]")]
		public ISingleResult<AdministrateurClientBO> AdministrateurClientDAL_SelectByClientId([Parameter(DbType="int")] Int32 ClientId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), ClientId);
			return ((ISingleResult<AdministrateurClientBO>)result.ReturnValue);
		}
	}
}
