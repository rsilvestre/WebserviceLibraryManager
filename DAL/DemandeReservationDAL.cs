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
	public class DemandeReservationDAL : System.Data.Linq.DataContext {

		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public DemandeReservationDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[DemandeReservation.SelectById]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectById([Parameter(DbType = "int")] Int32 DemandeReservationId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), DemandeReservationId);
			return ((ISingleResult<DemandeReservationBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[DemandeReservation.SelectByClientId]")]
		public ISingleResult<DemandeReservationBO> DemandeReservationDAL_SelectByClientId([Parameter(DbType="int")] Int32 ClientId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()), ClientId);
			return ((ISingleResult<DemandeReservationBO>)result.ReturnValue);
		}

	}
}
