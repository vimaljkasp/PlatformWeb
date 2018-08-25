
ALTER TABLE [dbo].[ProductStock] DROP CONSTRAINT [fk_ProcutStock_ProductSiteMapping]
GO
ALTER TABLE [dbo].[ProductSiteMapping] DROP CONSTRAINT [fk_ProductSiteMapping_Site]
GO
ALTER TABLE [dbo].[ProductSiteMapping] DROP CONSTRAINT [fk_ProductSiteMapping_Product]
GO
ALTER TABLE [dbo].[ProductSiteMapping] DROP CONSTRAINT [fk_ProductSiteMapping_Item]
GO
ALTER TABLE [dbo].[ProductSales] DROP CONSTRAINT [fk_Sales_ProductSiteMapping]
GO
ALTER TABLE [dbo].[ProductOrderDetail] DROP CONSTRAINT [fk_ProductOrderDetail_ProductSiteMapping]
GO
ALTER TABLE [dbo].[ProductOrderDetail] DROP CONSTRAINT [fk_ProductOrderDetail_ProductOrder]
GO
ALTER TABLE [dbo].[ProductOrder] DROP CONSTRAINT [fk_ProductOrder_CustomerId]
GO
ALTER TABLE [dbo].[Product] DROP CONSTRAINT [DF__Product__Product__267ABA7A]
GO
ALTER TABLE [dbo].[EmployeeSession] DROP CONSTRAINT [DF__EmployeeS__IsLog__38996AB5]
GO
ALTER TABLE [dbo].[CustomerSession] DROP CONSTRAINT [DF__CustomerS__IsLog__3A81B327]
GO
/****** Object:  Table [dbo].[SiteConfigurations]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[SiteConfigurations]
GO
/****** Object:  Table [dbo].[Site]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[Site]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[RoleModule]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[RoleModule]
GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[ProductStock]
GO
/****** Object:  Table [dbo].[ProductSiteMapping]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[ProductSiteMapping]
GO
/****** Object:  Table [dbo].[ProductSales]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[ProductSales]
GO
/****** Object:  Table [dbo].[ProductOrderDetail]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[ProductOrderDetail]
GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[ProductOrder]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[Module]
GO
/****** Object:  Table [dbo].[ItemCategory]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[ItemCategory]
GO
/****** Object:  Table [dbo].[EmployeeSession]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[EmployeeSession]
GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[EmployeeRole]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[CustomerWallet]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[CustomerWallet]
GO
/****** Object:  Table [dbo].[CustomerSession]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[CustomerSession]
GO
/****** Object:  Table [dbo].[CustomerPaymentTransaction]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[CustomerPaymentTransaction]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 23-08-2018 07:57:42 ******/
DROP TABLE [dbo].[Customer]
GO
/****** Object:  StoredProcedure [dbo].[GetProductOrders]    Script Date: 23-08-2018 07:57:42 ******/
DROP PROCEDURE [dbo].[GetProductOrders]
GO
/****** Object:  StoredProcedure [dbo].[GetDashboardDetails]    Script Date: 23-08-2018 07:57:42 ******/
DROP PROCEDURE [dbo].[GetDashboardDetails]
GO
/****** Object:  StoredProcedure [dbo].[GetDashboardDetails]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON

/****** Object:  Table [dbo].[Customer]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int]  NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[AddressLine1] [nvarchar](50) NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](20) NULL,
	[District] [nvarchar](20) NULL,
	[State] [nvarchar](40) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[MobileNumber] [nvarchar](20) NOT NULL,
	[HomePhone] [nvarchar](20) NULL,
 CONSTRAINT [PK__Customer__A4AE64D8A5987A80] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerPaymentTransaction]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerPaymentTransaction](
	[CustomerPaymentId] [int]  NOT NULL,
	[CustomerId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[PaymentCrAmount] [decimal](18, 2) NULL,
	[PaymentDrAmount] [decimal](18, 2) NULL,
	[PaymentDate] [datetime] NOT NULL,
	[PaymentReceivedBy] [nvarchar](50) NULL,
	[Ref1] [nvarchar](50) NULL,
	[Ref2] [nvarchar](50) NULL,
 CONSTRAINT [PK__Customer__55433A6B3C08E1B9] PRIMARY KEY CLUSTERED 
(
	[CustomerPaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerSession]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerSession](
	[SessionId] [int]  NOT NULL,
	[CustomerId] [int] NULL,
	[SessionStartDtm] [datetime] NOT NULL,
	[SessionEndDtm] [datetime] NOT NULL,
	[IsLogout] [bit] NULL,
 CONSTRAINT [PK__Customer__C9F49290E1376A59] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CustomerWallet]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerWallet](
	[WalletId] [int]  NOT NULL,
	[CustomerId] [int] NOT NULL,
	[WalletBalance] [decimal](18, 2) NOT NULL,
	[AmountDueDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Customer__A4AE64D825A5558C] PRIMARY KEY CLUSTERED 
(
	[WalletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int]  NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[UserName] [nvarchar](40) NOT NULL,
	[Password] [nvarchar](40) NOT NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[City] [nvarchar](20) NOT NULL,
	[District] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](20) NOT NULL,
	[MobileNumber] [nvarchar](20) NOT NULL,
	[HomePhonne] [nvarchar](20) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Employee__C9F2845715311A82] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeRole]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeRole](
	[EmployeeId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK__Employee__C27FE3F0BD3872AC] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeeSession]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeSession](
	[SessionId] [int]  NOT NULL,
	[EmployeeId] [int] NULL,
	[SiteId] [int] NULL,
	[SessionStartDtm] [datetime] NOT NULL,
	[SessionEndDtm] [datetime] NOT NULL,
	[IsLogout] [bit] NULL,
 CONSTRAINT [PK__Employee__C9F492903106A9A5] PRIMARY KEY CLUSTERED 
(
	[SessionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemCategory]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemCategory](
	[ItemId] [int]  NOT NULL,
	[ItemCode] [nvarchar](20) NULL,
	[ItemName] [nvarchar](40) NOT NULL,
	[ItemDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK__Item__727E838B4DD664E2] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Module]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ModuleId] [int] NOT NULL,
	[ModuleName] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__Module__2B7477A7C19C6495] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int]  NOT NULL,
	[ProductCode] [nvarchar](20) NULL,
	[ProductName] [nvarchar](40) NULL,
	[ProductDescription] [nvarchar](100) NULL,
	[ProductQuantity] [decimal](18, 2) NULL,
	[ProductPrice] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[Ref1] [nvarchar](50) NULL,
	[Ref2] [nvarchar](50) NULL,
 CONSTRAINT [PK__Product__B40CC6CDF76CEBFC] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductOrder]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrder](
	[OrderId] [int]  NOT NULL,
	[OrderNumber] [nvarchar](50) NOT NULL,
	[OrderPurchaseDtm] [datetime] NOT NULL,
	[OrderCustomerId] [int] NULL,
	[OrderPrice] [decimal](18, 2) NOT NULL,
	[OrderTax] [decimal](18, 2) NULL,
	[OrderTotalPrice] [decimal](18, 2) NULL,
	[OrderPriority] [nvarchar](50) NULL,
	[OrderComments] [nvarchar](80) NULL,
	[Ref1] [nvarchar](50) NULL,
	[Ref2] [nvarchar](50) NULL,
 CONSTRAINT [PK__ProductO__C3905BCF4C8A4679] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductOrderDetail]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductOrderDetail](
	[ProductOrderDetailId] [int]  NOT NULL,
	[OrderId] [int] NULL,
	[ProductMappingId] [int] NULL,
	[OrderStatus] [int] NOT NULL,
	[OrderAddress] [nvarchar](1) NULL,
	[DeliveryExpectedDate] [date] NOT NULL,
	[DeliveredDate] [datetime] NULL,
	[DeliveredBy] [nvarchar](150) NULL,
	[VehicleNumber] [nvarchar](150) NULL,
	[DriverName] [nvarchar](150) NULL,
	[DriverNumber] [nvarchar](150) NULL,
	[JCBDriverNumber] [nvarchar](150) NULL,
	[RoyaltyNumber] [nvarchar](150) NULL,
	[Quantity] [decimal](18, 2) NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[Ref1] [nvarchar](50) NULL,
	[Ref2] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductOrderDetail] PRIMARY KEY CLUSTERED 
(
	[ProductOrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSales]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSales](
	[SalesId] [int]  NOT NULL,
	[SalesDate] [date] NOT NULL,
	[ProductMappingId] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Ref1] [nvarchar](50) NULL,
	[Ref2] [nvarchar](50) NULL,
 CONSTRAINT [PK__Sales__DEE0F82A01E5150B] PRIMARY KEY CLUSTERED 
(
	[SalesDate] ASC,
	[ProductMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSiteMapping]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSiteMapping](
	[ProductMappingId] [int]  NOT NULL,
	[SiteId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK__ProductS__6F8176F647489215] PRIMARY KEY CLUSTERED 
(
	[ProductMappingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStock](
	[StockId] [int]  NOT NULL,
	[StockDate] [date] NOT NULL,
	[StockProductId] [int] NOT NULL,
	[StockCreatedBy] [int] NOT NULL,
	[StockCreatedDtm] [datetime] NOT NULL,
	[StockQuantiy] [decimal](18, 2) NOT NULL,
	[Ref1] [nvarchar](50) NULL,
	[Ref2] [nvarchar](50) NULL,
 CONSTRAINT [PK__ProductS__27BF069A2B5D3CC2] PRIMARY KEY CLUSTERED 
(
	[StockDate] ASC,
	[StockProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleModule]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModule](
	[RoleId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int]  NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleDescription] [nvarchar](100) NULL,
 CONSTRAINT [PK__Roles__8AFACE1A79825AB9] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Site]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[SiteId] [int]  NOT NULL,
	[SiteCode] [nvarchar](10) NULL,
	[SiteName] [nvarchar](40) NOT NULL,
	[SiteAddress] [nvarchar](100) NULL,
	[SiteCity] [nvarchar](20) NOT NULL,
	[SiteState] [nvarchar](20) NOT NULL,
	[SiteZipCode] [nvarchar](10) NOT NULL,
	[SiteMobileNumber] [nvarchar](10) NOT NULL,
	[IsActive] [bit] NULL,
	[SiteDistrict] [nvarchar](20) NULL,
	[SiteHomePhone] [nvarchar](20) NULL,
 CONSTRAINT [PK__Site__B9DCB963DB4717D3] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiteConfigurations]    Script Date: 23-08-2018 07:57:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteConfigurations](
	[Id] [int]  NOT NULL,
	[KeyData] [nvarchar](40) NOT NULL,
	[KeyName] [nvarchar](40) NOT NULL,
	[DataVal] [nvarchar](40) NOT NULL,
	[DefaultVal] [nvarchar](40) NOT NULL,
	[Description] [nvarchar](200) NULL,
 CONSTRAINT [PK__SiteConf__73525BEDD2907E57] PRIMARY KEY CLUSTERED 
(
	[KeyData] ASC,
	[KeyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


GO
INSERT [dbo].[Customer] ([CustomerId], [Name], [AddressLine1], [AddressLine2], [City], [District], [State], [PostalCode], [MobileNumber], [HomePhone]) VALUES (3, N'Vimal', NULL, NULL, NULL, NULL, NULL, NULL, N'9566812835', NULL)
GO
INSERT [dbo].[Customer] ([CustomerId], [Name], [AddressLine1], [AddressLine2], [City], [District], [State], [PostalCode], [MobileNumber], [HomePhone]) VALUES (4, N'Vimal', NULL, NULL, NULL, NULL, NULL, NULL, N'9566812835', NULL)

GO

INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (1, 4, 0, NULL, CAST(53700.00 AS Decimal(18, 2)), CAST(0x0000A940012AD52F AS DateTime), N'No Payment', NULL, NULL)
GO
INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (2, 4, 0, NULL, CAST(64500.00 AS Decimal(18, 2)), CAST(0x0000A940017493B4 AS DateTime), N'No Payment', NULL, NULL)
GO
INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (3, 4, 0, NULL, CAST(107500.00 AS Decimal(18, 2)), CAST(0x0000A941010491FD AS DateTime), N'No Payment', NULL, NULL)
GO
INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (4, 4, 0, NULL, CAST(107500.00 AS Decimal(18, 2)), CAST(0x0000A9410104D393 AS DateTime), N'No Payment', NULL, NULL)
GO
INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (5, 4, 0, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A944000106BF AS DateTime), N'No Payment', NULL, NULL)
GO
INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (6, 4, 0, NULL, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A94400035937 AS DateTime), N'No Payment', NULL, NULL)
GO
INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (10, 3, 2, CAST(0.00 AS Decimal(18, 2)), CAST(1075.00 AS Decimal(18, 2)), CAST(0x0000A94500000000 AS DateTime), N'Order Placed', NULL, NULL)
GO
INSERT [dbo].[CustomerPaymentTransaction] ([CustomerPaymentId], [CustomerId], [OrderId], [PaymentCrAmount], [PaymentDrAmount], [PaymentDate], [PaymentReceivedBy], [Ref1], [Ref2]) VALUES (11, 3, 2, CAST(500.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A94500254E84 AS DateTime), N'Rahul', NULL, NULL)

GO
INSERT [dbo].[CustomerWallet] ([WalletId], [CustomerId], [WalletBalance], [AmountDueDate]) VALUES (1, 4, CAST(53700.00 AS Decimal(18, 2)), CAST(0x0000A94A012AF57E AS DateTime))
GO
INSERT [dbo].[CustomerWallet] ([WalletId], [CustomerId], [WalletBalance], [AmountDueDate]) VALUES (3, 3, CAST(1650.00 AS Decimal(18, 2)), CAST(0x0000A94F002602A9 AS DateTime))

GO
INSERT [dbo].[Employee] ([EmployeeId], [Name], [UserName], [Password], [AddressLine1], [AddressLine2], [City], [District], [PostalCode], [MobileNumber], [HomePhonne], [IsActive]) VALUES (1, N'Vimal Anjana', N'9566812835', N'jT7a994atGo=', N'G02 D block', N'Balaji Elgeance', N'Bangalore', N'Pratapgarh', N'560066', N'9566812835', N'4534434543', NULL)
GO
INSERT [dbo].[Employee] ([EmployeeId], [Name], [UserName], [Password], [AddressLine1], [AddressLine2], [City], [District], [PostalCode], [MobileNumber], [HomePhonne], [IsActive]) VALUES (2, N'Vimal Anjana', N'9566812836', N'jT7a994atGo=', N'G02 D block', N'Balaji Elgeance', N'Bangalore', N'Pratapgarh', N'560066', N'9566812836', N'4534434543', NULL)

GO
INSERT [dbo].[EmployeeSession] ([SessionId], [EmployeeId], [SiteId], [SessionStartDtm], [SessionEndDtm], [IsLogout]) VALUES (2, 1, 1, CAST(0x0000A93A0167B6FE AS DateTime), CAST(0x002D247F018B81FF AS DateTime), 0)

GO
INSERT [dbo].[ItemCategory] ([ItemId], [ItemCode], [ItemName], [ItemDescription]) VALUES (1, N'Gitti', N'Gitti', N'All Gitti Products')

GO
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductDescription], [ProductQuantity], [ProductPrice], [IsActive], [Ref1], [Ref2]) VALUES (1, N'Gitti12MM-20MM', N'Gitti 12-20 MM', N'Gitti 12-20 MM Calculated in Square Feet', CAST(1.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), 1, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductDescription], [ProductQuantity], [ProductPrice], [IsActive], [Ref1], [Ref2]) VALUES (2, N'Gitti6MM', N'Gitti 6MM', N'Gitti 6MM Calculated in Square Feet', CAST(1.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), 1, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductDescription], [ProductQuantity], [ProductPrice], [IsActive], [Ref1], [Ref2]) VALUES (3, N'Gitti10MM', N'Gitti 10MM', N'Gitti 10MM Calculated in Square Feet', CAST(1.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), 1, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductDescription], [ProductQuantity], [ProductPrice], [IsActive], [Ref1], [Ref2]) VALUES (4, N'Gitti4MM', N'Gitti 4MM', N'Gitti 12-20 MM Calculated in Square Feet', CAST(1.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), 1, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductDescription], [ProductQuantity], [ProductPrice], [IsActive], [Ref1], [Ref2]) VALUES (5, N'DUST', N'DUST', N'DUST Calculated in Square Feet', CAST(1.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), 1, NULL, NULL)
GO
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductDescription], [ProductQuantity], [ProductPrice], [IsActive], [Ref1], [Ref2]) VALUES (6, N'Gitti65MM', N'Gitti 65MM', N'Gitti 12-20 MM Calculated in Ton', CAST(1.00 AS Decimal(18, 2)), CAST(12000.00 AS Decimal(18, 2)), 1, NULL, NULL)

GO
INSERT [dbo].[ProductOrder] ([OrderId], [OrderNumber], [OrderPurchaseDtm], [OrderCustomerId], [OrderPrice], [OrderTax], [OrderTotalPrice], [OrderPriority], [OrderComments], [Ref1], [Ref2]) VALUES (2, N'00000000-0000-0000-0000-000000000000', CAST(0x0000A94500000000 AS DateTime), 3, CAST(1000.00 AS Decimal(18, 2)), CAST(75.00 AS Decimal(18, 2)), CAST(1075.00 AS Decimal(18, 2)), N'Fast', N'Some Comments', NULL, NULL)
GO

INSERT [dbo].[ProductOrderDetail] ([ProductOrderDetailId], [OrderId], [ProductMappingId], [OrderStatus], [OrderAddress], [DeliveryExpectedDate], [DeliveredDate], [DeliveredBy], [VehicleNumber], [DriverName], [DriverNumber], [JCBDriverNumber], [RoyaltyNumber], [Quantity], [TotalPrice], [Ref1], [Ref2]) VALUES (1, 2, 1, 1, NULL, CAST(0x00000000 AS Date), CAST(0x0000A945001CE0C4 AS DateTime), N'ramesh', N'RJ 35 1234', N'Mukesh', N'956682833', N'9566812833', N'123231231', CAST(500.35 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), NULL, NULL)

GO
INSERT [dbo].[ProductSales] ([SalesId], [SalesDate], [ProductMappingId], [Quantity], [TotalPrice], [Ref1], [Ref2]) VALUES (1, CAST(0x9B3E0B00 AS Date), 1, CAST(1.00 AS Decimal(18, 2)), CAST(60000.00 AS Decimal(18, 2)), NULL, NULL)
GO
INSERT [dbo].[ProductSales] ([SalesId], [SalesDate], [ProductMappingId], [Quantity], [TotalPrice], [Ref1], [Ref2]) VALUES (2, CAST(0x9C3E0B00 AS Date), 1, CAST(2.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), NULL, NULL)
GO
INSERT [dbo].[ProductSales] ([SalesId], [SalesDate], [ProductMappingId], [Quantity], [TotalPrice], [Ref1], [Ref2]) VALUES (3, CAST(0x9F3E0B00 AS Date), 1, CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), NULL, NULL)
GO
INSERT [dbo].[ProductSales] ([SalesId], [SalesDate], [ProductMappingId], [Quantity], [TotalPrice], [Ref1], [Ref2]) VALUES (4, CAST(0xA03E0B00 AS Date), 1, CAST(1000.70 AS Decimal(18, 2)), CAST(2150.00 AS Decimal(18, 2)), NULL, NULL)

GO
INSERT [dbo].[ProductSiteMapping] ([ProductMappingId], [SiteId], [ItemId], [ProductId]) VALUES (1, 1, 1, 1)
GO
INSERT [dbo].[ProductSiteMapping] ([ProductMappingId], [SiteId], [ItemId], [ProductId]) VALUES (2, 1, 1, 2)
GO
INSERT [dbo].[ProductSiteMapping] ([ProductMappingId], [SiteId], [ItemId], [ProductId]) VALUES (3, 1, 1, 3)
GO
INSERT [dbo].[ProductSiteMapping] ([ProductMappingId], [SiteId], [ItemId], [ProductId]) VALUES (4, 1, 1, 4)
GO
INSERT [dbo].[ProductSiteMapping] ([ProductMappingId], [SiteId], [ItemId], [ProductId]) VALUES (5, 1, 1, 5)
GO
INSERT [dbo].[ProductSiteMapping] ([ProductMappingId], [SiteId], [ItemId], [ProductId]) VALUES (6, 1, 1, 6)

GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (1, N'SuperUser', N'Super User Role')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName], [RoleDescription]) VALUES (2, N'Worker', N'Worker User Role')

GO
INSERT [dbo].[Site] ([SiteId], [SiteCode], [SiteName], [SiteAddress], [SiteCity], [SiteState], [SiteZipCode], [SiteMobileNumber], [IsActive], [SiteDistrict], [SiteHomePhone]) VALUES (1, N'Kesunda', N'Kesunda Kreshar', N'Near Kesunda', N'Kesunda', N'Rajasthan', N'312601', N'4564646456', 1, N'Pratapgarh', N'1236547890')

GO
INSERT [dbo].[SiteConfigurations] ([Id], [KeyData], [KeyName], [DataVal], [DefaultVal], [Description]) VALUES (1, N'OrderTax', N'IsEnable', N'True', N'False', N'To know if tax is applicable on order')
GO
INSERT [dbo].[SiteConfigurations] ([Id], [KeyData], [KeyName], [DataVal], [DefaultVal], [Description]) VALUES (2, N'OrderTax', N'Percentage', N'7.5', N'7', N'To know if tax precentage on order')

GO
ALTER TABLE [dbo].[CustomerSession] ADD  CONSTRAINT [DF__CustomerS__IsLog__3A81B327]  DEFAULT ((0)) FOR [IsLogout]
GO
ALTER TABLE [dbo].[EmployeeSession] ADD  CONSTRAINT [DF__EmployeeS__IsLog__38996AB5]  DEFAULT ((0)) FOR [IsLogout]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__Product__Product__267ABA7A]  DEFAULT ((1)) FOR [ProductQuantity]
GO
ALTER TABLE [dbo].[ProductOrder]  WITH CHECK ADD  CONSTRAINT [fk_ProductOrder_CustomerId] FOREIGN KEY([OrderCustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
ALTER TABLE [dbo].[ProductOrder] CHECK CONSTRAINT [fk_ProductOrder_CustomerId]
GO
ALTER TABLE [dbo].[ProductOrderDetail]  WITH CHECK ADD  CONSTRAINT [fk_ProductOrderDetail_ProductOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[ProductOrder] ([OrderId])
GO
ALTER TABLE [dbo].[ProductOrderDetail] CHECK CONSTRAINT [fk_ProductOrderDetail_ProductOrder]
GO
ALTER TABLE [dbo].[ProductOrderDetail]  WITH CHECK ADD  CONSTRAINT [fk_ProductOrderDetail_ProductSiteMapping] FOREIGN KEY([ProductMappingId])
REFERENCES [dbo].[ProductSiteMapping] ([ProductMappingId])
GO
ALTER TABLE [dbo].[ProductOrderDetail] CHECK CONSTRAINT [fk_ProductOrderDetail_ProductSiteMapping]
GO
ALTER TABLE [dbo].[ProductSales]  WITH CHECK ADD  CONSTRAINT [fk_Sales_ProductSiteMapping] FOREIGN KEY([ProductMappingId])
REFERENCES [dbo].[ProductSiteMapping] ([ProductMappingId])
GO
ALTER TABLE [dbo].[ProductSales] CHECK CONSTRAINT [fk_Sales_ProductSiteMapping]
GO
ALTER TABLE [dbo].[ProductSiteMapping]  WITH CHECK ADD  CONSTRAINT [fk_ProductSiteMapping_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[ItemCategory] ([ItemId])
GO
ALTER TABLE [dbo].[ProductSiteMapping] CHECK CONSTRAINT [fk_ProductSiteMapping_Item]
GO
ALTER TABLE [dbo].[ProductSiteMapping]  WITH CHECK ADD  CONSTRAINT [fk_ProductSiteMapping_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ProductSiteMapping] CHECK CONSTRAINT [fk_ProductSiteMapping_Product]
GO
ALTER TABLE [dbo].[ProductSiteMapping]  WITH CHECK ADD  CONSTRAINT [fk_ProductSiteMapping_Site] FOREIGN KEY([SiteId])
REFERENCES [dbo].[Site] ([SiteId])
GO
ALTER TABLE [dbo].[ProductSiteMapping] CHECK CONSTRAINT [fk_ProductSiteMapping_Site]
GO
ALTER TABLE [dbo].[ProductStock]  WITH CHECK ADD  CONSTRAINT [fk_ProcutStock_ProductSiteMapping] FOREIGN KEY([StockProductId])
REFERENCES [dbo].[ProductSiteMapping] ([ProductMappingId])
GO
ALTER TABLE [dbo].[ProductStock] CHECK CONSTRAINT [fk_ProcutStock_ProductSiteMapping]
GO

