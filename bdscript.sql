USE [master]
GO
/****** Object:  Database [DBLanche]    Script Date: 21/05/2020 16:01:02 ******/
CREATE DATABASE [DBLanche]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBLanche', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DBLanche.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBLanche_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\DBLanche_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DBLanche] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBLanche].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBLanche] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBLanche] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBLanche] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBLanche] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBLanche] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBLanche] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBLanche] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBLanche] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBLanche] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBLanche] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBLanche] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBLanche] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBLanche] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBLanche] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBLanche] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBLanche] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBLanche] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBLanche] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBLanche] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBLanche] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBLanche] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBLanche] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBLanche] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBLanche] SET  MULTI_USER 
GO
ALTER DATABASE [DBLanche] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBLanche] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBLanche] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBLanche] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBLanche] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBLanche] SET QUERY_STORE = OFF
GO
USE [DBLanche]
GO
/****** Object:  Table [dbo].[Ingredientes]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Preco] [decimal](5, 2) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_Ingrediente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lanches]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lanches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NULL,
	[Preco] [decimal](5, 2) NULL,
	[DataCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_Lanche] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LanchesIngredientes]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LanchesIngredientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LancheId] [int] NULL,
	[IngredienteId] [int] NULL,
	[QtdIngrediente] [int] NULL,
	[DataCadastro] [datetime] NULL,
 CONSTRAINT [PK_LanchesIngredientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocoes]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](500) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
 CONSTRAINT [PK_Promocao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Ingredientes_ById]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Ingredientes_ById]
@id int
AS
  Select Id, Nome, Preco, DataCadastro
  FROM Ingredientes
  WHERE Id = @id
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_Ingredientes_ListAll]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Ingredientes_ListAll]
AS
  SELECT Id, Nome, Preco, DataCadastro
  FROM Ingredientes
  ORDER BY Id
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_Lanches_ById]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lanches_ById]
@id int
AS
  Select Id, Nome, Preco, DataCadastro
  FROM Lanches
  WHERE Id = @id
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_Lanches_ListAll]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Lanches_ListAll]
AS
  SELECT Id, Nome, Preco, DataCadastro
  FROM Lanches
  ORDER BY Id
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_Promocoes_ById]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Promocoes_ById]
@id int
AS
  Select Id, Nome, Descricao, DataCadastro
  FROM Promocoes
  WHERE Id = @id
RETURN
GO
/****** Object:  StoredProcedure [dbo].[sp_Promocoes_ListAll]    Script Date: 21/05/2020 16:01:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Promocoes_ListAll]
AS
  SELECT Id, Nome, Descricao, DataCadastro
  FROM Promocoes
  ORDER BY Id
RETURN
GO
USE [master]
GO
ALTER DATABASE [DBLanche] SET  READ_WRITE 
GO
