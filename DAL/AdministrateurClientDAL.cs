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
	public class AdministrateurClientDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public AdministrateurClientDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[AdministrateurClient.SelectByAdminId]")]
		public ISingleResult<AdministrateurClientBO> AdministrateurClientDAL_SelectByAdminId([Parameter(DbType = "int")] Int32 AdministrateurId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), AdministrateurId);
			return ((ISingleResult<AdministrateurClientBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[AdministrateurClient.SelectByClientId]")]
		public ISingleResult<AdministrateurClientBO> AdministrateurClientDAL_SelectByClientId([Parameter(DbType="int")] Int32 ClientId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), ClientId);
			return ((ISingleResult<AdministrateurClientBO>)result.ReturnValue);
		}
	}
}
