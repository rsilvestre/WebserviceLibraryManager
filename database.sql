USE [master]
GO
/****** Object:  Database [EphecSample]    Script Date: 15/07/2014 13:28:49 ******/
CREATE DATABASE [EphecSample]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EphecSample', FILENAME = N'C:\data\MSSQL11.MSSQLSERVER\MSSQL\DATA\EphecSample.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EphecSample_log', FILENAME = N'C:\data\MSSQL11.MSSQLSERVER\MSSQL\DATA\EphecSample_log.ldf' , SIZE = 15040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [EphecSample] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EphecSample].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EphecSample] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EphecSample] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EphecSample] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EphecSample] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EphecSample] SET ARITHABORT OFF 
GO
ALTER DATABASE [EphecSample] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EphecSample] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [EphecSample] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EphecSample] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EphecSample] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EphecSample] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EphecSample] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EphecSample] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EphecSample] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EphecSample] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EphecSample] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EphecSample] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EphecSample] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EphecSample] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EphecSample] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EphecSample] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EphecSample] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EphecSample] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EphecSample] SET RECOVERY FULL 
GO
ALTER DATABASE [EphecSample] SET  MULTI_USER 
GO
ALTER DATABASE [EphecSample] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EphecSample] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EphecSample] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EphecSample] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EphecSample', N'ON'
GO
USE [EphecSample]
GO
/****** Object:  UserDefinedTableType [dbo].[refLivreType]    Script Date: 15/07/2014 13:28:49 ******/
CREATE TYPE [dbo].[refLivreType] AS TABLE(
	[RefLivreId] [int] NOT NULL,
	[ISBN] [varchar](13) NOT NULL,
	[Titre] [varchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[Auteur] [varchar](50) NOT NULL,
	[Langue] [varchar](50) NOT NULL,
	[Editeur] [varchar](50) NOT NULL,
	[Published] [date] NOT NULL,
	[imageUrl] [varchar](250) NULL,
	PRIMARY KEY CLUSTERED 
(
	[RefLivreId] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  StoredProcedure [dbo].[Aministrateur.SelectById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Aministrateur.SelectById] @AdministrateurId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Administrateur WHERE AdministrateurId = @AdministrateurId;
END

GO
/****** Object:  StoredProcedure [dbo].[Bibliotheque.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bibliotheque.SelectAll] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Bibliotheque;
END

GO
/****** Object:  StoredProcedure [dbo].[Bibliotheque.SelectByAdministrateurId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bibliotheque.SelectByAdministrateurId] @AdministrateurId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.BibliothequeId, b.BibliothequeName FROM dbo.Bibliotheque  AS b
	LEFT JOIN dbo.AdministrateurBibliotheque AS ab ON b.BibliothequeId = ab.BibliethequeId 
	WHERE ab.AdministrateurId = @AdministrateurId
END

GO
/****** Object:  StoredProcedure [dbo].[Bibliotheque.SelectById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Bibliotheque.SelectById] @BibliothequeId AS int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Bibliotheque WHERE BibliothequeId = @BibliothequeId;
END

GO
/****** Object:  StoredProcedure [dbo].[Client.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Client.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Client
END

GO
/****** Object:  StoredProcedure [dbo].[Client.SelectClientById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Client.SelectClientById] @pId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Client WHERE ClientId = @pId
END

GO
/****** Object:  StoredProcedure [dbo].[DemandeAnnulation.InsertDemandeAnnulationByAdmininistrateur]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeAnnulation.InsertDemandeAnnulationByAdmininistrateur] @pAdministrateurId INT, @pDemandeReservationId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
		DECLARE @hasReservationId TINYINT, @reservationId INT, @errorResult VARCHAR(100);

    -- Insert statements for procedure here
	BEGIN TRAN T1
	SET @hasReservationId = (SELECT IIF(COUNT(*)>0, 1,0) AS result FROM dbo.Reservation WHERE DemandeReservationId = @pDemandeReservationId)

	IF @hasReservationId = 0
		BEGIN
			INSERT INTO dbo.DemandeAnnulation ( DemandeReservationId,  Raison ) VALUES ( @pDemandeReservationId, 'annulation' )

			IF @@ROWCOUNT > 0
				BEGIN
					COMMIT TRAN T1
					SELECT * FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId
				END
			ELSE
				BEGIN
					ROLLBACK TRAN T1
					SELECT @errorResult = CONCAT('Error 12001: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' without demandeReservationId');
					PRINT @errorResult;
				END
		END
	ELSE
		BEGIN
			DECLARE @hasReservationAnnule TINYINT;

			SET @hasReservationAnnule = (SELECT IIF(COUNT(*)>0,1,0) AS result FROM dbo.Emprunt AS em
				LEFT JOIN dbo.Reservation ON dbo.Reservation.EmpruntId = em.EmpruntId AND dbo.Reservation.ActionId = em.ActionId AND dbo.Reservation.LivreId = em.LivreId
				WHERE DemandeReservationId = @pDemandeReservationId AND em.Transition = 'annul')

			IF @hasReservationAnnule = 0
				BEGIN
					DECLARE @livreId INT, @clientId INT;

					SELECT @clientId = ClientId, @livreId = em.LivreId FROM dbo.Emprunt AS em
						LEFT JOIN dbo.Reservation ON dbo.Reservation.EmpruntId = em.EmpruntId AND dbo.Reservation.ActionId = em.ActionId AND dbo.Reservation.LivreId = em.LivreId
						WHERE DemandeReservationId = @pDemandeReservationId AND em.Transition = 'reserve'

					IF @clientId IS NOT NULL AND @clientId <> 0 AND @livreId IS NOT NULL AND @livreId <> 0
						BEGIN
							EXEC @reservationId = dbo.[Emprunt.Transition] @pTransition = 'annul', -- varchar(20)
								@pLivreId = @livreId, -- int
								@pClientId = @clientId, -- int
								@pAdministrateurId = @pAdministrateurId, -- int
								@pDemandeReservationId = @pDemandeReservationId -- int
							IF @reservationId IS NOT NULL AND @reservationId <> 0
								BEGIN
									COMMIT TRAN T1
									SELECT * FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId
								END
							ELSE
								BEGIN
									ROLLBACK TRAN T1
									SELECT @errorResult = CONCAT('Error 12001: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' without demandeReservationId');
									PRINT @errorResult;
								END
						END
					ELSE
						BEGIN
							ROLLBACK TRAN T1
							SELECT @errorResult = CONCAT('Error 12002: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' Error getting livreid and clientid');
							PRINT @errorResult;
						END
				END
			ELSE
				BEGIN
					INSERT INTO dbo.DemandeAnnulation ( DemandeReservationId,  Raison ) VALUES ( @pDemandeReservationId, 'annulation' )

					IF @@ROWCOUNT > 0
						BEGIN
							COMMIT TRAN T1
							SELECT * FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId
						END

					ELSE
						BEGIN
							ROLLBACK TRAN T1
							SELECT @errorResult = CONCAT('Error 12001: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' without demandeReservationId');
							PRINT @errorResult;

						END
				END
		END
				
	

END

GO
/****** Object:  StoredProcedure [dbo].[DemandeAnnulation.InsertDemandeAnnulationByClient]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeAnnulation.InsertDemandeAnnulationByClient] @pClientId INT, @pDemandeReservationId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
		DECLARE @hasReservationId TINYINT, @reservationId INT, @errorResult VARCHAR(100);

    -- Insert statements for procedure here
	BEGIN TRAN T1
	SET @hasReservationId = (SELECT IIF(COUNT(*)>0, 1,0) AS result FROM dbo.Reservation WHERE DemandeReservationId = @pDemandeReservationId)

	IF @hasReservationId = 0
		BEGIN
			INSERT INTO dbo.DemandeAnnulation ( DemandeReservationId,  Raison ) VALUES ( @pDemandeReservationId, 'annulation' )

			IF @@ROWCOUNT > 0
				BEGIN
					COMMIT TRAN T1
					SELECT * FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId
				END
			ELSE
				BEGIN
					ROLLBACK TRAN T1
					SELECT @errorResult = CONCAT('Error 12001: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' without demandeReservationId');
					PRINT @errorResult;
				END
		END
	ELSE
		BEGIN
			DECLARE @hasReservationAnnule TINYINT;

			SET @hasReservationAnnule = (SELECT IIF(COUNT(*)>0,1,0) AS result FROM dbo.Emprunt AS em
				LEFT JOIN dbo.Reservation ON dbo.Reservation.EmpruntId = em.EmpruntId AND dbo.Reservation.ActionId = em.ActionId AND dbo.Reservation.LivreId = em.LivreId
				WHERE DemandeReservationId = @pDemandeReservationId AND em.Transition = 'annul')

			IF @hasReservationAnnule = 0
				BEGIN
					DECLARE @livreId INT;

					SELECT @livreId = em.LivreId FROM dbo.Emprunt AS em
						LEFT JOIN dbo.Reservation ON dbo.Reservation.EmpruntId = em.EmpruntId AND dbo.Reservation.ActionId = em.ActionId AND dbo.Reservation.LivreId = em.LivreId
						WHERE DemandeReservationId = @pDemandeReservationId AND em.Transition = 'reserve'

					IF @livreId IS NOT NULL AND @livreId <> 0
						BEGIN
							EXEC @reservationId = dbo.[Emprunt.Transition] @pTransition = 'annul', -- varchar(20)
								@pLivreId = @livreId, -- int
								@pClientId = @pClientId, -- int
								@pAdministrateurId = NULL, -- int
								@pDemandeReservationId = @pDemandeReservationId -- int
							IF @reservationId IS NOT NULL AND @reservationId <> 0
								BEGIN
									COMMIT TRAN T1
									SELECT * FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId
								END
							ELSE
								BEGIN
									ROLLBACK TRAN T1
									SELECT @errorResult = CONCAT('Error 12001: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' without demandeReservationId');
									PRINT @errorResult;
								END
						END
					ELSE
						BEGIN
							ROLLBACK TRAN T1
							SELECT @errorResult = CONCAT('Error 12002: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' Error getting livreid and clientid');
							PRINT @errorResult;
						END
				END
			ELSE
				BEGIN
					INSERT INTO dbo.DemandeAnnulation ( DemandeReservationId,  Raison ) VALUES ( @pDemandeReservationId, 'annulation' )

					IF @@ROWCOUNT > 0
						BEGIN
							COMMIT TRAN T1
							SELECT * FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId
						END

					ELSE
						BEGIN
							ROLLBACK TRAN T1
							SELECT @errorResult = CONCAT('Error 12001: Cannot create Annulation in SP.DemandeAnnulation.InsertDemandeAnnulation ', @pDemandeReservationId, ' without demandeReservationId');
							PRINT @errorResult;

						END
				END
		END
				
	

END

GO
/****** Object:  StoredProcedure [dbo].[DemandeReservation.InsertDemandeReservation]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeReservation.InsertDemandeReservation] @ClientId INT, @RefLivreId INT
AS
DECLARE @demandeReservationId INT
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN T1
    -- Insert statements for procedure here
	SAVE TRAN T2
	BEGIN TRY
		INSERT INTO dbo.DemandeReservation ( ClientId, RefLivreId ) VALUES  ( @ClientId, @RefLivreId )

		SET @demandeReservationId = (SELECT SCOPE_IDENTITY());

	END TRY
	BEGIN CATCH
		BEGIN
			PRINT CONCAT('Error 11012: [DemandeReservation.InsertDemandeReservation] trigger activate, Cannot insert reflivre ', @RefLivreId, ' in the database');
		END
	END CATCH

	IF @demandeReservationId IS NOT NULL AND @demandeReservationId <> 0
		BEGIN
			COMMIT TRAN T1
			SELECT dr.*, IIF(da.DemandeReservationId IS NULL, 1, 0) AS Valide 
				FROM dbo.DemandeReservation AS dr 
				LEFT JOIN dbo.DemandeAnnulation AS da
				ON da.DemandeReservationId = dr.DemandeReservationId
			WHERE dr.DemandeReservationId = @demandeReservationId;
		END
	ELSE
		BEGIN
			IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRAN T1
				END
			PRINT CONCAT('Error 11011: [DemandeReservation.InsertDemandeReservation] Cannot insert reflivre ', @RefLivreId, ' in the database');
		END
END

GO
/****** Object:  StoredProcedure [dbo].[DemandeReservation.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeReservation.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dr.*, IIF(da.DemandeReservationId IS NULL, 1, 0) AS Valide FROM dbo.DemandeReservation AS dr LEFT JOIN dbo.DemandeAnnulation AS da
		ON da.DemandeReservationId = dr.DemandeReservationId
END

GO
/****** Object:  StoredProcedure [dbo].[DemandeReservation.SelectByEmpruntId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeReservation.SelectByEmpruntId] @pEmpruntId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dr.*, IIF(da.DemandeReservationId IS NULL, 1, 0) AS Valide FROM dbo.DemandeReservation AS dr 
		LEFT JOIN dbo.Reservation AS re ON re.DemandeReservationId = dr.DemandeReservationId
		LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
		WHERE re.EmpruntId = @pEmpruntId
END

GO
/****** Object:  StoredProcedure [dbo].[DemandeReservation.SelectById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeReservation.SelectById] @pDemandeReservationId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dr.*, IIF(da.DemandeReservationId IS NULL, 1, 0) AS Valide
		FROM dbo.DemandeReservation AS dr
		LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
		WHERE dr.DemandeReservationId = @pDemandeReservationId
END

GO
/****** Object:  StoredProcedure [dbo].[DemandeReservation.SelectForUserByRefLivreId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeReservation.SelectForUserByRefLivreId] @ClientId INT, @RefLivreId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT de.*, IIF(DATEDIFF(day, CreatedAt, GETDATE()) <= 15,1,0) AS Valide FROM dbo.DemandeReservation AS de
		LEFT JOIN dbo.RefLivre AS re
		ON de.RefLivreId = re.RefLivreId
		WHERE de.ClientId = @ClientId AND de.RefLivreId = @RefLivreId;
END

GO
/****** Object:  StoredProcedure [dbo].[DemandeReservation.SelectNewByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeReservation.SelectNewByClientId] @ClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dr.*, IIF(da.DemandeReservationId IS NULL, 1, 0) AS Valide FROM dbo.DemandeReservation AS dr LEFT JOIN dbo.DemandeAnnulation AS da
		ON da.DemandeReservationId = dr.DemandeReservationId
		WHERE dr.ClientId = @ClientId;
END

GO
/****** Object:  StoredProcedure [dbo].[DemandeReservation.SelectOldByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DemandeReservation.SelectOldByClientId] @ClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT dr.*, IIF(da.DemandeReservationId IS NULL, 1, 0) AS Valide FROM dbo.DemandeReservation AS dr LEFT JOIN dbo.DemandeAnnulation AS da
		ON da.DemandeReservationId = dr.DemandeReservationId
		WHERE dr.ClientId = @ClientId;
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.ConvertReservation]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.ConvertReservation] @pAdministrateurId INT, @pReservationId INT
AS
BEGIN
	DECLARE @empruntId INT, @errorResult VARCHAR(50), @pLivreId INT, @pClientId INT, @pDemandeReservationId INT;

	SET NOCOUNT ON;

	BEGIN TRAN
	SELECT TOP(1) @pLivreid = em.LivreId, @pClientId = em.ClientId, @pDemandeReservationId = re.DemandeReservationId
		FROM dbo.Emprunt AS em 
			INNER JOIN dbo.Reservation AS re ON re.EmpruntId = em.EmpruntId AND re.ActionId = em.ActionId AND re.LivreId = em.LivreId
		WHERE re.ReservationId = @pReservationId
		ORDER BY em.EmpruntId DESC
	IF @pLivreId IS NOT NULL AND @pClientId IS NOT NULL AND @pDemandeReservationId IS NOT NULL
		BEGIN
			EXEC @empruntId = [dbo].[Emprunt.Transition] @pTransition = 'convert', @pLivreId = @pLivreId, @pClientId = @pClientId, @pAdministrateurId = @pAdministrateurId, @pDemandeReservationId = @pDemandeReservationId
			IF @empruntId IS NOT NULL AND @empruntId <> 0
				BEGIN
					COMMIT TRAN
					SELECT * FROM dbo.Emprunt WHERE EmpruntId = @empruntId;
				END
			ELSE
				BEGIN
					IF @@TRANCOUNT > 0
						BEGIN
							ROLLBACK TRAN
						END
					SELECT @errorResult = CONCAT('Error 10951:Impossible to create convertion in SP emprunt.ConvertReservation for the book ', @pLivreId);
					PRINT @errorResult;
				END
		END
	ELSE
		BEGIN
			IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRAN
				END
			SELECT @errorResult = CONCAT('Error 10952:Impossible to create convertion in SP emprunt.ConvertReservation for the reservation ', @pReservationId, ' cause fild not well set');
			PRINT @errorResult;
		END
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.InsertAnnul]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.InsertAnnul] @pAdministrateurId INT, @pReservationId INT
AS
BEGIN
	DECLARE @reservationId INT, @clientId INT, @status TINYINT, @demandeReservationId INT, @livreId INT, @errorResult VARCHAR(50);

	SET NOCOUNT ON;
	BEGIN TRAN T1
	
	SELECT  @clientId = ClientId, @demandeReservationId = DemandeReservationId, @status = Status, @livreId = LivreId
		FROM (
			SELECT em.ClientId, dr.DemandeReservationId,   IIF(em.State = 'res', 1, 0) AS Status, em.LivreId FROM dbo.Emprunt AS em
				LEFT JOIN dbo.Reservation AS re ON re.EmpruntId = em.EmpruntId AND re.LivreId = em.LivreId AND re.ActionId = em.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE re.ReservationId = @pReservationId
		) AS tmpAnnul;

	IF @clientId IS NOT NULL AND @demandeReservationId IS NOT NULL AND @status = 1
		BEGIN
			EXEC @reservationId = [dbo].[Emprunt.Transition] @pTransition = 'annul', @pLivreId = @livreId, @pClientId = @clientId, @pAdministrateurId = @pAdministrateurId, @pDemandeReservationId = @demandeReservationId
			IF @reservationId IS NOT NULL AND @reservationId <> 0
				BEGIN
					COMMIT TRAN T1
					SELECT em.* FROM dbo.Emprunt AS em 
						LEFT JOIN dbo.Reservation AS re ON re.EmpruntId = em.EmpruntId AND re.ActionId = em.ActionId AND re.LivreId = em.LivreId
						WHERE re.ReservationId = @reservationId;
				END
			ELSE
				BEGIN
					IF @@TRANCOUNT > 0
						BEGIN
							ROLLBACK TRAN T1
						END
					SELECT @errorResult = CONCAT('Error 10301:Impossible to create reservation annul in SP emprunt.insertReturn for the reservation ', @pReservationId);
					PRINT @errorResult;
				END
		END
	ELSE
		BEGIN
			IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRAN T1
				END
			SELECT @errorResult = CONCAT('Error 10302:Impossible to create reservation annul in SP emprunt.insertReturn for the reservation ', @pReservationId, ' because the book is not in emp status');
			PRINT @errorResult;
		END
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.InsertEmprunt]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery22.sql|7|0|C:\Users\MICHAL~1\AppData\Local\Temp\~vsC5BE.sql
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.InsertEmprunt] @pAdministrateurId INT, @pPersonneId INT, @pLivreId INT
AS
BEGIN
	DECLARE @empruntId INT, @errorResult VARCHAR(50);

	SET NOCOUNT ON;

	BEGIN TRAN T1

	EXEC @empruntId = [dbo].[Emprunt.Transition] @pTransition = 'emprunt', @pLivreId = @pLivreId, @pClientId = @pPersonneId, @pAdministrateurId = @pAdministrateurId
	IF @empruntId IS NOT NULL AND @empruntId <> 0
		BEGIN
			COMMIT TRAN T1
			SELECT * FROM dbo.Emprunt WHERE EmpruntId = @empruntId;
		END
    ELSE
		BEGIN
			IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRAN T1
				END
				
			SELECT @errorResult = CONCAT('Error 10371:Impossible to create emprunt in SP emprunt.insertEmprunt for the book ', @pLivreId);
			PRINT @errorResult;
			RETURN 0
		END
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.InsertRetour]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.InsertRetour] @pAdministrateurId INT, @pLivreId INT
AS
BEGIN
	DECLARE @empruntId INT, @clientId INT, @status TINYINT, @errorResult VARCHAR(50);

	SET NOCOUNT ON;
	BEGIN TRAN T1
	SELECT TOP(1) @clientId = ClientId, @status = IIF(State = 'emp', 1, 0) FROM dbo.Emprunt WHERE LivreId = @pLivreId ORDER BY EmpruntId DESC;

	IF @clientId IS NOT NULL AND @status = 1
		BEGIN
			EXEC @empruntId = [dbo].[Emprunt.Transition] @pTransition = 'retour', @pLivreId = @pLivreId, @pClientId = @clientId, @pAdministrateurId = @pAdministrateurId
			IF @empruntId IS NOT NULL AND @empruntId <> 0
				BEGIN
					COMMIT TRAN T1
					SELECT * FROM dbo.Emprunt WHERE EmpruntId = @empruntId;
				END
			ELSE
				BEGIN
					IF @@TRANCOUNT > 0
						BEGIN
							ROLLBACK TRAN T1
						END
					SELECT @errorResult = CONCAT('Error 10361:Impossible to create emprunt return in SP emprunt.insertReturn for the book ', @pLivreId);
					PRINT @errorResult;
				END
		END
	ELSE
		BEGIN
			IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRAN T1
				END
			SELECT @errorResult = CONCAT('Error 10362:Impossible to create emprunt return in SP emprunt.insertReturn for the book ', @pLivreId, ' because the book is not in emp status');
			PRINT @errorResult;
		END
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Emprunt;
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.SelectByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.SelectByClientId] @pClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Emprunt WHERE ClientId = @pClientId;
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.SelectById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.SelectById] @pEmpruntId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Emprunt WHERE EmpruntId = @pEmpruntId
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.SelectForUserByLivreId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.SelectForUserByLivreId] @pClientId INT, @pLivreId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT em.* FROM dbo.Emprunt AS em
		LEFT JOIN dbo.Livre AS li
		ON em.LivreId = li.LivreId
		WHERE em.ClientId = @pClientId AND em.LivreId = @pLivreId
END

GO
/****** Object:  StoredProcedure [dbo].[Emprunt.Transition]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Emprunt.Transition] @pTransition VARCHAR(20), @pLivreId INT, @pClientId INT, @pAdministrateurId INT, @pDemandeReservationId INT = NULL
AS
BEGIN

DECLARE @empruntId INT, @errorResult VARCHAR(100), @bResult TINYINT, @actionId INT, @reservationId INT;


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SET @actionId = (SELECT COUNT(*) AS nomber FROM dbo.LivreActions WHERE LivreId = @pLivreId) + 1

	IF @pTransition = 'initial'
		BEGIN
			SAVE TRAN T2

			BEGIN TRY
				INSERT INTO dbo.LivreActions (ActionId, LivreId, ActionType, State) VALUES  (@actionId, @pLivreId, 'new', 'reg');

				IF @actionId IS NOT NULL AND @@ROWCOUNT > 0
					BEGIN
						INSERT INTO dbo.Emprunt
								( LivreId, ActionId, State, Transition, AdministrateurId, ClientId) 
								VALUES ( @pLivreId, @actionId, 'reg', 'initial', @pAdministrateurId,  @pClientId )
					
						SET @empruntId = (SELECT SCOPE_IDENTITY());
					
						IF @empruntId IS NOT NULL
							BEGIN 
								UPDATE dbo.LivreActions SET CurrentState = @EmpruntId WHERE ActionId = @ActionId AND LivreId = @pLivreId;

								--COMMIT TRAN T2
								RETURN @empruntId;
							END
						ELSE
							BEGIN
								SELECT @errorResult = CONCAT('Error 10681: in SP Transition,  Cannot create emprunt for new livre ', @pLivreId, ' exist');
								PRINT @errorResult;
								RETURN 0
							END
					END
				ELSE
					BEGIN
						SELECT @errorResult = CONCAT('Error 10682: in SP Transition,  Cannot create livre action for new livre ', @pLivreId, ' exist');
						PRINT @errorResult;
						RETURN 0
					END
			END TRY
			BEGIN CATCH
				SELECT @errorResult = CONCAT('Error 10683: in SP Transition, trigger error, Cannot create livre action for new livre ', @pLivreId, ' exist');
				PRINT @errorResult;
				RETURN 0
			END CATCH
            
		END
	ELSE IF @pTransition = 'emprunt' 
		BEGIN
			SAVE TRAN T2
			SET @bResult = (SELECT TOP(1) iif(State = 'reg', 1, 0) AS result FROM dbo.Emprunt WHERE LivreId = @pLivreId ORDER BY EmpruntId DESC);
			IF @bResult = 1
				BEGIN
					BEGIN TRY
						INSERT INTO dbo.LivreActions (ActionId, LivreId, ActionType, State) VALUES  (@actionId, @pLivreId, 'emprunter', 'emp' );

						INSERT dbo.Emprunt
								( LivreId, ActionId, State, Transition, AdministrateurId, ClientId)
							VALUES  ( @pLivreId, @actionId, 'emp', 'emprunt', @pAdministrateurId, @pClientId);
						SET @empruntId = (SELECT SCOPE_IDENTITY());

						IF @empruntId IS NOT NULL AND @actionId IS NOT NULL
							BEGIN
								UPDATE dbo.LivreActions SET CurrentState = @EmpruntId WHERE ActionId = @ActionId AND LivreId = @pLivreId;


								DECLARE @status1 INT, @livreId1 INT, @demandeReservationId1 INT, @clientId1 INT, @valid TINYINT, @final TINYINT;

								SET @final = 1;
		
								DECLARE J CURSOR FAST_FORWARD /**/ FOR
								SELECT em.LivreId, MIN(ClientId) AS ClientId, MIN(DemandeReservationId) AS  DemandeReservationId, IIF(MIN(em.State) = 'res', 1, 0) AS valid FROM dbo.Livre AS li1
									LEFT JOIN dbo.RefLivre AS rl ON rl.RefLivreId = li1.RefLivreId
									LEFT JOIN dbo.Livre AS li2 ON li2.RefLivreId = rl.RefLivreId
									LEFT JOIN dbo.Reservation AS re ON re.LivreId = li1.LivreId
									LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId 
									WHERE li2.LivreId = @pLivreId AND em.ClientId = @pClientId
									GROUP BY em.LivreId
								OPEN J

								FETCH NEXT FROM J INTO @LivreId1, @ClientId1, @demandeReservationId1, @valid
								SET @status1 = @@FETCH_STATUS

								WHILE @status1 = 0
									BEGIN
										DECLARE @empruntId1 INT;
										PRINT CONCAT(@LivreId1, ', ', @ClientId1, ', ',@demandeReservationId1, ', ', @valid)
										IF @valid = 1
											BEGIN
												EXEC @empruntId1 = [dbo].[Emprunt.Transition] @pTransition = 'annul', @pLivreId = @LivreId1, @pClientId = @ClientId1, @pAdministrateurId = @pAdministrateurId, @pDemandeReservationId = @demandeReservationId1
												IF @empruntId1 IS NULL
													BEGIN
														SET @status1 = 1
														SET @final = 0
														SELECT @errorResult = CONCAT('Error 10601: in SP Transition, Impossible to create emprunt return in SP emprunt.insertReturn for the book ', 15);
														PRINT @errorResult;
													END
											END
										IF @status1 = 0
											BEGIN
												FETCH NEXT FROM J INTO @LivreId1, @ClientId1, @demandeReservationId1, @valid
												SET @status1 = @@FETCH_STATUS
											END
									END
			
								CLOSE J;
								DEALLOCATE J;

								IF @final = 1
									BEGIN
										--COMMIT TRAN T2
										RETURN @empruntId;
									END
								ELSE
									BEGIN
										SELECT @errorResult = CONCAT('Error 10602: in SP Transition, Impossible to create emprunt for the book ', @pLivreId);
										PRINT @errorResult;
										RETURN 0
									END

							END
						ELSE
							BEGIN
								SELECT @errorResult = CONCAT('Error 10605: in SP Transition, Impossible to create emprunt for the book ', @pLivreId);
								PRINT @errorResult;
								RETURN 0;
							END

					END TRY
					BEGIN CATCH
						SELECT @errorResult = CONCAT('Error 10603: in SP Transition,  The book ', @pLivreId, ' too much emprunt ''reg''.');
						PRINT @errorResult;
						RETURN 0
					END CATCH
				END
                
			ELSE
				BEGIN
					SELECT @errorResult = CONCAT('Error 10604: in SP Transition,  The book ', @pLivreId, ' is not in the state ''reg''.');
					PRINT @errorResult;
					RETURN 0
				END
		END
	ELSE IF @pTransition = 'reserve'
		BEGIN
			SAVE TRAN T2
			SET @bResult = (SELECT TOP(1) iif(State = 'reg', 1, 0) AS result FROM dbo.Emprunt WHERE LivreId = @pLivreId ORDER BY EmpruntId DESC);
			IF @bResult = 1
				BEGIN
					BEGIN TRY
						INSERT INTO dbo.LivreActions (ActionId, LivreId, ActionType, State) VALUES  (@actionId, @pLivreId, 'reserver', 'res' );

						INSERT dbo.Emprunt
								( LivreId, ActionId, State, Transition, AdministrateurId, ClientId)
							VALUES  ( @pLivreId, @actionId, 'res', 'reserve', @pAdministrateurId, @pClientId);
						SET @empruntId = (SELECT SCOPE_IDENTITY());

						IF @empruntId IS NOT NULL AND @actionId IS NOT NULL
							BEGIN
								UPDATE dbo.LivreActions SET CurrentState = @EmpruntId WHERE ActionId = @ActionId AND LivreId = @pLivreId;
								IF @pDemandeReservationId IS NOT NULL
									BEGIN
										INSERT dbo.Reservation
											( EmpruntId, ActionId, LivreId, DemandeReservationId )
											VALUES  ( @empruntId , @actionId , @pLivreId , @pDemandeReservationId );

										-- SELECT * FROM dbo.Emprunt WHERE EmpruntId = @empruntId;
										SET @reservationId = (SELECT SCOPE_IDENTITY());
										IF @reservationId IS NOT NULL
											BEGIN
												--COMMIT TRAN T2
												RETURN @reservationId
											END
										ELSE
											BEGIN
												SELECT @errorResult = CONCAT('Error 10611: in SP Transition, Impossible to create reserve in reservation for the book ', @pLivreId, ' error in insert reservation');
												PRINT @errorResult;
												RETURN 0
											END
									END
								ELSE
									BEGIN
										SELECT @errorResult = CONCAT('Error 10612: in SP Transition, Impossible to create reserve in livreState for the book ', @pLivreId, ' without demandeReservationId');
										PRINT @errorResult;
										RETURN 0
									END
							END
						ELSE
							BEGIN
								SELECT @errorResult = CONCAT('Error 10613: in SP Transition, Impossible to create reserve for the book ', @pLivreId);
								PRINT @errorResult;
								RETURN 0
							END
					END TRY
					BEGIN CATCH
						SELECT @errorResult = CONCAT('Error 10614: in SP Transition,  The book ', @pLivreId, ' error ''reg''.');
						PRINT @errorResult;
						RETURN 0
					END CATCH
                    
				END
			ELSE
				BEGIN
					SELECT @errorResult = CONCAT('Error 10614: in SP Transition,  The book ', @pLivreId, ' is not in the state ''reg''.');
					PRINT @errorResult;
					RETURN 0
				END
		END
	ELSE IF @pTransition = 'retour'
		BEGIN
			SAVE TRAN T2
			SET @bResult = (SELECT TOP(1) iif(State = 'emp', 1, 0) AS result FROM dbo.Emprunt WHERE LivreId = @pLivreId ORDER BY EmpruntId DESC);
			IF @bResult = 1
				BEGIN
					BEGIN TRY
						INSERT INTO dbo.LivreActions (ActionId, LivreId, ActionType, State) VALUES  (@actionId, @pLivreId, 'retourner', 'reg' );

						INSERT dbo.Emprunt
								( LivreId, ActionId, State, Transition, AdministrateurId, ClientId)
							VALUES  ( @pLivreId, @actionId, 'reg', 'retour', @pAdministrateurId, @pClientId);
						SET @empruntId = (SELECT SCOPE_IDENTITY());

						IF @empruntId IS NOT NULL AND @actionId IS NOT NULL
							BEGIN
								UPDATE dbo.LivreActions SET CurrentState = @EmpruntId WHERE ActionId = @ActionId AND LivreId = @pLivreId;
							
								DECLARE @diffDateDay NUMERIC(5,2), @montant NUMERIC(5,2), @cout NUMERIC(5,2), @amende NUMERIC(5,2), @debutDate DATETIME, @isAdministrateur TINYINT, @itemId INT;

								SELECT TOP(1) @diffDateDay = DATEDIFF(day, CreatedAt, GETDATE()) + 1, @debutDate = CreatedAt FROM dbo.Emprunt WHERE LivreId = @pLivreId AND State='emp' ORDER BY CreatedAt DESC;
								SELECT @isAdministrateur = COUNT(*) FROM dbo.Administrateur WHERE AdministrateurId = @pClientId

								IF @isAdministrateur = 1
									BEGIN
										SET @cout = 0
										SET @amende = IIF(@diffDateDay < 28, 0, CEILING((@diffDateDay - 28)/7))
									END
								ELSE
									BEGIN
										SET @cout = CEILING(@diffDateDay / 7)
										SET @amende = IIF(@diffDateDay < 28, 0, CEILING((@diffDateDay - 28)/7))
									END
								
								SET @montant = @cout + @amende

								INSERT INTO dbo.Items ( EmpruntId, LivreId, ActionId, ClientId, AdministrateurId, Montant, Cout, Amende, DebutDate )
									VALUES ( @empruntId, @pLivreId, @actionId,  @pClientId, @pAdministrateurId, @montant, @cout, @amende, @debutDate )
								
								SET @itemId = (SELECT SCOPE_IDENTITY());

								IF @itemId IS NOT NULL AND @itemId <> 0
									BEGIN
										--COMMIT TRAN T2
										RETURN @empruntId;
									END
								ELSE
									BEGIN
										SELECT @errorResult = CONCAT('Error 10623: in SP Transition,  in Transition, Impossible to create Items for the book ', @pLivreId);
										PRINT @errorResult;
										RETURN 0
									END
							END
						ELSE
							BEGIN
								SELECT @errorResult = CONCAT('Error 10621: in SP Transition, Impossible to create retour for the book ', @pLivreId);
								PRINT @errorResult;
								RETURN 0
							END
					END TRY
					BEGIN CATCH
						SELECT @errorResult = CONCAT('Error 10624: in SP Transition, case of the trigger is executed The book ', @pLivreId, ' is not in the state ''emp''.');
						PRINT @errorResult;
						RETURN 0
					END CATCH
                    
				END
			ELSE
				BEGIN
					SELECT @errorResult = CONCAT('Error 10622: in SP Transition,  The book ', @pLivreId, ' is not in the state ''emp''.');
					PRINT @errorResult;
					RETURN 0
				END
		END
	ELSE IF @pTransition = 'convert'
		BEGIN
			SAVE TRAN T2
			SET @bResult = (SELECT TOP(1) iif(State = 'res', 1, 0) AS result FROM dbo.Emprunt WHERE LivreId = @pLivreId ORDER BY EmpruntId DESC);
			IF @bResult = 1
				BEGIN
					BEGIN TRY
						INSERT INTO dbo.LivreActions (ActionId, LivreId, ActionType, State) VALUES  (@actionId, @pLivreId, 'emprunter', 'emp' );

						INSERT dbo.Emprunt
								( LivreId, ActionId, State, Transition, AdministrateurId, ClientId)
							VALUES  ( @pLivreId, @actionId, 'emp', 'convert', @pAdministrateurId, @pClientId);
						SET @empruntId = (SELECT SCOPE_IDENTITY());

						IF @empruntId IS NOT NULL AND @actionId IS NOT NULL
							BEGIN
								UPDATE dbo.LivreActions SET CurrentState = @EmpruntId WHERE ActionId = @ActionId AND LivreId = @pLivreId;

								INSERT INTO dbo.Reservation ( EmpruntId, ActionId, LivreId, DemandeReservationId ) VALUES ( @empruntId, @actionId, @pLivreId, @pDemandeReservationId )
									
								SET @reservationId = (SELECT SCOPE_IDENTITY());

								IF @reservationId IS NOT NULL AND @reservationId <> 0
									BEGIN
										--COMMIT TRAN T2
										RETURN @empruntId;
									END
								ELSE
									BEGIN
										SELECT @errorResult = CONCAT('Error 10633: in SP Transition, Impossible to convert reservation from res to emp for the book ', @pLivreId);
										PRINT @errorResult;
										RETURN 0
									END
							END
						ELSE
							BEGIN
								SELECT @errorResult = CONCAT('Error 10631: in SP Transition, Impossible to create convert for the book ', @pLivreId);
								PRINT @errorResult;
								RETURN 0
							END
					END TRY
					BEGIN CATCH
						SELECT @errorResult = CONCAT('Error 10634: in SP Transition, end cause of a trigger, Impossible to create convert for the book ', @pLivreId);
						PRINT @errorResult;
						RETURN 0
					END CATCH
                    
				END
			ELSE
				BEGIN
					SELECT @errorResult = CONCAT('Error 10632: in SP Transition,  The book ', @pLivreId, ' is not in the state ''res''.');
					PRINT @errorResult;
					RETURN 0
				END
		END
	ELSE IF @pTransition = 'annul'
		BEGIN
			SAVE TRAN T2
			SET @bResult = (SELECT TOP(1) iif(State = 'res', 1, 0) AS result FROM dbo.Emprunt WHERE LivreId = @pLivreId ORDER BY EmpruntId DESC);
			IF @bResult = 1
				BEGIN
					BEGIN TRY
						INSERT INTO dbo.LivreActions (ActionId, LivreId, ActionType, State) VALUES  (@actionId, @pLivreId, 'annuler', 'reg' );

						INSERT dbo.Emprunt
								( LivreId, ActionId, State, Transition, AdministrateurId, ClientId)
							VALUES  ( @pLivreId, @actionId, 'reg', 'annul', @pAdministrateurId, @pClientId);
						SET @empruntId = (SELECT SCOPE_IDENTITY());

						IF @empruntId IS NOT NULL AND @actionId IS NOT NULL
							BEGIN
								IF @pDemandeReservationId IS NOT NULL
									BEGIN
										UPDATE dbo.LivreActions SET CurrentState = @EmpruntId WHERE ActionId = @ActionId AND LivreId = @pLivreId;
										INSERT dbo.Reservation
											( EmpruntId, ActionId, LivreId, DemandeReservationId )
											VALUES  ( @empruntId , @actionId , @pLivreId , @pDemandeReservationId );

										-- SELECT * FROM dbo.Emprunt WHERE EmpruntId = @empruntId;
										SET @reservationId = (SELECT SCOPE_IDENTITY());
										IF @reservationId IS NOT NULL
											BEGIN
												DECLARE @hasDemandeAnnulation INT
												SET @hasDemandeAnnulation = (SELECT IIF(COUNT(*)>0, 1, 0) AS result FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId)
												IF @hasDemandeAnnulation = 1
													BEGIN
														--COMMIT TRAN T2
														RETURN @reservationId
													END
												ELSE
													BEGIN
														INSERT INTO dbo.DemandeAnnulation ( DemandeReservationId,  Raison ) VALUES ( @pDemandeReservationId, 'annulation' )

														IF @@ROWCOUNT > 0
															BEGIN
																--COMMIT TRAN T2
																RETURN @reservationId
																--SELECT * FROM dbo.DemandeAnnulation WHERE DemandeReservationId = @pDemandeReservationId
															END

														ELSE
															BEGIN
																SELECT @errorResult = CONCAT('Error 10644:in SP Transition, Cannot create Annulation in ', @pDemandeReservationId, ' without demandeReservationId');
																PRINT @errorResult;
																RETURN 0
															END
													END

											END
										ELSE
											BEGIN
												SELECT @errorResult = CONCAT('Error 10641: in SP Transition, Impossible to create annul in reservation for the book ', @pLivreId, ' error in insert reservation');
												PRINT @errorResult;
												RETURN 0
											END
									END
								ELSE
									BEGIN
										SELECT @errorResult = CONCAT('Error 10642: in SP Transition, Impossible to create annul in livreState for the book ', @pLivreId, ' without demandeReservationId');
										PRINT @errorResult;
										RETURN 0
									END
							END
						ELSE
							BEGIN
								SELECT @errorResult = CONCAT('Error 10643: in SP Transition, Impossible to create anull for the book ', @pLivreId);
								PRINT @errorResult;
								RETURN 0
							END
					END TRY
					BEGIN CATCH
						SELECT @errorResult = CONCAT('Error 10645: in SP Transition, end cause of a trigger, The book ', @pLivreId, ' is not in the state ''res''.');
						PRINT @errorResult;
						RETURN 0
					END CATCH
                    
				END
			ELSE
				BEGIN
					SELECT @errorResult = CONCAT('Error 10644: in SP Transition,  The book ', @pLivreId, ' is not in the state ''res''.');
					PRINT @errorResult;
					RETURN 0
				END
		END

	
END

GO
/****** Object:  StoredProcedure [dbo].[Item.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Item.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Items
END

GO
/****** Object:  StoredProcedure [dbo].[Item.SelectByAdministrateurId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Item.SelectByAdministrateurId] @pAdministrateurId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Items WHERE AdministrateurId = @pAdministrateurId;
END

GO
/****** Object:  StoredProcedure [dbo].[Item.SelectByBibliothequeId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Item.SelectByBibliothequeId] @pBibliothequeId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT it.* FROM dbo.Items AS it
		LEFT JOIN dbo.Livre AS li
		ON li.LivreId = it.LivreId
		WHERE li.BibliothequeId = @pBibliothequeId;
END

GO
/****** Object:  StoredProcedure [dbo].[Item.SelectByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Item.SelectByClientId] @pClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Items WHERE ClientId = @pClientId;
END

GO
/****** Object:  StoredProcedure [dbo].[Item.SelectByEmpruntId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Item.SelectByEmpruntId] @pEmpruntId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Items WHERE EmpruntId = @pEmpruntId;
END

GO
/****** Object:  StoredProcedure [dbo].[Item.SelectByItemId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Item.SelectByItemId] @pItemId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Items WHERE ItemId = @pItemId;
END

GO
/****** Object:  StoredProcedure [dbo].[Item.SelectByLivreId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Item.SelectByLivreId] @pLivreId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Items WHERE LivreId = @pLivreId;
END

GO
/****** Object:  StoredProcedure [dbo].[Livre.InsertLivre]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Livre.InsertLivre] 
	@BibliothequeId INT,
	@RefLivreId INT,
	@ISBN VARCHAR(13),
	@Titre VARCHAR(50),
	@Description NVARCHAR(MAX),
	@Auteur VARCHAR(50),
	@Langue VARCHAR(50),
	@Editeur VARCHAR(50),
	@Published DATE,
	@imageUrl VARCHAR(250),
	@administrateurId INT
AS

DECLARE @RefLivreCount INT,
		@RefLivreId2 INT,
		@LivreId INT,
		@InternalReference VARCHAR(50);
		
DECLARE @result VARCHAR(100);

BEGIN
	
	SET @RefLivreId2 = (SELECT RefLivreId FROM dbo.RefLivre WHERE RefLivreId = @RefLivreId OR ISBN = @ISBN);

	BEGIN TRAN T1
	
	IF @RefLivreId2 IS NULL
	BEGIN
		INSERT INTO dbo.RefLivre ( ISBN, Titre, Description, Auteur, Langue, Editeur, Published, imageUrl) 
			VALUES (@ISBN, @Titre, @Description, @Auteur, @Langue, @Editeur, @Published, @imageUrl);
		
		SET @RefLivreId2 = (SELECT SCOPE_IDENTITY());
	END

	IF @RefLivreId2 IS NOT NULL
		BEGIN
			BEGIN TRY

				INSERT INTO dbo.Livre ( RefLivreId, BibliothequeId, LivreStatusId, InternalReference) 
					VALUES (@RefLivreId2, @BibliothequeId, 1, 0);
			
				SET @LivreId = (SELECT SCOPE_IDENTITY());
	
				SET @InternalReference = CONCAT('B',@BibliothequeId, 'R', @RefLivreId2, 'L', @LivreId);
		
				DECLARE @number INT;
				SET @number = (SELECT COUNT(*) FROM dbo.Livre WHERE InternalReference = @InternalReference)
	
				IF @number = 0
					BEGIN
						UPDATE dbo.Livre SET InternalReference = @InternalReference WHERE LivreId = @LivreId;
						DECLARE @empruntId INT;
						EXEC @empruntId = [dbo].[Emprunt.Transition] @pTransition = 'initial',
							@pLivreId = @LivreId,
							@pClientId = NULL,
							@pAdministrateurId = @administrateurId
						IF @empruntId IS NOT NULL
							BEGIN
								COMMIT TRAN T1
								SELECT * FROM dbo.Livre WHERE LivreId = @LivreId
							END
						ELSE
							BEGIN
								IF @@TRANCOUNT > 0
									BEGIN
										ROLLBACK TRAN T1
									END
								SELECT @result = CONCAT('Error 10824: impossible to create empruntstate for the book with isbn : ', @ISBN, ' in the sp Livre.InsertLivre and sp emprunt.transition');
								PRINT @result;
								RETURN 0
							END
					END
				ELSE
					BEGIN
						IF @@TRANCOUNT > 0
							BEGIN
								ROLLBACK TRAN T1
							END
						SELECT @result = CONCAT('Error 10823: The object id ', @ISBN, ' exist');
						PRINT @result;
						RETURN 0
					END
			END TRY
			BEGIN CATCH
				SELECT @result = CONCAT('Error 10822: The object, trigger error, livre isbn: ', @ISBN, ' don''t exist');
				PRINT @result;
				RETURN 0
			END CATCH
		END
	ELSE
		BEGIN
			IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRAN T1
				END
			SELECT @result = CONCAT('Error 10821: Impossible to create RefLivre : ', @RefLivreId2, ' : ', @ISBN, ' : ', @Titre, ' : ', @Description, ' : ', @Auteur, ' : ', @Langue, ' : ', @Editeur, ' : ', @Published, ' : ', @imageUrl, ' exist');
			PRINT @result;
			RETURN 0
		END
	
END

GO
/****** Object:  StoredProcedure [dbo].[Livre.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Livre.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Livre;
END

GO
/****** Object:  StoredProcedure [dbo].[Livre.SelectByBibliothequeId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Livre.SelectByBibliothequeId] @BibliothequeId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Livre WHERE BibliothequeId = @BibliothequeId;
END

GO
/****** Object:  StoredProcedure [dbo].[Livre.SelectById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Livre.SelectById] @LivreId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Livre WHERE LivreId = @LivreId;
END

GO
/****** Object:  StoredProcedure [dbo].[Livre.SelectByInfo]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Livre.SelectByInfo] @pLivreInfo VARCHAR(50), @pBibliothequeId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT dbo.Livre.* FROM dbo.Livre INNER  JOIN 
		(SELECT tmp1.* FROM (SELECT em.LivreId, em.State, em.ActionId FROM Emprunt AS em 
			LEFT JOIN dbo.Livre AS li ON li.LivreId = em.LivreId
			LEFT JOIN dbo.RefLivre AS rl ON rl.RefLivreId = li.RefLivreId
			WHERE (li.InternalReference LIKE '%' + @pLivreInfo + '%' OR rl.Titre LIKE '%' + @pLivreInfo +'%') AND li.BibliothequeId = @pBibliothequeId ) AS tmp1
		LEFT JOIN (SELECT em.LivreId, em.State, ActionId FROM Emprunt AS em 
			LEFT JOIN dbo.Livre AS li ON li.LivreId = em.LivreId
			LEFT JOIN dbo.RefLivre AS rl ON rl.RefLivreId = li.RefLivreId
			WHERE (li.InternalReference LIKE '%' + @pLivreInfo + '%' OR rl.Titre LIKE '%' + @pLivreInfo +'%') AND li.BibliothequeId = @pBibliothequeId ) AS tmp2
			ON tmp2.LivreId = tmp1.LivreId AND tmp1.ActionId < tmp2.ActionId WHERE tmp2.ActionId IS NULL AND tmp1.State = 'reg') AS temp
		ON temp.LivreId = dbo.Livre.LivreId
END

GO
/****** Object:  StoredProcedure [dbo].[LivreStatus.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[LivreStatus.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.LivreStatus;
END

GO
/****** Object:  StoredProcedure [dbo].[Personne.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Personne.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Personne
END

GO
/****** Object:  StoredProcedure [dbo].[Personne.SelectById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Personne.SelectById] @pId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Personne WHERE PersonneId = @pId
END

GO
/****** Object:  StoredProcedure [dbo].[Personne.SelectByInfo]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Personne.SelectByInfo] @pInfo VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT pe.* FROM dbo.Personne AS pe 
		WHERE	pe.PersonneFirstName LIKE '%' + @pInfo + '%'
			OR	pe.PersonneLastname LIKE '%' + @pInfo + '%'
			OR	CONCAT(pe.PersonneFirstName, ' ', PersonneLastname) LIKE '%' + @pInfo + '%'
			OR pe.PersonneMatricule LIKE '%' + @pInfo + '%'
END

GO
/****** Object:  StoredProcedure [dbo].[Personne.SelectByLivreEmpruntId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Personne.SelectByLivreEmpruntId] @pEmpruntId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT pe.PersonneId, pe.PersonneEmail, pe.PersonneFirstName, pe.PersonneLastname, pe.PersonneMatricule, pe.PersonneUsername 
		FROM dbo.Personne AS pe 
			LEFT JOIN dbo.Emprunt AS em ON em.ClientId = pe.PersonneId 
		WHERE em.EmpruntId = @pEmpruntId
END

GO
/****** Object:  StoredProcedure [dbo].[Personne.SelectByName]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Personne.SelectByName] @pName VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Personne WHERE PersonneFirstName = CONCAT('%',@pName,'%') OR PersonneLastName = CONCAT('%',@pName,'%')
END

GO
/****** Object:  StoredProcedure [dbo].[RefLivre.InsertLivre]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RefLivre.InsertLivre] 
	@ISBN VARCHAR(13),
	@Titre VARCHAR(50),
	@Description NVARCHAR(MAX),
	@Auteur VARCHAR(50),
	@Langue VARCHAR(50),
	@Editeur VARCHAR(50),
	@Published DATE,
	@imageUrl VARCHAR(250)
AS

DECLARE @RefLivreId INT;

BEGIN
	
	BEGIN TRAN
		-- Insert statements for procedure here
		DECLARE @number INT;
		SET @number = (SELECT COUNT(*) FROM dbo.RefLivre WHERE ISBN = @ISBN)
	
		IF @number = 0
		BEGIN
			INSERT INTO dbo.RefLivre ( ISBN, Titre, Description, Auteur, Langue, Editeur, Published, imageUrl) VALUES (@ISBN, @Titre, @Description, @Auteur, @Langue, @Editeur, @Published, @imageUrl);
			COMMIT TRAN
		END
		ELSE
		BEGIN
			ROLLBACK TRAN
			DECLARE @result VARCHAR(100);
			SELECT @result = CONCAT('Error 10021: The object id ', @ISBN, ' exist');
			PRINT @result;
		END
	
	SET @RefLivreId = (SELECT SCOPE_IDENTITY());
	SELECT * FROM RefLivre WHERE RefLivreId = @RefLivreId;

END

GO
/****** Object:  StoredProcedure [dbo].[RefLivre.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RefLivre.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM RefLivre;
END

GO
/****** Object:  StoredProcedure [dbo].[RefLivre.SelectById]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RefLivre.SelectById] @refLivreId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.RefLivre WHERE RefLivreId = @refLivreId;
END

GO
/****** Object:  StoredProcedure [dbo].[RefLivre.SelectByISBN]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RefLivre.SelectByISBN] @ISBN VARCHAR(13)
AS
DECLARE @delimiter CHAR(1),
@container VARCHAR(15);

BEGIN
SET @delimiter = '%';
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @container = @delimiter + @ISBN + @delimiter;
	SELECT * FROM dbo.RefLivre WHERE ISBN LIKE @container;
END

GO
/****** Object:  StoredProcedure [dbo].[RefLivre.SelectByTitre]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RefLivre.SelectByTitre] @Titre VARCHAR(50)
AS
DECLARE @delimiter CHAR(1),
	@container VARCHAR(52);
BEGIN
SET @delimiter = '%';
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @container = @delimiter + @Titre + @delimiter;
	SELECT * FROM dbo.RefLivre WHERE Titre LIKE @container;
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectAll]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Reservation
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectAnnuleByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectAnnuleByClientId] @pClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT result.ReservationId, result.EmpruntId, result.ActionId, result.LivreId, result.DemandeReservationId, result.CreatedAt FROM dbo.Reservation 
		INNER JOIN (
			SELECT tmp1.* FROM (SELECT re.*, em.State, em.Transition FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND dr.ClientId = @pClientId) AS tmp1
			LEFT JOIN (SELECT re.* FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND dr.ClientId = @pClientId) AS tmp2
			ON tmp2.LivreId = tmp1.LivreId AND tmp1.ActionId < tmp2.ActionId WHERE tmp2.ActionId IS NULL
		) AS result
		ON result.ReservationId = dbo.Reservation.ReservationId
		WHERE result.Transition = 'annule'
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectByDemandeReservationId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectByDemandeReservationId] @pDemandeReservationId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP(1) re.*, em.State FROM dbo.Reservation AS re LEFT JOIN dbo.Emprunt AS em 
		ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
		WHERE re.DemandeReservationId = @pDemandeReservationId
		ORDER BY ReservationId DESC
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectConvertiByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectConvertiByClientId] @pClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT result.ReservationId, result.EmpruntId, result.ActionId, result.LivreId, result.DemandeReservationId, result.CreatedAt FROM dbo.Reservation 
		INNER JOIN (
			SELECT tmp1.* FROM (SELECT re.*, em.State, em.Transition FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND dr.ClientId = @pClientId) AS tmp1
			LEFT JOIN (SELECT re.* FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND dr.ClientId = @pClientId) AS tmp2
			ON tmp2.LivreId = tmp1.LivreId AND tmp1.ActionId < tmp2.ActionId WHERE tmp2.ActionId IS NULL
		) AS result
		ON result.ReservationId = dbo.Reservation.ReservationId
		WHERE result.Transition = 'convert'
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectEnCoursNonValidByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectEnCoursNonValidByClientId] @pClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT result.ReservationId, result.EmpruntId, result.ActionId, result.LivreId, result.DemandeReservationId, result.CreatedAt FROM dbo.Reservation 
		INNER JOIN (
			SELECT tmp1.* FROM (SELECT re.*, em.State, em.Transition FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND DATEDIFF(day, re.CreatedAt, GETDATE()) > 15 AND dr.ClientId = @pClientId) AS tmp1
			LEFT JOIN (SELECT re.* FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND DATEDIFF(day, re.CreatedAt, GETDATE()) > 15 AND dr.ClientId = @pClientId) AS tmp2
			ON tmp2.LivreId = tmp1.LivreId AND tmp2.ActionId > tmp1.ActionId WHERE tmp2.ActionId IS NULL
		) AS result
		ON result.ReservationId = dbo.Reservation.ReservationId
		WHERE result.State = 'res'
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectEnCoursValidByClientId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectEnCoursValidByClientId] @pClientId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT result.ReservationId, result.EmpruntId, result.ActionId, result.LivreId, result.DemandeReservationId, result.CreatedAt FROM dbo.Reservation 
		INNER JOIN (
			SELECT tmp1.* FROM (SELECT re.*, em.State, em.Transition FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND DATEDIFF(day, re.CreatedAt, GETDATE()) <= 15 AND dr.ClientId = @pClientId) AS tmp1
			LEFT JOIN (SELECT re.* FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND DATEDIFF(day, re.CreatedAt, GETDATE()) <= 15 AND dr.ClientId = @pClientId) AS tmp2
			ON tmp2.LivreId = tmp1.LivreId AND tmp2.ActionId > tmp1.ActionId WHERE tmp2.ActionId IS NULL
		) AS result
		ON result.ReservationId = dbo.Reservation.ReservationId
		WHERE result.State = 'res'
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectEnCoursValidByInfo]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectEnCoursValidByInfo] @pInfo VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT result.ReservationId, result.EmpruntId, result.ActionId, result.LivreId, result.DemandeReservationId, result.CreatedAt FROM dbo.Reservation 
		INNER JOIN (
			SELECT tmp1.* FROM (SELECT re.*, em.State, em.Transition FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND DATEDIFF(day, re.CreatedAt, GETDATE()) <= 15 AND re.ReservationId = @pInfo) AS tmp1
			LEFT JOIN (SELECT re.* FROM dbo.Reservation AS re
				LEFT JOIN dbo.Emprunt AS em ON em.EmpruntId = re.EmpruntId AND em.LivreId = re.LivreId AND em.ActionId = re.ActionId
				LEFT JOIN dbo.DemandeReservation AS dr ON dr.DemandeReservationId = re.DemandeReservationId
				LEFT JOIN dbo.DemandeAnnulation AS da ON da.DemandeReservationId = dr.DemandeReservationId
				WHERE da.DemandeReservationId IS NULL AND DATEDIFF(day, re.CreatedAt, GETDATE()) <= 15 AND re.ReservationId = @pInfo) AS tmp2
			ON tmp2.LivreId = tmp1.LivreId AND tmp2.ActionId > tmp1.ActionId WHERE tmp2.ActionId IS NULL
		) AS result
		ON result.ReservationId = dbo.Reservation.ReservationId
		WHERE result.State = 'res'
END

GO
/****** Object:  StoredProcedure [dbo].[Reservation.SelectEnCoursValidByReservationId]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Reservation.SelectEnCoursValidByReservationId] @pDemandeReservationId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT tmp1.ReservationId,  tmp1.EmpruntId, tmp1.ActionId,  tmp1.LivreId, tmp1.DemandeReservationId, tmp1.CreatedAt FROM
		(SELECT re.*, em.State FROM dbo.Reservation AS re
			LEFT JOIN dbo.Emprunt AS em
				ON em.EmpruntId = re.EmpruntId AND em.ActionId = re.ActionId AND em.LivreId = re.LivreId
			WHERE DemandeReservationId = @pDemandeReservationId) AS tmp1
	LEFT JOIN 
		(SELECT re.*, em.State FROM dbo.Reservation AS re
		LEFT JOIN dbo.Emprunt AS em
			ON em.EmpruntId = re.EmpruntId AND em.ActionId = re.ActionId AND em.LivreId = re.LivreId
		WHERE DemandeReservationId = @pDemandeReservationId) AS tmp2
	ON tmp2.LivreId = tmp1.LivreId AND tmp2.EmpruntId > tmp1.EmpruntId
	WHERE tmp2.EmpruntId IS NULL AND tmp1.State = 'res'
END

GO
/****** Object:  StoredProcedure [dbo].[SessionManager.ByToken]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SessionManager.ByToken] @Token VARCHAR(50)
AS

DECLARE @intSessionManagerId INT;

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.

	SET NOCOUNT ON;

	SET @intSessionManagerId = (SELECT MAX(SessionId) FROM dbo.SessionManager WHERE Token = @Token AND DATEDIFF(MINUTE, CreatedAt, GETDATE()) < 30);

	BEGIN TRAN
	IF @intSessionManagerId IS NOT NULL
	BEGIN
		UPDATE dbo.SessionManager SET CreatedAt = GETDATE() WHERE SessionId = @intSessionManagerId;
		COMMIT TRAN
		SELECT * FROM dbo.SessionManager WHERE SessionId = @intSessionManagerId;
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
	END


END

GO
/****** Object:  StoredProcedure [dbo].[SessionManager.CreateSession]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SessionManager.CreateSession] @Username VARCHAR(50), @Password VARCHAR(50)
AS

DECLARE @PersonneId INT,
		@token VARCHAR(50),
		@SessionId INT,
		@intSessionManagerId INT,
		@userRole INT;

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	-- SET @PersonneId = (SELECT PersonneId FROM dbo.Personne WHERE PersonneUsername = @Username AND personnePassword = @Password);

	SELECT @PersonneId = PersonneId, @userRole = IIF(AdministrateurId IS NOT NULL, 2, 1)
		FROM dbo.Personne AS pe LEFT JOIN dbo.Administrateur AS ad 
		ON ad.AdministrateurId = pe.PersonneId
		WHERE PersonneUsername = @Username AND personnePassword = @Password;

	BEGIN TRAN

	IF @PersonneId IS NOT NULL
	BEGIN
		
		SET @intSessionManagerId = (SELECT MAX(SessionId) FROM dbo.SessionManager WHERE PersonneId = @PersonneId AND DATEDIFF(MINUTE, CreatedAt, GETDATE()) < 30);

		IF @intSessionManagerId IS NOT NULL
		BEGIN
			UPDATE dbo.SessionManager SET CreatedAt = GETDATE() WHERE SessionId = @intSessionManagerId;
			COMMIT TRAN
			SELECT * FROM SessionManager WHERE SessionId = @intSessionManagerId;
		END
		ELSE
		BEGIN
			SET @token = (select substring(replace(newid(), '-', ''), 1, 50));
			INSERT INTO dbo.SessionManager (PersonneId, Token, UserRole) VALUES (@PersonneId, @token, @userRole)
			COMMIT TRAN
		
			SET @SessionId = (SELECT SCOPE_IDENTITY());
			SELECT * FROM SessionManager WHERE SessionId = @SessionId;
		END
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
	END
END

GO
/****** Object:  Table [dbo].[Administrateur]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administrateur](
	[AdministrateurId] [int] NOT NULL,
	[PhoneNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Administrateur] PRIMARY KEY CLUSTERED 
(
	[AdministrateurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdministrateurBibliotheque]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdministrateurBibliotheque](
	[BibliethequeId] [int] NOT NULL,
	[AdministrateurId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_AdministrateurBibliotheque] PRIMARY KEY CLUSTERED 
(
	[BibliethequeId] ASC,
	[AdministrateurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bibliotheque]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bibliotheque](
	[BibliothequeId] [int] IDENTITY(1,1) NOT NULL,
	[BibliothequeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Bibliotheque] PRIMARY KEY CLUSTERED 
(
	[BibliothequeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Client]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientId] [int] NOT NULL,
	[BibliothequeId] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DemandeAnnulation]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DemandeAnnulation](
	[DemandeReservationId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[Raison] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DemandeAnnulation] PRIMARY KEY CLUSTERED 
(
	[DemandeReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DemandeReservation]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DemandeReservation](
	[DemandeReservationId] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[RefLivreId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_DemandeReservation] PRIMARY KEY CLUSTERED 
(
	[DemandeReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Emprunt]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Emprunt](
	[EmpruntId] [int] IDENTITY(1,1) NOT NULL,
	[LivreId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Transition] [varchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[AdministrateurId] [int] NULL,
	[ClientId] [int] NULL,
 CONSTRAINT [PK_Emprunt] PRIMARY KEY CLUSTERED 
(
	[EmpruntId] ASC,
	[LivreId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Emprunt_Action_Livre] UNIQUE NONCLUSTERED 
(
	[ActionId] ASC,
	[LivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Emprunt_Emprunt_Action_Livre] UNIQUE NONCLUSTERED 
(
	[EmpruntId] ASC,
	[ActionId] ASC,
	[LivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[EmpruntId] [int] NOT NULL,
	[LivreId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[AdministrateurId] [int] NOT NULL,
	[Montant] [numeric](5, 2) NOT NULL,
	[Cout] [numeric](5, 2) NOT NULL,
	[Amende] [numeric](5, 2) NOT NULL,
	[DebutDate] [datetime] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC,
	[EmpruntId] ASC,
	[LivreId] ASC,
	[ActionId] ASC,
	[ClientId] ASC,
	[AdministrateurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Items] UNIQUE NONCLUSTERED 
(
	[EmpruntId] ASC,
	[LivreId] ASC,
	[ActionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Livre]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Livre](
	[LivreId] [int] IDENTITY(1,1) NOT NULL,
	[RefLivreId] [int] NOT NULL,
	[BibliothequeId] [int] NOT NULL,
	[LivreStatusId] [int] NOT NULL,
	[InternalReference] [varchar](50) NOT NULL,
	[CreatedAt] [date] NOT NULL,
 CONSTRAINT [PK_Livre_1] PRIMARY KEY CLUSTERED 
(
	[LivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Livre_InternalReference] UNIQUE NONCLUSTERED 
(
	[InternalReference] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LivreActions]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LivreActions](
	[ActionId] [int] NOT NULL,
	[LivreId] [int] NOT NULL,
	[ActionType] [varchar](50) NOT NULL,
	[CurrentState] [int] NULL,
	[State] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LivreActions_1] PRIMARY KEY CLUSTERED 
(
	[ActionId] ASC,
	[LivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LivreStatus]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LivreStatus](
	[LivreStatusId] [int] IDENTITY(1,1) NOT NULL,
	[LivreStatusValue] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LivreStatus] PRIMARY KEY CLUSTERED 
(
	[LivreStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Personne]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personne](
	[PersonneId] [int] IDENTITY(1,1) NOT NULL,
	[PersonneMatricule] [varchar](50) NOT NULL,
	[PersonneFirstName] [varchar](50) NOT NULL,
	[PersonneLastname] [varchar](50) NOT NULL,
	[PersonneUsername] [varchar](50) NOT NULL,
	[PersonnePassword] [varchar](50) NOT NULL,
	[PersonneEmail] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Personne] PRIMARY KEY CLUSTERED 
(
	[PersonneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RefLivre]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RefLivre](
	[RefLivreId] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [varchar](13) NOT NULL,
	[Titre] [varchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Auteur] [varchar](50) NOT NULL,
	[Langue] [varchar](50) NULL,
	[Editeur] [varchar](50) NULL,
	[Published] [date] NULL,
	[imageUrl] [varchar](250) NULL,
 CONSTRAINT [PK_Livre] PRIMARY KEY CLUSTERED 
(
	[RefLivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[ReservationId] [int] IDENTITY(1,1) NOT NULL,
	[EmpruntId] [int] NOT NULL,
	[ActionId] [int] NOT NULL,
	[LivreId] [int] NOT NULL,
	[DemandeReservationId] [int] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Reservation] UNIQUE NONCLUSTERED 
(
	[EmpruntId] ASC,
	[ActionId] ASC,
	[LivreId] ASC,
	[DemandeReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Reservation_Emprunt_Action_Livre] UNIQUE NONCLUSTERED 
(
	[EmpruntId] ASC,
	[ActionId] ASC,
	[LivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SessionManager]    Script Date: 15/07/2014 13:28:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SessionManager](
	[SessionId] [int] IDENTITY(1,1) NOT NULL,
	[PersonneId] [int] NOT NULL,
	[Token] [varchar](50) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UserRole] [int] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Session] UNIQUE NONCLUSTERED 
(
	[Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Index [IX_DemandeReservation_Client]    Script Date: 15/07/2014 13:28:49 ******/
CREATE NONCLUSTERED INDEX [IX_DemandeReservation_Client] ON [dbo].[DemandeReservation]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DemandeReservation_RefLivre]    Script Date: 15/07/2014 13:28:49 ******/
CREATE NONCLUSTERED INDEX [IX_DemandeReservation_RefLivre] ON [dbo].[DemandeReservation]
(
	[RefLivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Emprunt]    Script Date: 15/07/2014 13:28:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Emprunt] ON [dbo].[Emprunt]
(
	[EmpruntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livre_Bibliotheque]    Script Date: 15/07/2014 13:28:49 ******/
CREATE NONCLUSTERED INDEX [IX_Livre_Bibliotheque] ON [dbo].[Livre]
(
	[BibliothequeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livre_LivreStatus]    Script Date: 15/07/2014 13:28:49 ******/
CREATE NONCLUSTERED INDEX [IX_Livre_LivreStatus] ON [dbo].[Livre]
(
	[LivreStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Livre_RefLivre]    Script Date: 15/07/2014 13:28:49 ******/
CREATE NONCLUSTERED INDEX [IX_Livre_RefLivre] ON [dbo].[Livre]
(
	[RefLivreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_LivreStatus]    Script Date: 15/07/2014 13:28:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_LivreStatus] ON [dbo].[LivreStatus]
(
	[LivreStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Personne_Email]    Script Date: 15/07/2014 13:28:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Personne_Email] ON [dbo].[Personne]
(
	[PersonneEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Personne_Matricule]    Script Date: 15/07/2014 13:28:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Personne_Matricule] ON [dbo].[Personne]
(
	[PersonneMatricule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Personne_Username]    Script Date: 15/07/2014 13:28:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Personne_Username] ON [dbo].[Personne]
(
	[PersonneUsername] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdministrateurBibliotheque] ADD  CONSTRAINT [DF_AdministrateurBibliotheque_timestamp]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[DemandeAnnulation] ADD  CONSTRAINT [DF_DemandeAnnulation_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[DemandeReservation] ADD  CONSTRAINT [DF_DemandeReservation_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Emprunt] ADD  CONSTRAINT [DF_LivreState_State]  DEFAULT ('reg') FOR [State]
GO
ALTER TABLE [dbo].[Emprunt] ADD  CONSTRAINT [DF_LivreState_Transition]  DEFAULT ('initial') FOR [Transition]
GO
ALTER TABLE [dbo].[Emprunt] ADD  CONSTRAINT [DF_LivreState_Timestamp]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Livre] ADD  CONSTRAINT [DF_Livre_LivreStatusId]  DEFAULT ((1)) FOR [LivreStatusId]
GO
ALTER TABLE [dbo].[Livre] ADD  CONSTRAINT [DF_Livre_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[LivreActions] ADD  CONSTRAINT [DF_LivreActions_ActionType]  DEFAULT ('new') FOR [ActionType]
GO
ALTER TABLE [dbo].[LivreActions] ADD  CONSTRAINT [DF_LivreActions_State]  DEFAULT ('reg') FOR [State]
GO
ALTER TABLE [dbo].[Reservation] ADD  CONSTRAINT [DF_Reservation_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[SessionManager] ADD  CONSTRAINT [DF_Session_CreateAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[SessionManager] ADD  CONSTRAINT [DF_SessionManager_Role]  DEFAULT ((0)) FOR [UserRole]
GO
ALTER TABLE [dbo].[Administrateur]  WITH CHECK ADD  CONSTRAINT [FK_Administrateur_Personne] FOREIGN KEY([AdministrateurId])
REFERENCES [dbo].[Personne] ([PersonneId])
GO
ALTER TABLE [dbo].[Administrateur] CHECK CONSTRAINT [FK_Administrateur_Personne]
GO
ALTER TABLE [dbo].[AdministrateurBibliotheque]  WITH CHECK ADD  CONSTRAINT [FK_AdministrateurBibliotheque_Administrateur] FOREIGN KEY([AdministrateurId])
REFERENCES [dbo].[Administrateur] ([AdministrateurId])
GO
ALTER TABLE [dbo].[AdministrateurBibliotheque] CHECK CONSTRAINT [FK_AdministrateurBibliotheque_Administrateur]
GO
ALTER TABLE [dbo].[AdministrateurBibliotheque]  WITH CHECK ADD  CONSTRAINT [FK_AdministrateurBibliotheque_Bibliotheque] FOREIGN KEY([BibliethequeId])
REFERENCES [dbo].[Bibliotheque] ([BibliothequeId])
GO
ALTER TABLE [dbo].[AdministrateurBibliotheque] CHECK CONSTRAINT [FK_AdministrateurBibliotheque_Bibliotheque]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Bibliotheque] FOREIGN KEY([BibliothequeId])
REFERENCES [dbo].[Bibliotheque] ([BibliothequeId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Bibliotheque]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Personne] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Personne] ([PersonneId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Personne]
GO
ALTER TABLE [dbo].[DemandeAnnulation]  WITH CHECK ADD  CONSTRAINT [FK_DemandeAnnulation_DemandeReservation] FOREIGN KEY([DemandeReservationId])
REFERENCES [dbo].[DemandeReservation] ([DemandeReservationId])
GO
ALTER TABLE [dbo].[DemandeAnnulation] CHECK CONSTRAINT [FK_DemandeAnnulation_DemandeReservation]
GO
ALTER TABLE [dbo].[DemandeReservation]  WITH CHECK ADD  CONSTRAINT [FK_DemandeReservation_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[DemandeReservation] CHECK CONSTRAINT [FK_DemandeReservation_Client]
GO
ALTER TABLE [dbo].[DemandeReservation]  WITH CHECK ADD  CONSTRAINT [FK_DemandeReservation_RefLivre] FOREIGN KEY([RefLivreId])
REFERENCES [dbo].[RefLivre] ([RefLivreId])
GO
ALTER TABLE [dbo].[DemandeReservation] CHECK CONSTRAINT [FK_DemandeReservation_RefLivre]
GO
ALTER TABLE [dbo].[Emprunt]  WITH CHECK ADD  CONSTRAINT [FK_Emprunt_Administrateur] FOREIGN KEY([AdministrateurId])
REFERENCES [dbo].[Administrateur] ([AdministrateurId])
GO
ALTER TABLE [dbo].[Emprunt] CHECK CONSTRAINT [FK_Emprunt_Administrateur]
GO
ALTER TABLE [dbo].[Emprunt]  WITH CHECK ADD  CONSTRAINT [FK_Emprunt_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[Emprunt] CHECK CONSTRAINT [FK_Emprunt_Client]
GO
ALTER TABLE [dbo].[Emprunt]  WITH CHECK ADD  CONSTRAINT [FK_Emprunt_LivreActions] FOREIGN KEY([ActionId], [LivreId])
REFERENCES [dbo].[LivreActions] ([ActionId], [LivreId])
GO
ALTER TABLE [dbo].[Emprunt] CHECK CONSTRAINT [FK_Emprunt_LivreActions]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Administrateur] FOREIGN KEY([AdministrateurId])
REFERENCES [dbo].[Administrateur] ([AdministrateurId])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Administrateur]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Client] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([ClientId])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Client]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Emprunt] FOREIGN KEY([EmpruntId], [LivreId], [ActionId])
REFERENCES [dbo].[Emprunt] ([EmpruntId], [LivreId], [ActionId])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Emprunt]
GO
ALTER TABLE [dbo].[Livre]  WITH CHECK ADD  CONSTRAINT [FK_Livre_Bibliotheque] FOREIGN KEY([BibliothequeId])
REFERENCES [dbo].[Bibliotheque] ([BibliothequeId])
GO
ALTER TABLE [dbo].[Livre] CHECK CONSTRAINT [FK_Livre_Bibliotheque]
GO
ALTER TABLE [dbo].[Livre]  WITH CHECK ADD  CONSTRAINT [FK_Livre_LivreStatus] FOREIGN KEY([LivreStatusId])
REFERENCES [dbo].[LivreStatus] ([LivreStatusId])
GO
ALTER TABLE [dbo].[Livre] CHECK CONSTRAINT [FK_Livre_LivreStatus]
GO
ALTER TABLE [dbo].[Livre]  WITH CHECK ADD  CONSTRAINT [FK_Livre_RefLivre] FOREIGN KEY([RefLivreId])
REFERENCES [dbo].[RefLivre] ([RefLivreId])
GO
ALTER TABLE [dbo].[Livre] CHECK CONSTRAINT [FK_Livre_RefLivre]
GO
ALTER TABLE [dbo].[LivreActions]  WITH CHECK ADD  CONSTRAINT [FK_LivreActions_Livre] FOREIGN KEY([LivreId])
REFERENCES [dbo].[Livre] ([LivreId])
GO
ALTER TABLE [dbo].[LivreActions] CHECK CONSTRAINT [FK_LivreActions_Livre]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_DemandeReservation] FOREIGN KEY([DemandeReservationId])
REFERENCES [dbo].[DemandeReservation] ([DemandeReservationId])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_DemandeReservation]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Emprunt] FOREIGN KEY([EmpruntId], [LivreId], [ActionId])
REFERENCES [dbo].[Emprunt] ([EmpruntId], [LivreId], [ActionId])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Emprunt]
GO
ALTER TABLE [dbo].[SessionManager]  WITH CHECK ADD  CONSTRAINT [FK_Session_Personne] FOREIGN KEY([PersonneId])
REFERENCES [dbo].[Personne] ([PersonneId])
GO
ALTER TABLE [dbo].[SessionManager] CHECK CONSTRAINT [FK_Session_Personne]
GO
USE [master]
GO
ALTER DATABASE [EphecSample] SET  READ_WRITE 
GO
