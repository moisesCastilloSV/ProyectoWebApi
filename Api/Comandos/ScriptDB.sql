USE [Api]
GO
ALTER TABLE [dbo].[PeliculaActores] DROP CONSTRAINT [FK__PeliculaA__Pelic__5165187F]
GO
ALTER TABLE [dbo].[PeliculaActores] DROP CONSTRAINT [FK__PeliculaA__Actor__5070F446]
GO
/****** Object:  Table [dbo].[UsuarioSesion]    Script Date: 11/11/2021 11:49:51 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsuarioSesion]') AND type in (N'U'))
DROP TABLE [dbo].[UsuarioSesion]
GO
/****** Object:  Table [dbo].[PeliculaActores]    Script Date: 11/11/2021 11:49:51 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PeliculaActores]') AND type in (N'U'))
DROP TABLE [dbo].[PeliculaActores]
GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 11/11/2021 11:49:51 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pelicula]') AND type in (N'U'))
DROP TABLE [dbo].[Pelicula]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 11/11/2021 11:49:51 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genero]') AND type in (N'U'))
DROP TABLE [dbo].[Genero]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 11/11/2021 11:49:51 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Actor]') AND type in (N'U'))
DROP TABLE [dbo].[Actor]
GO
USE [master]
GO
/****** Object:  Database [Api]    Script Date: 11/11/2021 11:49:51 AM ******/
DROP DATABASE [Api]
GO
/****** Object:  Database [Api]    Script Date: 11/11/2021 11:49:51 AM ******/
CREATE DATABASE [Api]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Api', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Api.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Api_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Api_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Api] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Api].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Api] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Api] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Api] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Api] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Api] SET ARITHABORT OFF 
GO
ALTER DATABASE [Api] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Api] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Api] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Api] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Api] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Api] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Api] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Api] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Api] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Api] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Api] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Api] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Api] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Api] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Api] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Api] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Api] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Api] SET RECOVERY FULL 
GO
ALTER DATABASE [Api] SET  MULTI_USER 
GO
ALTER DATABASE [Api] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Api] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Api] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Api] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Api] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Api] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Api', N'ON'
GO
ALTER DATABASE [Api] SET QUERY_STORE = OFF
GO
USE [Api]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 11/11/2021 11:49:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
	[Foto] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 11/11/2021 11:49:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pelicula]    Script Date: 11/11/2021 11:49:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pelicula](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](255) NOT NULL,
	[EnCines] [bit] NOT NULL,
	[FechaEstreno] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeliculaActores]    Script Date: 11/11/2021 11:49:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeliculaActores](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ActorId] [int] NULL,
	[PeliculaId] [int] NULL,
	[Personaje] [varchar](100) NOT NULL,
	[Orden] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioSesion]    Script Date: 11/11/2021 11:49:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioSesion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actor] ON 
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (1, N'Actualizacion path', CAST(N'1955-05-22T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (2, N'Moises', CAST(N'1996-05-22T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (3, N'Actor-3', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (4, N'Actor-4', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (5, N'Actor-5', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (6, N'Actor-6', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (7, N'Actor-7', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (8, N'Actor-8', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (9, N'Actor-9', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (10, N'Actor-10', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (11, N'Actor-11', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (12, N'Actor-12', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (13, N'Actor-13', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (14, N'Actor-14', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (15, N'Actor-15', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (16, N'Actor-16', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (17, N'Actor-17', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (18, N'Actor-18', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (19, N'Actor-19', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
INSERT [dbo].[Actor] ([ID], [Nombre], [FechaNacimiento], [Foto]) VALUES (20, N'Actor-20', CAST(N'2021-11-09T23:17:18.190' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Actor] OFF
GO
SET IDENTITY_INSERT [dbo].[Genero] ON 
GO
INSERT [dbo].[Genero] ([ID], [Nombre]) VALUES (1, N'Accion')
GO
INSERT [dbo].[Genero] ([ID], [Nombre]) VALUES (3, N'Comedia')
GO
INSERT [dbo].[Genero] ([ID], [Nombre]) VALUES (4, N'Romence')
GO
SET IDENTITY_INSERT [dbo].[Genero] OFF
GO
SET IDENTITY_INSERT [dbo].[Pelicula] ON 
GO
INSERT [dbo].[Pelicula] ([ID], [Titulo], [EnCines], [FechaEstreno]) VALUES (1, N'Capitán América: El primer vengador', 1, CAST(N'2021-11-10T23:54:05.760' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Pelicula] OFF
GO
SET IDENTITY_INSERT [dbo].[PeliculaActores] ON 
GO
INSERT [dbo].[PeliculaActores] ([ID], [ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (1, 1, 1, N'Capitan', 0)
GO
INSERT [dbo].[PeliculaActores] ([ID], [ActorId], [PeliculaId], [Personaje], [Orden]) VALUES (2, 2, 1, N'Nick Fury', 1)
GO
SET IDENTITY_INSERT [dbo].[PeliculaActores] OFF
GO
ALTER TABLE [dbo].[PeliculaActores]  WITH CHECK ADD FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([ID])
GO
ALTER TABLE [dbo].[PeliculaActores]  WITH CHECK ADD FOREIGN KEY([PeliculaId])
REFERENCES [dbo].[Pelicula] ([ID])
GO
USE [master]
GO
ALTER DATABASE [Api] SET  READ_WRITE 
GO
