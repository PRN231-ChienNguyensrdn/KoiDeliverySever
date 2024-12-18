USE [master]
GO
/****** Object:  Database [KoiDeliveryDB]    Script Date: 11/3/2024 2:51:50 PM ******/
CREATE DATABASE [KoiDeliveryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KoiDeliveryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KoiDeliveryDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KoiDeliveryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\KoiDeliveryDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KoiDeliveryDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KoiDeliveryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KoiDeliveryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KoiDeliveryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KoiDeliveryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KoiDeliveryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KoiDeliveryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KoiDeliveryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KoiDeliveryDB] SET  MULTI_USER 
GO
ALTER DATABASE [KoiDeliveryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KoiDeliveryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KoiDeliveryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KoiDeliveryDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KoiDeliveryDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KoiDeliveryDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KoiDeliveryDB] SET QUERY_STORE = OFF
GO
USE [KoiDeliveryDB]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ImagePath] [nvarchar](255) NULL,
	[CreatedAt] [datetime] NULL,
	[AuthorID] [int] NULL,
	[PriceListID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BlogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerProfiles]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerProfiles](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[TotalOrders] [int] NULL,
	[TotalSpent] [decimal](18, 0) NULL,
	[LastOrderDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[Origin] [nvarchar](255) NOT NULL,
	[Destination] [nvarchar](255) NOT NULL,
	[TotalWeight] [decimal](18, 0) NOT NULL,
	[TotalQuantity] [int] NOT NULL,
	[ShippingMethod] [nvarchar](100) NULL,
	[AdditionalServices] [nvarchar](255) NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[DateShip] [datetime] NULL,
	[PaymentMethod] [nvarchar](50) NULL,
	[PhoneContact] [nvarchar](15) NULL,
	[FishType] [nvarchar](250) NULL,
	[NameUserGet] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PriceList]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PriceList](
	[PriceID] [int] IDENTITY(1,1) NOT NULL,
	[WeightRange] [nvarchar](50) NOT NULL,
	[BasePrice] [decimal](18, 0) NOT NULL,
	[AdditionalServicePrice] [decimal](18, 0) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PriceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RatingsFeedbacks]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RatingsFeedbacks](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[Rating] [int] NULL,
	[Feedback] [nvarchar](1000) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Route]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[RoutedID] [int] IDENTITY(1,1) NOT NULL,
	[ShipmentID] [int] NULL,
	[Status] [bit] NULL,
	[Notice] [nvarchar](250) NULL,
	[DateSetting] [date] NOT NULL,
	[DateUpdate] [date] NULL,
	[Adress] [nvarchar](50) NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[RoutedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipments]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipments](
	[ShipmentID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[SalesStaffID] [int] NULL,
	[DeliveringStaffID] [int] NULL,
	[HealthCheckStatus] [nvarchar](50) NULL,
	[PackingStatus] [nvarchar](50) NULL,
	[ShippingStatus] [nvarchar](50) NULL,
	[ForeignImportStatus] [nvarchar](50) NULL,
	[CertificateIssued] [nvarchar](255) NULL,
	[DeliveryDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ShipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentMethod] [nvarchar](100) NULL,
	[BankCode] [nvarchar](max) NULL,
	[BankTranNo] [nvarchar](max) NULL,
	[CardType] [nvarchar](max) NULL,
	[PaymentInfor] [nvarchar](max) NULL,
	[PayDate] [datetime] NULL,
	[TransactionNo] [nvarchar](max) NULL,
	[TransasctionStatus] [int] NULL,
	[PaymentAccount] [int] NULL,
	[OrderID] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/3/2024 2:51:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[Address] [nvarchar](255) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Origin], [Destination], [TotalWeight], [TotalQuantity], [ShippingMethod], [AdditionalServices], [Status], [CreatedAt], [DateShip], [PaymentMethod], [PhoneContact], [FishType], [NameUserGet]) VALUES (1, 1, N'Hanoi', N'Ho Chi Minh City', CAST(13 AS Decimal(18, 0)), 50, N'Air', N'Insurance, Packaging', N'Pending', CAST(N'2024-11-03T14:38:28.887' AS DateTime), CAST(N'2024-12-01T00:00:00.000' AS DateTime), N'Credit Card', N'0123456789', N'Koi', N'John Doe')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Origin], [Destination], [TotalWeight], [TotalQuantity], [ShippingMethod], [AdditionalServices], [Status], [CreatedAt], [DateShip], [PaymentMethod], [PhoneContact], [FishType], [NameUserGet]) VALUES (7, 1, N'Hanoi', N'Ho Chi Minh City', CAST(13 AS Decimal(18, 0)), 50, N'Air', N'Insurance, Packaging', N'Pending', CAST(N'2024-11-03T14:40:12.143' AS DateTime), CAST(N'2024-12-01T00:00:00.000' AS DateTime), N'Credit Card', N'0123456789', N'Koi', N'John Doe')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Origin], [Destination], [TotalWeight], [TotalQuantity], [ShippingMethod], [AdditionalServices], [Status], [CreatedAt], [DateShip], [PaymentMethod], [PhoneContact], [FishType], [NameUserGet]) VALUES (8, 2, N'Da Nang', N'Hanoi', CAST(8 AS Decimal(18, 0)), 30, N'Ground', N'Packaging', N'Shipped', CAST(N'2024-11-03T14:40:23.580' AS DateTime), CAST(N'2024-11-15T00:00:00.000' AS DateTime), N'Cash', N'0987654321', N'Goldfish', N'Jane Doe')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Origin], [Destination], [TotalWeight], [TotalQuantity], [ShippingMethod], [AdditionalServices], [Status], [CreatedAt], [DateShip], [PaymentMethod], [PhoneContact], [FishType], [NameUserGet]) VALUES (9, 3, N'Hue', N'Can Tho', CAST(15 AS Decimal(18, 0)), 45, N'Sea', NULL, N'In Transit', CAST(N'2024-11-03T14:40:33.077' AS DateTime), CAST(N'2024-12-05T00:00:00.000' AS DateTime), N'Credit Card', N'0933445566', N'Tetra', N'Alice Nguyen')
