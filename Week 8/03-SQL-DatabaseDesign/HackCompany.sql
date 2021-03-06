USE [master]
GO
/****** Object:  Database [HackCompany]    Script Date: 30.1.2016 г. 20:59:00 ******/
CREATE DATABASE [HackCompany]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HackCompany', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HackCompany.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HackCompany_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\HackCompany_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HackCompany] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HackCompany].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HackCompany] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HackCompany] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HackCompany] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HackCompany] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HackCompany] SET ARITHABORT OFF 
GO
ALTER DATABASE [HackCompany] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HackCompany] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HackCompany] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HackCompany] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HackCompany] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HackCompany] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HackCompany] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HackCompany] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HackCompany] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HackCompany] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HackCompany] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HackCompany] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HackCompany] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HackCompany] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HackCompany] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HackCompany] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HackCompany] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HackCompany] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HackCompany] SET  MULTI_USER 
GO
ALTER DATABASE [HackCompany] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HackCompany] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HackCompany] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HackCompany] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HackCompany] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HackCompany]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 30.1.2016 г. 20:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [char](3) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 30.1.2016 г. 20:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Adress] [nvarchar](50) NOT NULL,
	[Discount] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 30.1.2016 г. 20:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 30.1.2016 г. 20:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [date] NOT NULL,
	[Manager_Id] [int] NULL,
	[Department_Id] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 30.1.2016 г. 20:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Customer_Id] [int] NOT NULL,
	[TotalPrice] [money] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrdersProducts]    Script Date: 30.1.2016 г. 20:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersProducts](
	[Order_Id] [int] NOT NULL,
	[Product_Id] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 30.1.2016 г. 20:59:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[Category_Id] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Code]) VALUES (1, N'Books', N'BKS')
