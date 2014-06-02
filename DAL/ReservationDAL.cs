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
	public class ReservationDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public ReservationDAL(String ConnString) : base(ConnString, mappingSource) { }

		[Function(Name="[dbo].[Reservation.SelectAll]")]
		public ISingleResult<ReservationBO> ReservationDAL_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<ReservationBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Reservation.SelectById]")]
		public ISingleResult<ReservationBO> ReservationDAL_SelectById([Parameter(DbType = "int")] Int32 ReservationId) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ReservationId);
			return ((ISingleResult<ReservationBO>)(result.ReturnValue));
		}
	}
}
