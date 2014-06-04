using System;
using System.Data.SqlClient;
using System.Configuration;

namespace WebsDAL
{
    public static class Util
    {
		public static string GetConnection() {
			SqlConnectionStringBuilder builder;

			String connection = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
			builder = new SqlConnectionStringBuilder(connection);
			return builder.ConnectionString;
		}
    }
}
