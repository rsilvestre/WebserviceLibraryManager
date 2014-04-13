using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class BibliothequeDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public BibliothequeDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[Bibliotheque.SelectAll]")]
		public ISingleResult<BibliothequeBO> BibliothequeDAL_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
			return ((ISingleResult<BibliothequeBO>)result.ReturnValue);
		}
	}
}
