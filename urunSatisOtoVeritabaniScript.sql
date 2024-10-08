USE [master]
GO
/****** Object:  Database [DbUrunSatis]    Script Date: 28.03.2023 11:20:09 ******/
CREATE DATABASE [DbUrunSatis] ON  PRIMARY 
( NAME = N'DbUrunSatis', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DbUrunSatis.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DbUrunSatis_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\DbUrunSatis_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DbUrunSatis] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbUrunSatis].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbUrunSatis] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbUrunSatis] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbUrunSatis] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbUrunSatis] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbUrunSatis] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbUrunSatis] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbUrunSatis] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DbUrunSatis] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbUrunSatis] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbUrunSatis] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbUrunSatis] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbUrunSatis] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbUrunSatis] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbUrunSatis] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbUrunSatis] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbUrunSatis] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DbUrunSatis] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbUrunSatis] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbUrunSatis] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbUrunSatis] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbUrunSatis] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbUrunSatis] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbUrunSatis] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbUrunSatis] SET RECOVERY FULL 
GO
ALTER DATABASE [DbUrunSatis] SET  MULTI_USER 
GO
ALTER DATABASE [DbUrunSatis] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbUrunSatis] SET DB_CHAINING OFF 
GO
USE [DbUrunSatis]
GO
/****** Object:  StoredProcedure [dbo].[satisListesi]    Script Date: 28.03.2023 11:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[satisListesi]
as
select satisID, TblUrunler.urunAd as 'Ürün Adı', TblMusteriler.ad + ' ' + TblMusteriler.soyad as ' Ad Soyad', adet, toplamFiyat as 'Toplam Fiyat', tarih  from TblSatislar
inner join TblUrunler 
on TblSatislar.urun= TblUrunler.urunID 
inner join tblMusteriler 
on TblSatislar.musteri = TblMusteriler.musteriID 


GO
/****** Object:  StoredProcedure [dbo].[satisListesi2]    Script Date: 28.03.2023 11:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[satisListesi2]
as
select satisID, TblUrunler.urunAd as 'Ürün Adı', TblMusteriler.ad + ' ' + TblMusteriler.soyad as 'Ad Soyad', adet, toplamFiyat as 'Toplam Fiyat', tarih  from TblSatislar
inner join TblUrunler 
on TblSatislar.urun= TblUrunler.urunID 
inner join tblMusteriler 
on TblSatislar.musteri = TblMusteriler.musteriID 

GO
/****** Object:  Table [dbo].[TblMusteriler]    Script Date: 28.03.2023 11:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblMusteriler](
	[musteriID] [int] IDENTITY(1,1) NOT NULL,
	[ad] [nvarchar](50) NULL,
	[soyad] [nvarchar](50) NULL,
	[adres] [nvarchar](50) NULL,
	[tel] [nvarchar](50) NULL,
	[durum] [bit] NULL,
 CONSTRAINT [PK_TblMusteriler] PRIMARY KEY CLUSTERED 
(
	[musteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblSatislar]    Script Date: 28.03.2023 11:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblSatislar](
	[satisID] [int] IDENTITY(1,1) NOT NULL,
	[urun] [int] NULL,
	[musteri] [int] NULL,
	[adet] [int] NULL,
	[toplamFiyat] [int] NULL,
	[tarih] [smalldatetime] NULL,
 CONSTRAINT [PK_TblSatislar] PRIMARY KEY CLUSTERED 
(
	[satisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblUrunler]    Script Date: 28.03.2023 11:20:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUrunler](
	[urunID] [int] IDENTITY(1,1) NOT NULL,
	[urunAd] [nvarchar](50) NULL,
	[stok] [int] NULL,
	[alisFiyat] [int] NULL,
	[satisFiyat] [int] NULL,
	[durum] [bit] NULL,
 CONSTRAINT [PK_TblUrunler] PRIMARY KEY CLUSTERED 
(
	[urunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TblMusteriler] ON 

INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (1, N'Ahmet', N'TAHTA', N'Adana ', N'(555) 123-4567', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (2, N'MEHMET', N'KAYACI', N'MERSİN TARSUS', N'(505) 222-2222', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (3, N'Hasan', N'Su', N'Kayseri', N'(555) 555-5555', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (4, N'Saliha', N'Şahin', N'Konya Ereğli', N'(555) 444-4444', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (5, N'Mesut ', N'Şahin', N'Bursa ', N'(505) 111-1111', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (6, N'Mustafa', N'Yılmaz', N'Kayseri', N'(510) 222-2222', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (7, N'Beyza', N'ŞAHİN', N'Konya Karatay', N'(555) 777-7777', 0)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (8, N'Beyza ', N'Şahin', N'Konya meram', N'(555) 999-9999', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (9, N'Burak', N'Kaan', N'Kütahya', N'(555) 888-8888', 1)
INSERT [dbo].[TblMusteriler] ([musteriID], [ad], [soyad], [adres], [tel], [durum]) VALUES (10, N'Tarık', N'Akan', N'İstanbul', N'(444) 123-1231', 0)
SET IDENTITY_INSERT [dbo].[TblMusteriler] OFF
SET IDENTITY_INSERT [dbo].[TblSatislar] ON 

INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (1, 1, 1, 1, 12000, CAST(0xAFD10000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (2, 2, 2, 1, 5000, CAST(0xAFCB0000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (3, 1, 1, 1, 100, CAST(0xAFD2035C AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (4, 4, 1, 1, 60, CAST(0xAFD203E9 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (5, 3, 1, 2, 220, CAST(0xAFD203EA AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (6, 6, 2, 2, 2000, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (7, 2, 2, 2, 10000, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (8, 7, 1, 5, 150, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (9, 1, 1, 1, 12000, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (10, 2, 4, 1, 5000, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (11, 5, 5, 1, 2500, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (12, 8, 9, 1, 1600, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (13, 8, 6, 2, 3200, CAST(0xAFD20000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (14, 6, 9, 1, 1000, CAST(0xAFD30000 AS SmallDateTime))
INSERT [dbo].[TblSatislar] ([satisID], [urun], [musteri], [adet], [toplamFiyat], [tarih]) VALUES (15, 9, 1, 2, 240, CAST(0xAFD30000 AS SmallDateTime))
SET IDENTITY_INSERT [dbo].[TblSatislar] OFF
SET IDENTITY_INSERT [dbo].[TblUrunler] ON 

INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (1, N'Bilgisayar', 4, 10000, 12000, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (2, N'Yazıcı', 7, 4000, 5000, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (3, N'Klavye', 8, 100, 110, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (4, N'Mause', 5, 50, 60, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (5, N'Tarayıcı', 14, 2000, 2500, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (6, N'HDD', 7, 800, 1000, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (7, N'Test', 0, 22, 30, 0)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (8, N'Ekran', 7, 1200, 1600, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (9, N'Flash Bellek', 8, 75, 120, 1)
INSERT [dbo].[TblUrunler] ([urunID], [urunAd], [stok], [alisFiyat], [satisFiyat], [durum]) VALUES (10, N'USB çoğaltıcı', 5, 120, 150, 0)
SET IDENTITY_INSERT [dbo].[TblUrunler] OFF
ALTER TABLE [dbo].[TblMusteriler] ADD  CONSTRAINT [DF_TblMusteriler_durum]  DEFAULT ((1)) FOR [durum]
GO
ALTER TABLE [dbo].[TblUrunler] ADD  CONSTRAINT [DF_TblUrunler_durum]  DEFAULT ((1)) FOR [durum]
GO
ALTER TABLE [dbo].[TblSatislar]  WITH CHECK ADD  CONSTRAINT [FK_TblSatislar_TblMusteriler] FOREIGN KEY([musteri])
REFERENCES [dbo].[TblMusteriler] ([musteriID])
GO
ALTER TABLE [dbo].[TblSatislar] CHECK CONSTRAINT [FK_TblSatislar_TblMusteriler]
GO
ALTER TABLE [dbo].[TblSatislar]  WITH CHECK ADD  CONSTRAINT [FK_TblSatislar_TblUrunler] FOREIGN KEY([urun])
REFERENCES [dbo].[TblUrunler] ([urunID])
GO
ALTER TABLE [dbo].[TblSatislar] CHECK CONSTRAINT [FK_TblSatislar_TblUrunler]
GO
USE [master]
GO
ALTER DATABASE [DbUrunSatis] SET  READ_WRITE 
GO
