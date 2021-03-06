USE [db_AcikVeriPortal]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](200) NOT NULL,
	[sifre] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataRequests]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DataRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataSetFileDetail]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataSetFileDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NOT NULL,
	[Extension] [nvarchar](max) NOT NULL,
	[DataSetId] [int] NOT NULL,
	[FileDataId] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DataSetFileDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DataSets]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataSets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[FormatId] [int] NOT NULL,
	[LicenseId] [int] NOT NULL,
	[LabelId] [int] NOT NULL,
 CONSTRAINT [PK_DataSets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Formats]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Formats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Labels]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Labels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Licenses]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Licenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Licenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 17.08.2020 19:56:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](200) NOT NULL,
	[Soyad] [nvarchar](200) NOT NULL,
	[EPosta] [nvarchar](200) NOT NULL,
	[Sifre] [nvarchar](200) NOT NULL,
	[OlusturulmaTarihi] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[admin] ON 

GO
INSERT [dbo].[admin] ([id], [email], [sifre]) VALUES (1, N'golcukbelediyesi@gmail.com', N'golcukbelediye')
GO
SET IDENTITY_INSERT [dbo].[admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Ekonomi')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Afet Yönetimi')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Enerji')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Yaşam')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Yönetim')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (6, N'İnsan')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Çevre')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (9, N'Tarih')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (10, N'Mobilite')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[DataRequests] ON 

