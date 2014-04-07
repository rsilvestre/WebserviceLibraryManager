using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebsBO;

namespace WebsDAL {
	public class RefLivreDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public RefLivreDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[RefLivre.SelectAll]")]
		public ISingleResult<RefLivreBO> RefLivreBO_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<RefLivreBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[RefLivre.InsertLivre]")]
		public ISingleResult<RefLivreBO> RefLivreBO_InsertLivre(
			[Parameter(DbType = "varchar(13)")]		String		ISBN,
			[Parameter(DbType = "varchar(50)")]		String		Titre,
			[Parameter(DbType = "nvarchar(MAX)")]	String		Description,
			[Parameter(DbType = "varchar(50)")]		String		Auteur,
			[Parameter(DbType = "varchar(50)")]		String		Langue,
			[Parameter(DbType = "varchar(50)")]		String		Editeur,
			[Parameter(DbType = "date")]			DateTime	Published,
			[Parameter(DbType = "varchar(250)")]	String		ImageUrl
			) {
				IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ISBN, Titre, Description, Auteur, Langue, Editeur, Published, ImageUrl);
				return ((ISingleResult<RefLivreBO>)result.ReturnValue);
		}
	}
}
