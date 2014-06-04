using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class AdministrateurDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public AdministrateurDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[Aministrateur.SelectById]")]
		public ISingleResult<AdministrateurBO> AdministrateurDAL_SelectById([Parameter(DbType = "int")] Int32 AdministrateurId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), AdministrateurId);
			return ((ISingleResult<AdministrateurBO>)result.ReturnValue);
		}
	}
}
