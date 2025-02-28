USE [NewShop]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
ALTER TABLE [dbo].[Products] DROP CONSTRAINT IF EXISTS [FK_Products_Providers]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
ALTER TABLE [dbo].[Products] DROP CONSTRAINT IF EXISTS [FK_dbo.Products_dbo.Categories_CategoryId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Orders]') AND type in (N'U'))
ALTER TABLE [dbo].[Orders] DROP CONSTRAINT IF EXISTS [FK_dbo.Orders_dbo.Customers_CustomerId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT IF EXISTS [FK_dbo.OrderDetails_dbo.Products_ProductId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetails]') AND type in (N'U'))
ALTER TABLE [dbo].[OrderDetails] DROP CONSTRAINT IF EXISTS [FK_dbo.OrderDetails_dbo.Orders_OrderId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comments]') AND type in (N'U'))
ALTER TABLE [dbo].[Comments] DROP CONSTRAINT IF EXISTS [FK_Comments_Products]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Providers]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Products]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Orders]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[OrderDetails]
GO
/****** Object:  Table [dbo].[NavItems]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[NavItems]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Customers]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Comments]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP TABLE IF EXISTS [dbo].[Categories]
GO
USE [master]
GO
/****** Object:  Database [NewShop]    Script Date: 12/9/2023 11:57:55 AM ******/
DROP DATABASE IF EXISTS [NewShop]
GO
/****** Object:  Database [NewShop]    Script Date: 12/9/2023 11:57:55 AM ******/
CREATE DATABASE [NewShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OnlineShop', FILENAME = N'D:\NewShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OnlineShop_log', FILENAME = N'D:\NewShop_log.LDF' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NewShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NewShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NewShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NewShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NewShop] SET  MULTI_USER 
GO
ALTER DATABASE [NewShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NewShop] SET QUERY_STORE = OFF
GO
USE [NewShop]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NameVN] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComContent] [nvarchar](200) NOT NULL,
	[CreateAt] [datetime] NULL,
	[ProductId] [nvarchar](10) NOT NULL,
	[Rate] [int] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RePassword] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NavItems]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NavItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NavName] [nvarchar](50) NOT NULL,
	[NavNameVN] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.NavItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductId] [nvarchar](10) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Amount] [float] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Available] [bit] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ProviderId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 12/9/2023 11:57:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[Id] [int] NOT NULL,
	[ProviderName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [NameVN]) VALUES (1, N'Food', N'Thực phẩm')
INSERT [dbo].[Categories] ([Id], [Name], [NameVN]) VALUES (2, N'Drink', N'Đồ uống')
INSERT [dbo].[Categories] ([Id], [Name], [NameVN]) VALUES (3, N'Assessories', N'Đồ gia dụng')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Fullname], [Email], [Password], [RePassword]) VALUES (1, N'James Bond', N'kh1@gmail.com', N'123', N'123')
INSERT [dbo].[Customers] ([Id], [Fullname], [Email], [Password], [RePassword]) VALUES (2, N'Tony Jaa', N'tj@gmail.com', N'456', N'456')
INSERT [dbo].[Customers] ([Id], [Fullname], [Email], [Password], [RePassword]) VALUES (3, N'Bruce Lee', N'bl@gmail.com', N'321', N'321')
INSERT [dbo].[Customers] ([Id], [Fullname], [Email], [Password], [RePassword]) VALUES (4, N'Jackie Chan', N'jc@gmail.com', N'654', N'654')
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[NavItems] ON 

INSERT [dbo].[NavItems] ([Id], [NavName], [NavNameVN]) VALUES (1, N'Home', N'Trang chủ')
INSERT [dbo].[NavItems] ([Id], [NavName], [NavNameVN]) VALUES (2, N'Offers', N'Hàng hóa')
INSERT [dbo].[NavItems] ([Id], [NavName], [NavNameVN]) VALUES (4, N'Help', N'Trợ giúp')
INSERT [dbo].[NavItems] ([Id], [NavName], [NavNameVN]) VALUES (5, N'Contact', N'Liên hệ')
SET IDENTITY_INSERT [dbo].[NavItems] OFF
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (1, 1, N'F01', 1000, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (2, 1, N'F04', 1000, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (3, 2, N'F01', 1000, 1)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [ProductId], [UnitPrice], [Quantity]) VALUES (4, 2, N'F03', 500, 1)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [CustomerId], [OrderDate], [Address], [Amount], [Description]) VALUES (1, 1, CAST(N'2019-03-30T00:00:00.000' AS DateTime), N'London', 1000, NULL)
INSERT [dbo].[Orders] ([Id], [CustomerId], [OrderDate], [Address], [Amount], [Description]) VALUES (2, 2, CAST(N'2019-03-30T00:00:00.000' AS DateTime), N'Paris', 1500, NULL)
SET IDENTITY_INSERT [dbo].[Orders] OFF
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'A01', N'Nồi lẩu', 500, N'hh1.png', 0, 3, NULL, 1)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'A02', N'Bộ nồi', 400, N'hh2.png', 1, 3, NULL, 1)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'A03', N'Khuôn bánh', 1200, N'hh3.png', 1, 3, NULL, 2)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'A04', N'Bình nước', 500, N'hh4.png', 0, 3, NULL, 2)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'A05', N'Nồi inox', 400, N'hh5.png', 1, 3, NULL, 3)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'D01', N'Nước táo', 1200, N'bv1.png', 1, 2, NULL, 4)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'D02', N'Nước cam', 500, N'bv2.png', 0, 2, NULL, 4)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'D03', N'Nước dâu', 400, N'bv3.png', 1, 2, NULL, 5)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'D04', N'Bia đen', 1000, N'bv4.png', 1, 2, NULL, 5)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'D05', N'Coca', 1200, N'bv5.png', 1, 2, NULL, 6)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'F01', N'Muối', 1000, N'1.png', 1, 1, NULL, 7)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'F02', N'Hướng dương', 1200, N'2.png', 1, 1, NULL, 7)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'F03', N'Bột mì', 500, N'3.png', 0, 1, NULL, 9)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'F04', N'Súp TATA', 400, N'4.png', 1, 1, NULL, 9)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'F05', N'Gạo', 1000, N'5.png', 1, 1, NULL, 8)
INSERT [dbo].[Products] ([Id], [Name], [UnitPrice], [Image], [Available], [CategoryId], [Description], [ProviderId]) VALUES (N'F06', N'Sữa', 1000, N'4.png', 1, 1, NULL, 8)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (1, N'Sunhouse', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (2, N'Roler', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (3, N'Elmich', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (4, N'Mixue', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (5, N'CircleK', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (6, N'ToCoToCo', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (7, N'AceCook', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (8, N'MiLan', NULL)
INSERT [dbo].[Providers] ([Id], [ProviderName], [Description]) VALUES (9, N'Kotobuki', NULL)
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Products]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetails_dbo.Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_dbo.OrderDetails_dbo.Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Customers_CustomerId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Providers] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Providers] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Providers]
GO
USE [master]
GO
ALTER DATABASE [NewShop] SET  READ_WRITE 
GO


