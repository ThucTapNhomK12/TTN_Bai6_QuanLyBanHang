/*
Navicat SQL Server Data Transfer

Source Server         : MS-SQL
Source Server Version : 120000
Source Host           : ANHQUAN-PC\SQLEXPRESS:1433
Source Database       : db_sale_management
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2017-05-08 14:49:37
*/

USE master
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'db_sale_management')
DROP DATABASE db_sale_management
GO
CREATE DATABASE db_sale_management
GO
USE db_sale_management

-- ----------------------------
-- Table structure for chi_tiet_hoa_don_ban
-- ----------------------------
GO
CREATE TABLE [dbo].[chi_tiet_hoa_don_ban] (
[ma_hoa_don] int NOT NULL ,
[ma_san_pham] int NOT NULL ,
[so_luong] int NOT NULL ,
[don_gia] float(53) NOT NULL ,
[thanh_tien] float(53) NOT NULL 
)


GO

-- ----------------------------
-- Records of chi_tiet_hoa_don_ban
-- ----------------------------
INSERT INTO [dbo].[chi_tiet_hoa_don_ban] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'1', N'1', N'7', N'10000000', N'70000000')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_ban] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'2', N'2', N'1603', N'29977700', N'48054253100')
GO
GO

-- ----------------------------
-- Table structure for chi_tiet_hoa_don_mua
-- ----------------------------
GO
CREATE TABLE [dbo].[chi_tiet_hoa_don_mua] (
[ma_hoa_don] int NOT NULL ,
[ma_san_pham] int NOT NULL ,
[so_luong] int NOT NULL ,
[don_gia] float(53) NOT NULL ,
[thanh_tien] float(53) NOT NULL 
)


GO

-- ----------------------------
-- Records of chi_tiet_hoa_don_mua
-- ----------------------------
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'1', N'1', N'3', N'10000000', N'30000000')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'2', N'1', N'150', N'10000000', N'1500000000')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'2', N'2', N'8', N'29977700', N'239821600')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'3', N'1', N'123', N'10000000', N'1230000000')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'3', N'2', N'1509', N'29977700', N'45236349300')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'4', N'2', N'100', N'29977700', N'2997770000')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'5', N'1', N'5', N'10000000', N'50000000')
GO
GO
INSERT INTO [dbo].[chi_tiet_hoa_don_mua] ([ma_hoa_don], [ma_san_pham], [so_luong], [don_gia], [thanh_tien]) VALUES (N'5', N'2', N'3', N'29977700', N'89933100')
GO
GO

