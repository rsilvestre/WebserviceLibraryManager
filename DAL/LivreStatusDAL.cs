using System;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class LivreStatusDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public LivreStatusDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[LivreStatus.SelectAll]")]
		public ISingleResult<LivreStatusBO> LivreStatusDAL_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()));
			return ((ISingleResult<LivreStatusBO>)result.ReturnValue);
		}
	}
}
