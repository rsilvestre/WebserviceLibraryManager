﻿using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using WebsBO;

namespace WebsDAL {
	public class RefLivreDAL : DataContext {
		private static readonly MappingSource mappingSource = new AttributeMappingSource();

		public RefLivreDAL(String connString) : base(connString, mappingSource) { }

		[Function(Name="[dbo].[RefLivre.SelectAll]")]
		public ISingleResult<RefLivreBO> RefLivreBO_SelectAll() {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())));
			return ((ISingleResult<RefLivreBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[RefLivre.SelectByTitre]")]
		public ISingleResult<RefLivreBO> RefLivreBO_SelectByTitre([Parameter(DbType="varchar(50)")] String Titre) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), Titre);
			return ((ISingleResult<RefLivreBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[RefLivre.SelectByISBN]")]
		public ISingleResult<RefLivreBO> RefLivreBO_SelectByISBN([Parameter(DbType="varchar(13)")] String ISBN) {
			IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), ISBN);
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
				IExecuteResult result = ExecuteMethodCall(this, ((MethodInfo)(MethodBase.GetCurrentMethod())), ISBN, Titre, Description, Auteur, Langue, Editeur, Published, ImageUrl);
				return ((ISingleResult<RefLivreBO>)result.ReturnValue);
		}

		[Function(Name="[dbo].[RefLivre.SelectById]")]
		public ISingleResult<RefLivreBO> RefLivreBO_SelectById([Parameter(DbType="int")]int refLivreId) {
			IExecuteResult result = ExecuteMethodCall(this,(MethodInfo)MethodBase.GetCurrentMethod(), refLivreId);
			return ((ISingleResult<RefLivreBO>)result.ReturnValue);
		}
	}
}