-- ----------------------------
-- Table structure for hoa_don_ban
-- ----------------------------
GO
CREATE TABLE [dbo].[hoa_don_ban] (
[ma_hoa_don] int NOT NULL IDENTITY(1,1) ,
[ngay_lap] date NOT NULL ,
[tong_tien] float(53) NOT NULL ,
[ma_khach_hang] int NOT NULL ,
[ma_nhan_vien] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[hoa_don_ban]', RESEED, 4)
GO

-- ----------------------------
-- Records of hoa_don_ban
-- ----------------------------
SET IDENTITY_INSERT [dbo].[hoa_don_ban] ON
GO
INSERT INTO [dbo].[hoa_don_ban] ([ma_hoa_don], [ngay_lap], [tong_tien], [ma_khach_hang], [ma_nhan_vien]) VALUES (N'1', N'2017-04-16', N'70000000', N'1', N'3')
GO
GO
INSERT INTO [dbo].[hoa_don_ban] ([ma_hoa_don], [ngay_lap], [tong_tien], [ma_khach_hang], [ma_nhan_vien]) VALUES (N'2', N'2017-04-16', N'48054253100', N'1', N'3')
GO
GO
INSERT INTO [dbo].[hoa_don_ban] ([ma_hoa_don], [ngay_lap], [tong_tien], [ma_khach_hang], [ma_nhan_vien]) VALUES (N'4', N'2017-04-16', N'0', N'1', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[hoa_don_ban] OFF
GO

-- ----------------------------
-- Table structure for hoa_don_mua
-- ----------------------------
GO
CREATE TABLE [dbo].[hoa_don_mua] (
[ma_hoa_don] int NOT NULL IDENTITY(1,1) ,
[ngay_lap] date NOT NULL ,
[ma_nha_cung_cap] int NOT NULL ,
[tong_tien] float(53) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[hoa_don_mua]', RESEED, 5)
GO

-- ----------------------------
-- Records of hoa_don_mua
-- ----------------------------
SET IDENTITY_INSERT [dbo].[hoa_don_mua] ON
GO
INSERT INTO [dbo].[hoa_don_mua] ([ma_hoa_don], [ngay_lap], [ma_nha_cung_cap], [tong_tien]) VALUES (N'1', N'2017-04-16', N'1', N'30000000')
GO
GO
INSERT INTO [dbo].[hoa_don_mua] ([ma_hoa_don], [ngay_lap], [ma_nha_cung_cap], [tong_tien]) VALUES (N'2', N'2017-04-16', N'1', N'1739821600')
GO
GO
INSERT INTO [dbo].[hoa_don_mua] ([ma_hoa_don], [ngay_lap], [ma_nha_cung_cap], [tong_tien]) VALUES (N'3', N'2017-04-16', N'1', N'46466349300')
GO
GO
INSERT INTO [dbo].[hoa_don_mua] ([ma_hoa_don], [ngay_lap], [ma_nha_cung_cap], [tong_tien]) VALUES (N'4', N'2017-04-18', N'1', N'2997770000')
GO
GO
INSERT INTO [dbo].[hoa_don_mua] ([ma_hoa_don], [ngay_lap], [ma_nha_cung_cap], [tong_tien]) VALUES (N'5', N'2017-04-18', N'1', N'139933100')
GO
GO
SET IDENTITY_INSERT [dbo].[hoa_don_mua] OFF
GO

-- ----------------------------
-- Table structure for khach_hang
-- ----------------------------
GO
CREATE TABLE [dbo].[khach_hang] (
[ma_khach_hang] int NOT NULL IDENTITY(1,1) ,
[ho_ten] nvarchar(255) NOT NULL ,
[ngay_sinh] date NOT NULL ,
[dia_chi] nvarchar(255) NOT NULL ,
[so_dien_thoai] nvarchar(20) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[khach_hang]', RESEED, 2)
GO

-- ----------------------------
-- Records of khach_hang
-- ----------------------------
SET IDENTITY_INSERT [dbo].[khach_hang] ON
GO
INSERT INTO [dbo].[khach_hang] ([ma_khach_hang], [ho_ten], [ngay_sinh], [dia_chi], [so_dien_thoai]) VALUES (N'1', N'Trần Văn Huân', N'1989-12-16', N'Hà Nội', N'9878923686348')
GO
GO
INSERT INTO [dbo].[khach_hang] ([ma_khach_hang], [ho_ten], [ngay_sinh], [dia_chi], [so_dien_thoai]) VALUES (N'2', N'hehehehehehe', N'2017-04-03', N'hehe', N'1234')
GO
GO
SET IDENTITY_INSERT [dbo].[khach_hang] OFF
GO

-- ----------------------------
-- Table structure for loai_san_pham
-- ----------------------------
GO
CREATE TABLE [dbo].[loai_san_pham] (
[ma_loai_san_pham] int NOT NULL IDENTITY(1,1) ,
[ten_loai_san_pham] nvarchar(255) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[loai_san_pham]', RESEED, 3)
GO

-- ----------------------------
-- Records of loai_san_pham
-- ----------------------------
SET IDENTITY_INSERT [dbo].[loai_san_pham] ON
GO
INSERT INTO [dbo].[loai_san_pham] ([ma_loai_san_pham], [ten_loai_san_pham]) VALUES (N'1', N'máy đo')
GO
GO
INSERT INTO [dbo].[loai_san_pham] ([ma_loai_san_pham], [ten_loai_san_pham]) VALUES (N'2', N'MÁY HÚT')
GO
GO
INSERT INTO [dbo].[loai_san_pham] ([ma_loai_san_pham], [ten_loai_san_pham]) VALUES (N'3', N'abc')
GO
GO
SET IDENTITY_INSERT [dbo].[loai_san_pham] OFF
GO

-- ----------------------------
-- Table structure for nha_cung_cap
-- ----------------------------
GO
CREATE TABLE [dbo].[nha_cung_cap] (
[ma_nha_cung_cap] int NOT NULL IDENTITY(1,1) ,
[ten_nha_cung_cap] nvarchar(255) NOT NULL ,
[dia_chi] nvarchar(255) NOT NULL ,
[so_dien_thoai] nvarchar(20) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[nha_cung_cap]', RESEED, 3)
GO

-- ----------------------------
-- Records of nha_cung_cap
-- ----------------------------
SET IDENTITY_INSERT [dbo].[nha_cung_cap] ON
GO
INSERT INTO [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [so_dien_thoai]) VALUES (N'1', N'ASIN', N'HÀ NỘI', N'01219233556')
GO
GO
INSERT INTO [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [so_dien_thoai]) VALUES (N'2', N'HOA MAI', N'NAM ĐỊNH', N'0754397932')
GO
GO
INSERT INTO [dbo].[nha_cung_cap] ([ma_nha_cung_cap], [ten_nha_cung_cap], [dia_chi], [so_dien_thoai]) VALUES (N'3', N'bcxbcx', N'cxbxc', N'5233253')
GO
GO
SET IDENTITY_INSERT [dbo].[nha_cung_cap] OFF
GO

-- ----------------------------
-- Table structure for nhan_vien
-- ----------------------------
GO
CREATE TABLE [dbo].[nhan_vien] (
[ma_nhan_vien] int NOT NULL IDENTITY(1,1) ,
[ho_ten] nvarchar(255) NOT NULL ,
[dia_chi] nvarchar(255) NOT NULL ,
[so_dien_thoai] nvarchar(20) NOT NULL ,
[tai_khoan] nvarchar(255) NOT NULL ,
[mat_khau] nvarchar(255) NOT NULL ,
[trang_thai] bit NOT NULL ,
[phan_quyen] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[nhan_vien]', RESEED, 4)
GO

-- ----------------------------
-- Records of nhan_vien
-- ----------------------------
SET IDENTITY_INSERT [dbo].[nhan_vien] ON
GO
INSERT INTO [dbo].[nhan_vien] ([ma_nhan_vien], [ho_ten], [dia_chi], [so_dien_thoai], [tai_khoan], [mat_khau], [trang_thai], [phan_quyen]) VALUES (N'1', N'Admin', N'Hà Nội', N'0981429415', N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'1', N'1')
GO
GO
INSERT INTO [dbo].[nhan_vien] ([ma_nhan_vien], [ho_ten], [dia_chi], [so_dien_thoai], [tai_khoan], [mat_khau], [trang_thai], [phan_quyen]) VALUES (N'2', N'Phạm Thị Nguyệt', N'Hà Nội', N'0936515261', N'phamnguyet', N'202cb962ac59075b964b07152d234b70', N'1', N'3')
GO
GO
INSERT INTO [dbo].[nhan_vien] ([ma_nhan_vien], [ho_ten], [dia_chi], [so_dien_thoai], [tai_khoan], [mat_khau], [trang_thai], [phan_quyen]) VALUES (N'3', N'Mai Văn Liêm', N'hà noi', N'01658342653', N'mailiem', N'21232f297a57a5a743894a0e4a801fc3', N'1', N'2')
GO
GO
INSERT INTO [dbo].[nhan_vien] ([ma_nhan_vien], [ho_ten], [dia_chi], [so_dien_thoai], [tai_khoan], [mat_khau], [trang_thai], [phan_quyen]) VALUES (N'4', N'MAI VĂN LONG', N'HÀ NỘI', N'0988463275634', N'MAILONG', N'21232f297a57a5a743894a0e4a801fc3', N'1', N'4')
GO
GO
SET IDENTITY_INSERT [dbo].[nhan_vien] OFF
GO

-- ----------------------------
-- Table structure for san_pham
-- ----------------------------
GO
CREATE TABLE [dbo].[san_pham] (
[ma_san_pham] int NOT NULL IDENTITY(1,1) ,
[ten_san_pham] nvarchar(255) NOT NULL ,
[gia_san_pham] float(53) NOT NULL ,
[so_luong] int NOT NULL ,
[don_vi_tinh] nvarchar(255) NOT NULL ,
[thong_so_ky_thuat] ntext NOT NULL ,
[tinh_trang] bit NOT NULL ,
[ma_loai_san_pham] int NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[san_pham]', RESEED, 2)
GO

-- ----------------------------
-- Records of san_pham
-- ----------------------------
SET IDENTITY_INSERT [dbo].[san_pham] ON
GO
INSERT INTO [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [gia_san_pham], [so_luong], [don_vi_tinh], [thong_so_ky_thuat], [tinh_trang], [ma_loai_san_pham]) VALUES (N'1', N'Máy đo độ ẩm', N'10000000', N'124', N'chiếc', N'1234dk,sn,', N'1', N'1')
GO
GO
INSERT INTO [dbo].[san_pham] ([ma_san_pham], [ten_san_pham], [gia_san_pham], [so_luong], [don_vi_tinh], [thong_so_ky_thuat], [tinh_trang], [ma_loai_san_pham]) VALUES (N'2', N'máy hút', N'29977700', N'3', N'chiếc', N'ahihi', N'1', N'2')
GO
GO
SET IDENTITY_INSERT [dbo].[san_pham] OFF
GO

-- ----------------------------
-- Procedure structure for proc_backup
-- ----------------------------
GO
create proc [dbo].[proc_backup]
as
Backup database db_sale_management to disk ='c:/SQLBackup/db_sale_management.bak'
GO

-- ----------------------------
-- Indexes structure for table chi_tiet_hoa_don_ban
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table chi_tiet_hoa_don_ban
-- ----------------------------
ALTER TABLE [dbo].[chi_tiet_hoa_don_ban] ADD PRIMARY KEY ([ma_hoa_don], [ma_san_pham])
GO

-- ----------------------------
-- Indexes structure for table chi_tiet_hoa_don_mua
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table chi_tiet_hoa_don_mua
-- ----------------------------
ALTER TABLE [dbo].[chi_tiet_hoa_don_mua] ADD PRIMARY KEY ([ma_hoa_don], [ma_san_pham])
GO

-- ----------------------------
-- Indexes structure for table hoa_don_ban
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table hoa_don_ban
-- ----------------------------
ALTER TABLE [dbo].[hoa_don_ban] ADD PRIMARY KEY ([ma_hoa_don])
GO

-- ----------------------------
-- Indexes structure for table hoa_don_mua
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table hoa_don_mua
-- ----------------------------
ALTER TABLE [dbo].[hoa_don_mua] ADD PRIMARY KEY ([ma_hoa_don])
GO

-- ----------------------------
-- Indexes structure for table khach_hang
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table khach_hang
-- ----------------------------
ALTER TABLE [dbo].[khach_hang] ADD PRIMARY KEY ([ma_khach_hang])
GO

-- ----------------------------
-- Indexes structure for table loai_san_pham
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table loai_san_pham
-- ----------------------------
ALTER TABLE [dbo].[loai_san_pham] ADD PRIMARY KEY ([ma_loai_san_pham])
GO

-- ----------------------------
-- Indexes structure for table nha_cung_cap
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table nha_cung_cap
-- ----------------------------
ALTER TABLE [dbo].[nha_cung_cap] ADD PRIMARY KEY ([ma_nha_cung_cap])
GO

-- ----------------------------
-- Indexes structure for table nhan_vien
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table nhan_vien
-- ----------------------------
ALTER TABLE [dbo].[nhan_vien] ADD PRIMARY KEY ([ma_nhan_vien])
GO

-- ----------------------------
-- Indexes structure for table san_pham
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table san_pham
-- ----------------------------
ALTER TABLE [dbo].[san_pham] ADD PRIMARY KEY ([ma_san_pham])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[chi_tiet_hoa_don_ban]
-- ----------------------------
ALTER TABLE [dbo].[chi_tiet_hoa_don_ban] ADD FOREIGN KEY ([ma_hoa_don]) REFERENCES [dbo].[hoa_don_ban] ([ma_hoa_don]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_ban] ADD FOREIGN KEY ([ma_san_pham]) REFERENCES [dbo].[san_pham] ([ma_san_pham]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[chi_tiet_hoa_don_mua]
-- ----------------------------
ALTER TABLE [dbo].[chi_tiet_hoa_don_mua] ADD FOREIGN KEY ([ma_hoa_don]) REFERENCES [dbo].[hoa_don_mua] ([ma_hoa_don]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[chi_tiet_hoa_don_mua] ADD FOREIGN KEY ([ma_san_pham]) REFERENCES [dbo].[san_pham] ([ma_san_pham]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[hoa_don_ban]
-- ----------------------------
ALTER TABLE [dbo].[hoa_don_ban] ADD FOREIGN KEY ([ma_khach_hang]) REFERENCES [dbo].[khach_hang] ([ma_khach_hang]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[hoa_don_ban] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [dbo].[nhan_vien] ([ma_nhan_vien]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[hoa_don_mua]
-- ----------------------------
ALTER TABLE [dbo].[hoa_don_mua] ADD FOREIGN KEY ([ma_nha_cung_cap]) REFERENCES [dbo].[nha_cung_cap] ([ma_nha_cung_cap]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[san_pham]
-- ----------------------------
ALTER TABLE [dbo].[san_pham] ADD FOREIGN KEY ([ma_loai_san_pham]) REFERENCES [dbo].[loai_san_pham] ([ma_loai_san_pham]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
