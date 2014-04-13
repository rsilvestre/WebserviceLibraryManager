using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class LivreDAL : System.Data.Linq.DataContext {
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		public LivreDAL(String connectString) : base(connectString, mappingSource) { }

		[Function(Name="[dbo].[Livre.SelectAll]")]
		public ISingleResult<LivreBO> LivreBO_SelectAll() {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()));
			return ((ISingleResult<LivreBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[Livre.InsertLivre]")]
		public ISingleResult<LivreBO> LivreBO_InsertLivre(
			[Parameter(DbType = "int")]				Int32		BibliothequeId,
			[Parameter(DbType = "int")]				Int32		RefLivreId,
			[Parameter(DbType = "varchar(13)")]		String		ISBN,
			[Parameter(DbType = "varchar(50)")]		String		Titre,
			[Parameter(DbType = "nvarchar(MAX)")]	String		Description,
			[Parameter(DbType = "varchar(50)")]		String		Auteur,
			[Parameter(DbType = "varchar(50)")]		String		Langue,
			[Parameter(DbType = "varchar(50)")]		String		Editeur,
			[Parameter(DbType = "date")]			DateTime	Published,
			[Parameter(DbType = "varchar(250)")]	String		ImageUrl
			) {
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)MethodInfo.GetCurrentMethod()),
				BibliothequeId, RefLivreId, ISBN, Titre, Description, Auteur, Langue, Editeur, Published, ImageUrl
				);
			return ((ISingleResult<LivreBO>)result.ReturnValue);
		}
	}
}
