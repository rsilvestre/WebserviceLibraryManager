using System;
using System.Reflection;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WebsBO;

namespace WebsDAL {
	public class DemandeAnnulationDAL : DataContext {

		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public DemandeAnnulationDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[DemandeAnnulation.SelectById]")]
		public ISingleResult<DemandeAnnulationBO> DemandeAnnulationDAL_SelectById([Parameter(DbType = "int")] Int32 DemandeAnnulationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)MethodBase.GetCurrentMethod()), DemandeAnnulationId);
			return ((ISingleResult<DemandeAnnulationBO>)result.ReturnValue);
		}
	}
}
