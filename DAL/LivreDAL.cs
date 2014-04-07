using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class LivreDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public LivreDAL(String connectString) : base(connectString, mappingSource) { }

		[Function(Name="[dbo].[Livre.SelectAll]")]
		public ISingleResult<LivreBO> LivreBO_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
			return ((ISingleResult<LivreBO>)result.ReturnValue);
		}
	}
}
