using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class LocationDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public LocationDAL(String ConnString) : base(ConnString, mappingSource) { }

		[Function(Name="[dbo].[Location.SelectAll]")]
		public ISingleResult<LocationBO> LocationBO_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<LocationBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Location.SelectLocationById]")]
		public ISingleResult<LocationBO> LocationBOSelectLocationById([Parameter(DbType = "int")] int pId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pId);
			return ((ISingleResult<LocationBO>)(result.ReturnValue));
		}

	}
}
