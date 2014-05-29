using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WebsEX {
	[DataContract(Namespace = "WebsEX.BadDatabaseAcessFaultException")]
    public class BadDatabaseAcessFaultException {
		[DataMember]
		public String Issue { get; set; }

		[DataMember]
		public String Details { get; set; }
    }
}
