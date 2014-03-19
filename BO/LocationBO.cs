using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebsBO {
	[DataContract(Namespace = "urn:WebsBO.LocationBO")]
	public class LocationBO {
		private Int32 _LocationId;
		private Int32 _ClientId;
		private DateTime _LocationDate;

		public LocationBO() { }

		public LocationBO(Int32 pLocationId, Int32 pClientId, DateTime pLocationDate) {
			LocationId = pLocationId;
			ClientId = pClientId;
			LocationDate = pLocationDate;
		}

		[DataMember(Name="LocationId")]
		public Int32 LocationId {
			get { return _LocationId; }
			set { _LocationId = value; }
		}

		[DataMember(Name="ClientId")]
		public Int32 ClientId {
			get { return _ClientId; }
			set { _ClientId = value; }
		}

		[DataMember(Name="LocationDate")]
		public DateTime LocationDate {
			get { return _LocationDate; }
			set { _LocationDate = value; }
		}
	}
}