INSERT [dbo].[Orders] ([OrderID], [CustomerID], [Origin], [Destination], [TotalWeight], [TotalQuantity], [ShippingMethod], [AdditionalServices], [Status], [CreatedAt], [DateShip], [PaymentMethod], [PhoneContact], [FishType], [NameUserGet]) VALUES (10, 4, N'Hai Phong', N'Da Nang', CAST(10 AS Decimal(18, 0)), 20, N'Air', N'Insurance', N'Delivered', CAST(N'2024-11-03T14:40:40.910' AS DateTime), CAST(N'2024-11-20T00:00:00.000' AS DateTime), N'Bank Transfer', N'0901234567', N'Betta', N'Bob Tran')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Shipments] ON 

INSERT [dbo].[Shipments] ([ShipmentID], [OrderID], [SalesStaffID], [DeliveringStaffID], [HealthCheckStatus], [PackingStatus], [ShippingStatus], [ForeignImportStatus], [CertificateIssued], [DeliveryDate]) VALUES (3, 1, 1, 1, N'Passed', N'Complete', N'In Transit', N'Cleared', N'Issued', CAST(N'2024-12-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Shipments] ([ShipmentID], [OrderID], [SalesStaffID], [DeliveringStaffID], [HealthCheckStatus], [PackingStatus], [ShippingStatus], [ForeignImportStatus], [CertificateIssued], [DeliveryDate]) VALUES (5, 7, 1, 1, N'Passed', N'In Progress', N'In Transit', NULL, N'Not Issued', CAST(N'2024-12-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Shipments] ([ShipmentID], [OrderID], [SalesStaffID], [DeliveringStaffID], [HealthCheckStatus], [PackingStatus], [ShippingStatus], [ForeignImportStatus], [CertificateIssued], [DeliveryDate]) VALUES (6, 8, 2, 2, N'Failed', N'Complete', N'Delivered', N'Cleared', N'Issued', CAST(N'2025-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Shipments] ([ShipmentID], [OrderID], [SalesStaffID], [DeliveringStaffID], [HealthCheckStatus], [PackingStatus], [ShippingStatus], [ForeignImportStatus], [CertificateIssued], [DeliveryDate]) VALUES (7, 9, 2, 1, N'Pending', N'In Progress', N'Pending', NULL, NULL, CAST(N'2025-01-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Shipments] ([ShipmentID], [OrderID], [SalesStaffID], [DeliveringStaffID], [HealthCheckStatus], [PackingStatus], [ShippingStatus], [ForeignImportStatus], [CertificateIssued], [DeliveryDate]) VALUES (8, 10, 1, 3, N'Passed', N'Complete', N'Delivered', N'Cleared', N'Issued', CAST(N'2025-01-10T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Shipments] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [PhoneNumber], [Address], [CreatedAt]) VALUES (1, N'John Doe', N'john.doe@example.com', N'hashedpassword1', N'Customer', N'123-456-7890', N'123 Elm Street, Springfield', CAST(N'2024-09-19T23:48:30.917' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [PhoneNumber], [Address], [CreatedAt]) VALUES (2, N'Jane Smith', N'jane.smith@example.com', N'hashedpassword2', N'SalesStaff', N'987-654-3210', N'456 Oak Avenue, Springfield', CAST(N'2024-09-19T23:48:30.917' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [PhoneNumber], [Address], [CreatedAt]) VALUES (3, N'Alice Johnson', N'alice.johnson@example.com', N'hashedpassword3', N'DeliveringStaff', N'555-123-4567', N'789 Pine Road, Springfield', CAST(N'2024-09-19T23:48:30.917' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [Role], [PhoneNumber], [Address], [CreatedAt]) VALUES (4, N'Theanh', N'bob.brown@example.com', N'hashedpassword4', N'Manager', N'0123', N'q12', CAST(N'2024-09-19T23:48:30.917' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534A55527D4]    Script Date: 11/3/2024 2:51:51 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Blogs] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[CustomerProfiles] ADD  DEFAULT ((0)) FOR [TotalOrders]
GO
ALTER TABLE [dbo].[CustomerProfiles] ADD  DEFAULT ((0)) FOR [TotalSpent]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[PriceList] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[RatingsFeedbacks] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Shipments] ADD  DEFAULT ('In-Progress') FOR [ShippingStatus]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD FOREIGN KEY([PriceListID])
REFERENCES [dbo].[PriceList] ([PriceID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CustomerProfiles]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RatingsFeedbacks]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Route]  WITH CHECK ADD  CONSTRAINT [FK_Route_Shipments] FOREIGN KEY([ShipmentID])
REFERENCES [dbo].[Shipments] ([ShipmentID])
GO
ALTER TABLE [dbo].[Route] CHECK CONSTRAINT [FK_Route_Shipments]
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD FOREIGN KEY([DeliveringStaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD FOREIGN KEY([SalesStaffID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Orders]
GO
ALTER TABLE [dbo].[RatingsFeedbacks]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
USE [master]
GO
ALTER DATABASE [KoiDeliveryDB] SET  READ_WRITE 
GO
