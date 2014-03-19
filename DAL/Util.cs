using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WebsDAL
{
    public static class Util
    {
		public static string GetConnection() {
			String connection;
			SqlConnectionStringBuilder builder;

			try {
				builder = new SqlConnectionStringBuilder();
				connection = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
				builder = new SqlConnectionStringBuilder(connection);
			} catch (Exception Ex) {
				throw;
			}
			return builder.ConnectionString;
		}
    }
}