INSERT [dbo].[Category] ([Id], [Name], [Code]) VALUES (2, N'Music', N'MSC')
INSERT [dbo].[Category] ([Id], [Name], [Code]) VALUES (3, N'Hardware', N'HDW')
INSERT [dbo].[Category] ([Id], [Name], [Code]) VALUES (4, N'Software', N'SFW')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Email], [Adress], [Discount]) VALUES (1, N'Peshkata', N'peshkata@gmail.com', N'Sofia, Bulgaria', 20)
INSERT [dbo].[Customer] ([Id], [Name], [Email], [Adress], [Discount]) VALUES (2, N'Ivanka', N'ivanova@gmail.com', N'Varna, Bulgaria', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [Email], [Adress], [Discount]) VALUES (3, N'Petra', N'petrova@gmail.com', N'Burgas, Bulgaria', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [Email], [Adress], [Discount]) VALUES (4, N'Dancho', N'dancho@gmail.com', N'Plovdiv, Bulgaria', 30)
INSERT [dbo].[Customer] ([Id], [Name], [Email], [Adress], [Discount]) VALUES (5, N'Kati', N'kati@gmail.com', N'Veliko Turnovo, Bulgaria', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Name]) VALUES (1, N'Sales')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (2, N'Production')
INSERT [dbo].[Department] ([Id], [Name]) VALUES (3, N'Financial')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (1, N'Big Boss', N'bigboss@gmail.com', CAST(N'1993-01-27' AS Date), NULL, NULL)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (2, N'Pesho Peshev', N'', CAST(N'2001-01-29' AS Date), 1, 1)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (3, N'Pesho', N'peshev@gmail.com', CAST(N'1967-01-27' AS Date), 2, 1)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (4, N'Gosho', N'goshev@gmail.com', CAST(N'1977-01-27' AS Date), 2, 1)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (5, N'Spas', N'spas@gmail.com', CAST(N'1987-01-27' AS Date), 2, 1)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (6, N'Iskren', N'iskrenov@gmai.com', CAST(N'1997-01-27' AS Date), 2, 1)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (7, N'Mitko', N'mitaka@gmail.com', CAST(N'1993-01-27' AS Date), 1, 2)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (8, N'Stamat', N'stamat@gmail.com', CAST(N'1981-01-27' AS Date), 7, 2)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (9, N'Stoyan', N'stoyan@gmail.com', CAST(N'1976-01-27' AS Date), 7, 2)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (10, N'Ivanka', N'ivanka@gmail.com', CAST(N'1991-01-27' AS Date), 7, 2)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (11, N'Mariika', N'mariika@gmail.com', CAST(N'1992-01-27' AS Date), 7, 2)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (12, N'Plamen', N'plamen@gmail.com', CAST(N'1986-01-27' AS Date), 1, 3)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (13, N'Plamena', N'plamena@gmail.com', CAST(N'1879-01-27' AS Date), 12, 3)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (14, N'Yordan', N'yordan@gmail.com', CAST(N'1871-01-27' AS Date), 12, 3)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (15, N'Stefka', N'stefka@gmail.com', CAST(N'1873-01-27' AS Date), 12, 3)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (16, N'Gospodin', N'gospodin@gmail.com', CAST(N'1993-01-27' AS Date), 12, 3)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (17, N'Mimi', N'mimi@gmail.com', CAST(N'1994-01-27' AS Date), 12, 3)
INSERT [dbo].[Employee] ([Id], [Name], [Email], [DateOfBirth], [Manager_Id], [Department_Id]) VALUES (18, N'Gosho Goshev', N'peshev@abv.bg', CAST(N'2001-01-29' AS Date), 2, 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Date], [Customer_Id], [TotalPrice]) VALUES (1, CAST(N'2016-01-27' AS Date), 1, 500.0000)
INSERT [dbo].[Order] ([Id], [Date], [Customer_Id], [TotalPrice]) VALUES (2, CAST(N'2016-01-27' AS Date), 2, 100.0000)
INSERT [dbo].[Order] ([Id], [Date], [Customer_Id], [TotalPrice]) VALUES (3, CAST(N'2016-01-27' AS Date), 4, 1000.0000)
INSERT [dbo].[Order] ([Id], [Date], [Customer_Id], [TotalPrice]) VALUES (4, CAST(N'2016-01-27' AS Date), 3, 150.0000)
INSERT [dbo].[Order] ([Id], [Date], [Customer_Id], [TotalPrice]) VALUES (5, CAST(N'2016-01-27' AS Date), 5, 125.0000)
SET IDENTITY_INSERT [dbo].[Order] OFF
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (1, 1)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (1, 2)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (1, 3)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (2, 2)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (2, 3)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (3, 8)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (3, 9)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (4, 4)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (4, 5)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (5, 10)
INSERT [dbo].[OrdersProducts] ([Order_Id], [Product_Id]) VALUES (5, 11)
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (1, N'Harry Potter 1', 50.0000, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (2, N'Harry Potter 2', 60.0000, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (3, N'Harry Potter 3', 70.0000, 1)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (4, N'EMINEM', 100.0000, 2)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (5, N'Slavi Trifonov Best Songs', 150.0000, 2)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (8, N'NVIDIA 10GB Video Card', 1000.0000, 3)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (9, N'Intel i10 20-Core CPU', 5000.0000, 3)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (10, N'Windows 11', 500.0000, 4)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Category_Id]) VALUES (11, N'Visual Studio', 10000.0000, 4)
SET IDENTITY_INSERT [dbo].[Product] OFF
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([Manager_Id])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrdersProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Order] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrdersProducts] CHECK CONSTRAINT [FK_OrdersProducts_Order]
GO
ALTER TABLE [dbo].[OrdersProducts]  WITH CHECK ADD  CONSTRAINT [FK_OrdersProducts_Product] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrdersProducts] CHECK CONSTRAINT [FK_OrdersProducts_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category_Id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [HackCompany] SET  READ_WRITE 
GO
