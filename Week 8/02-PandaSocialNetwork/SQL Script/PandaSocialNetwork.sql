USE [master]
GO
/****** Object:  Database [PandaSocialNetowrk]    Script Date: 30.1.2016 г. 20:58:18 ******/
CREATE DATABASE [PandaSocialNetowrk]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PandaSocialNetowrk', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PandaSocialNetowrk.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PandaSocialNetowrk_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\PandaSocialNetowrk_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PandaSocialNetowrk] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PandaSocialNetowrk].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PandaSocialNetowrk] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET ARITHABORT OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PandaSocialNetowrk] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PandaSocialNetowrk] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PandaSocialNetowrk] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PandaSocialNetowrk] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PandaSocialNetowrk] SET  MULTI_USER 
GO
ALTER DATABASE [PandaSocialNetowrk] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PandaSocialNetowrk] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PandaSocialNetowrk] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PandaSocialNetowrk] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PandaSocialNetowrk] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PandaSocialNetowrk]
GO
/****** Object:  Table [dbo].[Panda]    Script Date: 30.1.2016 г. 20:58:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Panda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
 CONSTRAINT [PK_Panda] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PandaFriends]    Script Date: 30.1.2016 г. 20:58:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PandaFriends](
	[Panda_Id] [int] NOT NULL,
	[Friend_Id] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Panda] ON 

INSERT [dbo].[Panda] ([Id], [Name], [Email], [Gender]) VALUES (1, N'Ivo', N'ivo@pandamail.com', 0)
INSERT [dbo].[Panda] ([Id], [Name], [Email], [Gender]) VALUES (2, N'Rado', N'rado@pandamail.com', 0)
INSERT [dbo].[Panda] ([Id], [Name], [Email], [Gender]) VALUES (3, N'Tony', N'tony@pandamail.com', 1)
INSERT [dbo].[Panda] ([Id], [Name], [Email], [Gender]) VALUES (4, N'Tonyz', N'tony@pandamail.com', 1)
SET IDENTITY_INSERT [dbo].[Panda] OFF
INSERT [dbo].[PandaFriends] ([Panda_Id], [Friend_Id]) VALUES (1, 2)
INSERT [dbo].[PandaFriends] ([Panda_Id], [Friend_Id]) VALUES (2, 1)
INSERT [dbo].[PandaFriends] ([Panda_Id], [Friend_Id]) VALUES (2, 3)
INSERT [dbo].[PandaFriends] ([Panda_Id], [Friend_Id]) VALUES (3, 2)
ALTER TABLE [dbo].[PandaFriends]  WITH CHECK ADD  CONSTRAINT [FK_PandaFriends_Panda] FOREIGN KEY([Panda_Id])
REFERENCES [dbo].[Panda] ([Id])
GO
ALTER TABLE [dbo].[PandaFriends] CHECK CONSTRAINT [FK_PandaFriends_Panda]
GO
ALTER TABLE [dbo].[PandaFriends]  WITH CHECK ADD  CONSTRAINT [FK_PandaFriends_Panda1] FOREIGN KEY([Friend_Id])
REFERENCES [dbo].[Panda] ([Id])
GO
ALTER TABLE [dbo].[PandaFriends] CHECK CONSTRAINT [FK_PandaFriends_Panda1]
GO
USE [master]
GO
ALTER DATABASE [PandaSocialNetowrk] SET  READ_WRITE 
GO