GO
INSERT [dbo].[DataRequests] ([Id], [StatusId], [Title], [Description]) VALUES (2, 1, N'Deneme', N'fdsfdfgdfhfd')
GO
INSERT [dbo].[DataRequests] ([Id], [StatusId], [Title], [Description]) VALUES (5, 1, N'Gölcük''te ay bazında son 2 yılın trafik yoğunluğu bilgileri', N'Gölcük''te (mümkün olursa semtlerinde) Ağustos 2018''den itibarenki aylık trafik yoğunluğu bilgileri için veri isteği.')
GO
INSERT [dbo].[DataRequests] ([Id], [StatusId], [Title], [Description]) VALUES (6, 1, N'İstanbul''da hayvan bakım ve rehabilitasyon merkezlerine harcanan meblağ/yapılan yatırımlar', N'Adalar''da faytonların kaldırılmasından sonra hayvan hakları konusunda yeşeren umutlarımızın sahipsiz hayvanlar konusunda da devam etmesini istiyoruz. 2020 yılının başından bu yana İstanbul''da hangi hayvan bakım ve rehabilitasyon merkezine ne kadar para harcandı, koşullar iyileştirildi mi, yeni yatırımlar yapıldı mı bunu öğrenmek istiyorum.')
GO
INSERT [dbo].[DataRequests] ([Id], [StatusId], [Title], [Description]) VALUES (7, 1, N'Geri Dönüşüm', N'2020 yılı içinde geri dönüştürülebilir atıkların ayrıştırılması ve dönüştürülmesi için ayrılan bütçe miktarı ve bu amaçla çalışan tesis sayısı nedir?')
GO
SET IDENTITY_INSERT [dbo].[DataRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[DataSetFileDetail] ON 

GO
INSERT [dbo].[DataSetFileDetail] ([Id], [FileName], [Extension], [DataSetId], [FileDataId]) VALUES (15, N'isbike-web-servis-kullanm-dokuman_v1.0..pdf', N'.pdf', 5, N'adf892b7-73ee-4392-9b5c-bb7dd8fe18d5')
GO
INSERT [dbo].[DataSetFileDetail] ([Id], [FileName], [Extension], [DataSetId], [FileDataId]) VALUES (16, N'hava-kalitesi-web-servisi-kullanm-dokuman.pdf', N'.pdf', 6, N'd74c3f07-8e60-4901-a228-06a8208e0217')
GO
INSERT [dbo].[DataSetFileDetail] ([Id], [FileName], [Extension], [DataSetId], [FileDataId]) VALUES (17, N'sokak_hayvanlarna_verilen_mama_miktar_metadata.pdf', N'.pdf', 7, N'b4d1fe3a-3a33-46fe-af75-773de0f3e7c5')
GO
INSERT [dbo].[DataSetFileDetail] ([Id], [FileName], [Extension], [DataSetId], [FileDataId]) VALUES (18, N'ibbwifi-ulkelere-gore-abone-dalm-metadata.pdf', N'.pdf', 8, N'f2ae7698-d4e2-4321-820f-b7f3eb498572')
GO
SET IDENTITY_INSERT [dbo].[DataSetFileDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[DataSets] ON 

GO
INSERT [dbo].[DataSets] ([Id], [Title], [Description], [CategoryId], [OrganizationId], [FormatId], [LicenseId], [LabelId]) VALUES (5, N' İsbike İstasyon Durumları Web Servisi', N'Bu metot ile İsbike uygulaması üzerinde hizmet veren istasyonların durum bilgilerini görüntülenebilir.', 10, 7, 2, 2, 5)
GO
INSERT [dbo].[DataSets] ([Id], [Title], [Description], [CategoryId], [OrganizationId], [FormatId], [LicenseId], [LabelId]) VALUES (6, N'Hava Kalitesi İstasyon Ölçüm Sonuçları Web Servisi', N'Bu web servis ile Id’si girilen istasyonun başlangıç ve bitiş tarihine göre Konsantrasyon (Concentration) ve Hava Kalitesi Index (AQI) bilgileri paylaşılmaktadır.', 7, 9, 2, 2, 6)
GO
INSERT [dbo].[DataSets] ([Id], [Title], [Description], [CategoryId], [OrganizationId], [FormatId], [LicenseId], [LabelId]) VALUES (7, N'Sokak hayvanlarına verilen mama miktarı', N'2020.01 -2020.03 dönemi sokak hayvanlarına verilen mama miktarı', 4, 10, 2, 2, 8)
GO
INSERT [dbo].[DataSets] ([Id], [Title], [Description], [CategoryId], [OrganizationId], [FormatId], [LicenseId], [LabelId]) VALUES (8, N'ibbWiFi Ülkelere Göre Abone Dağılımı', N'Veri seti abone dönemi, ülke kodu, ülke ve abone sayısı bilgilerini içermektedir.', 6, 11, 2, 2, 8)
GO
SET IDENTITY_INSERT [dbo].[DataSets] OFF
GO
SET IDENTITY_INSERT [dbo].[Formats] ON 

GO
INSERT [dbo].[Formats] ([Id], [Name]) VALUES (1, N'XLSX')
GO
INSERT [dbo].[Formats] ([Id], [Name]) VALUES (2, N'PDF')
GO
INSERT [dbo].[Formats] ([Id], [Name]) VALUES (4, N'TXT')
GO
SET IDENTITY_INSERT [dbo].[Formats] OFF
GO
SET IDENTITY_INSERT [dbo].[Labels] ON 

GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (1, N'Ulaşım')
GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (2, N'Hat')
GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (3, N'Raylı Sistemler')
GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (4, N'mobilite')
GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (5, N'istasyon')
GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (6, N'çevre')
GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (7, N'web servis')
GO
INSERT [dbo].[Labels] ([Id], [Name]) VALUES (8, N'yaşam')
GO
SET IDENTITY_INSERT [dbo].[Labels] OFF
GO
SET IDENTITY_INSERT [dbo].[Licenses] ON 

GO
INSERT [dbo].[Licenses] ([Id], [Name]) VALUES (1, N'CC0 1.0')
GO
INSERT [dbo].[Licenses] ([Id], [Name]) VALUES (2, N'Gölcük Belediyesi Açık Veri Lisansı')
GO
SET IDENTITY_INSERT [dbo].[Licenses] OFF
GO
SET IDENTITY_INSERT [dbo].[Organizations] ON 

GO
INSERT [dbo].[Organizations] ([Id], [Name]) VALUES (6, N'Ulaşım Daire Başkanlığı')
GO
INSERT [dbo].[Organizations] ([Id], [Name]) VALUES (7, N'İSPARK A.Ş.')
GO
INSERT [dbo].[Organizations] ([Id], [Name]) VALUES (8, N'Raylı Sistem Daire Başkanlığı')
GO
INSERT [dbo].[Organizations] ([Id], [Name]) VALUES (9, N'Çevre Koruma ve Kontrol Daire Başkanlığı')
GO
INSERT [dbo].[Organizations] ([Id], [Name]) VALUES (10, N'Muhtarlıklar ve Gıda Daire Başkanlığı')
GO
INSERT [dbo].[Organizations] ([Id], [Name]) VALUES (11, N'Bilgi  İşlem Daire Başkanlığı')
GO
SET IDENTITY_INSERT [dbo].[Organizations] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

GO
INSERT [dbo].[Status] ([Id], [Name]) VALUES (1, N'Açık')
GO
INSERT [dbo].[Status] ([Id], [Name]) VALUES (2, N'Kapalı')
GO
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([Id], [Ad], [Soyad], [EPosta], [Sifre], [OlusturulmaTarihi]) VALUES (2, N'Zeynep', N'İnan', N'zeynp.inan3269@gmail.com', N'zeynep', CAST(N'2020-08-17 00:12:01.103' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[DataRequests]  WITH CHECK ADD  CONSTRAINT [FK_DataRequests_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[DataRequests] CHECK CONSTRAINT [FK_DataRequests_StatusId]
GO
ALTER TABLE [dbo].[DataSetFileDetail]  WITH CHECK ADD  CONSTRAINT [FK_DataSetFileDetail_DataSetId] FOREIGN KEY([DataSetId])
REFERENCES [dbo].[DataSets] ([Id])
GO
ALTER TABLE [dbo].[DataSetFileDetail] CHECK CONSTRAINT [FK_DataSetFileDetail_DataSetId]
GO
ALTER TABLE [dbo].[DataSets]  WITH CHECK ADD  CONSTRAINT [FK_DataSets_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[DataSets] CHECK CONSTRAINT [FK_DataSets_CategoryId]
GO
ALTER TABLE [dbo].[DataSets]  WITH CHECK ADD  CONSTRAINT [FK_DataSets_FormatId] FOREIGN KEY([FormatId])
REFERENCES [dbo].[Formats] ([Id])
GO
ALTER TABLE [dbo].[DataSets] CHECK CONSTRAINT [FK_DataSets_FormatId]
GO
ALTER TABLE [dbo].[DataSets]  WITH CHECK ADD  CONSTRAINT [FK_DataSets_LabelId] FOREIGN KEY([LabelId])
REFERENCES [dbo].[Labels] ([Id])
GO
ALTER TABLE [dbo].[DataSets] CHECK CONSTRAINT [FK_DataSets_LabelId]
GO
ALTER TABLE [dbo].[DataSets]  WITH CHECK ADD  CONSTRAINT [FK_DataSets_LicenseId] FOREIGN KEY([LicenseId])
REFERENCES [dbo].[Licenses] ([Id])
GO
ALTER TABLE [dbo].[DataSets] CHECK CONSTRAINT [FK_DataSets_LicenseId]
GO
ALTER TABLE [dbo].[DataSets]  WITH CHECK ADD  CONSTRAINT [FK_DataSets_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([Id])
GO
ALTER TABLE [dbo].[DataSets] CHECK CONSTRAINT [FK_DataSets_OrganizationId]
GO
