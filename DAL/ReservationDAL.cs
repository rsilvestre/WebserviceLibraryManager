using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class ReservationDAL : DataContext {
		private static readonly MappingSource MappingSource = new AttributeMappingSource();

		public ReservationDAL(String connString) : base(connString, MappingSource) { }

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

		[Function(Name="[dbo].[Reservation.SelectEnCoursValidByClientId]")]
		public ISingleResult<ReservationBO> ReservationDAL_SelectEnCoursValidByClientId([Parameter(DbType = "int")] Int32 pClientId) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pClientId);
			return ((ISingleResult<ReservationBO>)(result.ReturnValue));
		}

		[Function(Name="[dbo].[Reservation.SelectEnCoursValidByInfo]")]
		public ISingleResult<ReservationBO> ReservationDAL_SelectEnCoursValidByInfo([Parameter(DbType = "varchar(50)")] String pInfo) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), pInfo);
			return ((ISingleResult<ReservationBO>)(result.ReturnValue));
		}
	}
}
