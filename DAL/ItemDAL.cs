using System;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class ItemDAL : DataContext {
		private static readonly MappingSource MappingSource = new AttributeMappingSource();

		public ItemDAL(String connString) : base(connString, MappingSource) { }

		[Function(Name = "[dbo].[Item.SelectAll]")]
		public ISingleResult<ItemBO> ItemBO_SelectAll() { 
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((ISingleResult<ItemBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Item.SelectByItemId]")]
		public ISingleResult<ItemBO> ItemBO_SelectByItemId([Parameter(DbType="int")] Int32 pItemId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pItemId);
			return ((ISingleResult<ItemBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Item.SelectByEmpruntId]")]
		public ISingleResult<ItemBO> ItemBO_SelectByEmpruntId([Parameter(DbType="int")] Int32 pEmpruntId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pEmpruntId);
			return ((ISingleResult<ItemBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Item.SelectByAdministrateurId]")]
		public ISingleResult<ItemBO> ItemBO_SelectByAdministrateurId([Parameter(DbType="int")] Int32 pAdministrateurId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pAdministrateurId);
			return ((ISingleResult<ItemBO>)(result.ReturnValue));
		}
	}
}
