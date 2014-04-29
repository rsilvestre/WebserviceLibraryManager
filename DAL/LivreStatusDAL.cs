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
	public class LivreStatusDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public LivreStatusDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[LivreStatus.SelectAll]")]
		public ISingleResult<LivreStatusBO> LivreStatusDAL_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
			return ((ISingleResult<LivreStatusBO>)result.ReturnValue);
		}
	}
}
