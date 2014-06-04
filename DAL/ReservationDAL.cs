using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class ReservationDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public ReservationDAL(String ConnString) : base(ConnString, mappingSource) { }

		[Function(Name="[dbo].[Reservation.SelectAll]")]
		public ISingleResult<ReservationBO> ReservationDAL_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((ISingleResult<ReservationBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Reservation.SelectById]")]
		public ISingleResult<ReservationBO> ReservationDAL_SelectById([Parameter(DbType = "int")] Int32 ReservationId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), ReservationId);
			return ((ISingleResult<ReservationBO>)(result.ReturnValue));
		}
	}
}
