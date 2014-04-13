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
	public class DemandeAnnulationDAL : System.Data.Linq.DataContext {

		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public DemandeAnnulationDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[DemandeAnnulation.SelectById]")]
		public ISingleResult<DemandeAnnulationBO> DemandeAnnulationDAL_SelectById([Parameter(DbType = "int")] Int32 DemandeAnnulationId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), DemandeAnnulationId);
			return ((ISingleResult<DemandeAnnulationBO>)result.ReturnValue);
		}
	}
}
