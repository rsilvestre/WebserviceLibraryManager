using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class PersonneDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public PersonneDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[Personne.SelectAll]")]
		public ISingleResult<PersonneBO> PersonneBO_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Personne.SelectById]")]
		public ISingleResult<PersonneBO> PersonneBO_SelectById([Parameter(DbType="int")] Int32 pId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pId);
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Personne.SelectByName]")]
		public ISingleResult<PersonneBO> PersonneBO_SelectByName([Parameter(DbType="varchar(50)")] String pName) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pName);
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Personne.SelectByInfo]")]
		public ISingleResult<PersonneBO> PersonneBO_SelectByInfo([Parameter(DbType="varchar(50)")] String pInfo) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pInfo);
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}

		[Function(Name = "[dbo].[Personne.SelectByLivreEmpruntId]")]
		public ISingleResult<PersonneBO> PersonneBO_SelectByLivreEmpruntId([Parameter(DbType="int")] Int32 pEmpruntId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pEmpruntId);
			return ((ISingleResult<PersonneBO>)(result.ReturnValue));
		}
	}
}
