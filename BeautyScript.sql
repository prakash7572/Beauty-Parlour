USE [master]
GO
/****** Object:  Database [BeautyParlour]    Script Date: 18-03-2024 09:58:43 ******/
CREATE DATABASE [BeautyParlour]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BeautyParlour', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BeautyParlour.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BeautyParlour_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BeautyParlour_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BeautyParlour] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BeautyParlour].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BeautyParlour] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BeautyParlour] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BeautyParlour] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BeautyParlour] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BeautyParlour] SET ARITHABORT OFF 
GO
ALTER DATABASE [BeautyParlour] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BeautyParlour] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BeautyParlour] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BeautyParlour] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BeautyParlour] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BeautyParlour] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BeautyParlour] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BeautyParlour] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BeautyParlour] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BeautyParlour] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BeautyParlour] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BeautyParlour] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BeautyParlour] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BeautyParlour] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BeautyParlour] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BeautyParlour] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BeautyParlour] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BeautyParlour] SET RECOVERY FULL 
GO
ALTER DATABASE [BeautyParlour] SET  MULTI_USER 
GO
ALTER DATABASE [BeautyParlour] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BeautyParlour] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BeautyParlour] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BeautyParlour] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BeautyParlour] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BeautyParlour] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BeautyParlour', N'ON'
GO
ALTER DATABASE [BeautyParlour] SET QUERY_STORE = ON
GO
ALTER DATABASE [BeautyParlour] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BeautyParlour]
GO
/****** Object:  Table [dbo].[Aboutuses]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aboutuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[SubTitle] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[Image] [varchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[Image] [varchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubTitle] [varchar](max) NULL,
	[Image] [varchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientOpening]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientOpening](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubTitle] [varchar](100) NULL,
	[Description] [varchar](max) NULL,
	[Image] [varchar](100) NULL,
	[Destination] [varchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubTitle] [varchar](100) NULL,
	[Phone] [varchar](15) NULL,
	[Address] [varchar](max) NULL,
	[Email] [varchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Makeups]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makeups](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FaFaImg] [varchar](max) NULL,
	[Title] [varchar](10) NULL,
	[SabTitle] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubTitle] [varchar](100) NULL,
	[Image] [varchar](100) NULL,
	[Description] [varchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[MakeupType] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Price]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Price](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubTitle] [varchar](100) NULL,
	[Makeup] [varchar](100) NULL,
	[Price] [money] NULL,
	[Description] [varchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](10) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[UserName] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](20) NULL,
	[CreatedBy] [datetime2](7) NOT NULL,
	[ModifyBy] [datetime2](7) NULL,
	[Status] [bit] NOT NULL,
	[Image] [varchar](max) NULL,
	[Phone] [varchar](15) NULL,
	[MiddleName] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[SubTitle] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[Image] [varchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Image] [varchar](max) NULL,
	[Description] [varchar](max) NULL,
	[TwitterUrl] [varchar](100) NULL,
	[InstagramUrl] [varchar](100) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [datetime] NULL,
	[ModifyBy] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aboutuses] ADD  DEFAULT ((1)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Profiles] ADD  DEFAULT (getdate()) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[Profiles] ADD  DEFAULT ((1)) FOR [Status]
GO
/****** Object:  StoredProcedure [dbo].[Beauty_SP]    Script Date: 18-03-2024 09:58:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC Beauty_SP @QueryType='GET_ALL_ABOUTUS'
CREATE PROCEDURE [dbo].[Beauty_SP]
(
@ID				INT=0,
@UserName		VARCHAR(100)=NULL,
@Title			VARCHAR(100)=NULL,
@SubTitle		VARCHAR(100)=NULL,
@Description	VARCHAR(100)= NULL,
@Image			NVARCHAR(100)=NULL,
@Phone			VARCHAR(15)=NULL,
@Address		VARCHAR(MAX)=NULL,
@Email			VARCHAR(100)=NULL,
@Password		VARCHAR(100)=NULL,
@NewPassword 	VARCHAR(100)=NULL,
@OldPassword	VARCHAR(100)=NULL,
@Makeup			VARCHAR(100)=NULL,
@InstagramUrl	VARCHAR(100)=NULL,
@TwitterUrl		VARCHAR(100)=NULL,
@FirstName		VARCHAR(100)=NULL,
@MiddleName		VARCHAR(100)=NULL,
@LastName		VARCHAR(100)=NULL,
@FaFaImg		VARCHAR(100)=NULL,
@Destination	VARCHAR(100)=NULL,
@CreatedBy		DATETIME=NULL,
@ModifyBy		DATETIME=NULL,
@Price			MONEY=NULL,
@MakeupType     BIT=0,
@QueryType		VARCHAR(100)=NULL
)
AS
BEGIN 
	  -------------FOR MASSAGE------------
	  DECLARE @OperationMessage    VARCHAR(MAX)
	  DECLARE @ErrorMessage		   VARCHAR(MAX)
	  DECLARE @StatusCode		   VARCHAR(10)
	  DECLARE @OperationStatus	   VARCHAR=1
	  DECLARE @IdentityId		   VARCHAR(200)=NULL
	  --------------USER_LOGIN------------
	  IF(@QueryType='USER_LOGIN')
	  BEGIN
			IF EXISTS (SELECT Email,Password FROM Profiles WHERE Email=@Email AND Password=@Password)
				BEGIN
					 SET @IdentityId=CONVERT(VARCHAR,SCOPE_IDENTITY());SET @StatusCode='SUCCESS';SET @OperationMessage='User Login Successfully !!'
					 SELECT @StatusCode AS StatusCode,@OperationMessage AS OperationMessage,@IdentityId AS IdentityId
				END
			ELSE
				BEGIN
					SET @IdentityId=CONVERT(VARCHAR,SCOPE_IDENTITY());SET @StatusCode='ERROR';SET @ErrorMessage='Invaild Email & Password !!'
					SELECT @StatusCode AS StatusCode,@ErrorMessage AS ErrorMessage,@IdentityId AS IdentityId
				END
	  END
	  ---------------GET_LOGIN_USER_INFO-------
	  IF(@QueryType='GET_LOGIN_INFO')
	  BEGIN
			 SELECT ID AS 'UserId',Title,FirstName,MiddleName,LastName,UserName,Email,Phone,ISNULL(Image,'') AS 'Image'
			 FROM Profiles WHERE Email=@Email AND Password=@Password

			 SELECT 'Makeups' AS Category, COUNT(ID) AS Count FROM Makeups
			 UNION
			 SELECT 'Clients' AS Category, COUNT(ID) AS Count FROM ClientOpening
			 UNION
			 SELECT 'Banners' AS Category, COUNT(ID) AS Count FROM Banner
			 UNION
			 SELECT 'About' AS Category, COUNT(ID) AS Count FROM Aboutuses
			 UNION
			 SELECT 'Service' AS Category, COUNT(ID) AS Count FROM Services
			 UNION
			 SELECT 'News' AS Category, COUNT(ID) AS Count FROM News
			 UNION
			 SELECT 'Contacts' AS Category, COUNT(ID) AS Count FROM Contacts
			 UNION
			 SELECT 'Price' AS Category, COUNT(ID) AS Count FROM Price
			 UNION
			 SELECT 'Brands' AS Category, COUNT(ID) AS Count FROM Brands
			 UNION
			 SELECT 'Teams' AS Category, COUNT(ID) AS Count FROM Teams;
			
	  END
	  --------------UPDATE_PROFILE_INFO---------
	  IF(@QueryType='UPDATE_PROFILE')
	  BEGIN

			UPDATE Profiles SET Title=@Title,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,
			UserName=@UserName,Email=@Email,Phone=@Phone,Image=@Image
			WHERE ID=@ID
	  
	  END
	  --------------CHANGE_PASSWORD---------
	  IF(@QueryType='CHANGE_PASSWORD')
	  BEGIN
			IF EXISTS (SELECT Password FROM Profiles WHERE  Password=@OldPassword AND ID = @ID)
				BEGIN
					 
					 UPDATE Profiles SET Password=@NewPassword WHERE  ID = @ID

					 SET @IdentityId=CONVERT(VARCHAR,SCOPE_IDENTITY());SET @StatusCode='SUCCESS';SET @OperationMessage='Password Update Successfully !!'
					 SELECT @StatusCode AS StatusCode,@OperationMessage AS OperationMessage,@IdentityId AS IdentityId
				END
			ELSE
				BEGIN
					SET @IdentityId=CONVERT(VARCHAR,SCOPE_IDENTITY());SET @StatusCode='ERROR';SET @ErrorMessage='Invaild Password !!'
					SELECT @StatusCode AS StatusCode,@ErrorMessage AS ErrorMessage,@IdentityId AS IdentityId
				END
	  END
      --------------ABOUTUS---------------
	  IF(@QueryType='GET_ALL_ABOUTUS')
	  BEGIN
	     SELECT ID,Title,SubTitle,Description,Image FROM Aboutuses WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_ABOUTUS')
	  BEGIN
	       SELECT ID,Title,SubTitle,Description,Image FROM Aboutuses WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_ABOUTUS')
	  BEGIN
	       INSERT INTO Aboutuses (Title,SubTitle,Description,Image,IsDeleted,CreatedBy) 
		   VALUES(@Title,@SubTitle,@Description,@Image,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_ABOUTUS')
	  BEGIN
	       UPDATE Aboutuses SET Title=@Title,SubTitle=@SubTitle,Description=@Description,Image=@Image,
		   ModifyBy=GETDATE()
		   WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_ABOUTUS')
	  BEGIN
			UPDATE Aboutuses SET IsDeleted=0  WHERE ID=@ID
	  END
	  --------------SERVICES---------------
	  IF(@QueryType='GET_ALL_SERVICES')
	  BEGIN
	     SELECT ID,Title,SubTitle,Description,Image FROM Services WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_SERVICES')
	  BEGIN
	       SELECT ID,Title,SubTitle,Description,Image FROM Services WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_SERVICES')
	  BEGIN
	       INSERT INTO Services (Title,SubTitle,Description,Image,IsDeleted,CreatedBy) 
		   VALUES(@Title,@SubTitle,@Description,@Image,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_SERVICES')
	  BEGIN
	       UPDATE Services SET Title=@Title,SubTitle=@SubTitle,Description=@Description,Image=@Image, 
		   ModifyBy=GetDate() WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_SERVICES')
	  BEGIN
	        UPDATE Services SET IsDeleted=0 WHERE ID=@ID
	  END
	  --------------CONTACTS---------------
	  IF(@QueryType='GET_ALL_CONTACTS')
	  BEGIN
	     SELECT ID,SubTitle,Phone,Address,Email FROM Contacts WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_CONTACTS')
	  BEGIN
	     SELECT ID,SubTitle,Phone,Address,Email FROM Contacts WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_CONTACTS')
	  BEGIN
	       INSERT INTO Contacts (SubTitle,Phone,Address,Email,IsDeleted,CreatedBy) 
		   VALUES(@SubTitle,@Phone,@Address,@Email,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_CONTACTS')
	  BEGIN
	       UPDATE Contacts SET SubTitle=@SubTitle,Phone=@Phone,Address=@Address,Email=@Email,
		   CreatedBy=GETDATE() WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_CONTACTS')
	  BEGIN
			 UPDATE Contacts SET IsDeleted=0 WHERE ID=@ID
	  END
	  --------------NEWS---------------
	  IF(@QueryType='GET_ALL_NEWS')
	  BEGIN
	     SELECT ID,SubTitle,Image,Description,MakeupType FROM News WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_NEWS')
	  BEGIN
	      SELECT ID,SubTitle,Image,Description,MakeupType FROM News WHERE ID=@ID AND  IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_NEWS')
	  BEGIN
	       INSERT INTO News (SubTitle,Image,Description,MakeupType,IsDeleted,CreateDate) 
		   VALUES(@SubTitle,@Image,@Description,@MakeupType,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_NEWS')
	  BEGIN
	       UPDATE News SET SubTitle=@SubTitle,Image=@Image,Description=@SubTitle,MakeupType=@MakeupType,
		   ModifyBy=GETDATE() WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_NEWS')
	  BEGIN
			 UPDATE News SET IsDeleted=0 WHERE ID=@ID
	  END
	  ------------- PRICES ----------------
	  IF(@QueryType='GET_ALL_PRICE')
	  BEGIN
	     SELECT ID,SubTitle,Makeup,Price,Description FROM Price WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_PRICE')
	  BEGIN
	     SELECT ID,SubTitle,Makeup,Price,Description FROM Price WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_PRICE')
	  BEGIN
	       INSERT INTO Price (SubTitle,Makeup,Price,Description,IsDeleted,CreatedBy) 
		   VALUES(@SubTitle,@Makeup,@Price,@Description,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_PRICE')
	  BEGIN
	       UPDATE Price SET SubTitle=@SubTitle,Makeup=@Makeup,Price=@Price,Description=@Description,
		   ModifyBy=GETDATE() WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_PRICE')
	  BEGIN
			 UPDATE Price SET IsDeleted=0 WHERE ID=@ID
	  END
	  ---------------MAKEUP -----------------
	  IF(@QueryType='GET_ALL_MAKEUP')
	  BEGIN
	     SELECT ID,Title,FaFaImg,Description FROM Makeups WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_MAKEUP')
	  BEGIN
	     SELECT ID,Title,FaFaImg,Description FROM Makeups WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_MAKEUP')
	  BEGIN
	       INSERT INTO Makeups (Title,FaFaImg,Description,IsDeleted,CreatedBy) 
		   VALUES(@Title,@FaFaImg,@Description,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_MAKEUP')
	  BEGIN
	       UPDATE Makeups SET Title=@Title,FaFaImg=@FaFaImg,Description=@Description,ModifyBy=GETDATE()
		   WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_MAKEUP')
	  BEGIN
			UPDATE Makeups SET IsDeleted=0 WHERE ID=@ID
	  END
	  -------------- TEAMS----------------
	  IF(@QueryType='GET_ALL_TEAM')
	  BEGIN
	     SELECT ID,Title,FirstName,MiddleName,LastName,Image,Description,TwitterUrl,InstagramUrl
		 FROM Teams WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_TEAM')
	  BEGIN
		 SELECT ID,Title,FirstName,MiddleName,LastName,Image,Description,TwitterUrl,InstagramUrl
		 FROM Teams WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_TEAM')
	  BEGIN
	       INSERT INTO Teams (Title,FirstName,MiddleName,LastName,Image,Description,TwitterUrl,InstagramUrl,IsDeleted,CreatedBy)
		   VALUES(@Title,@FirstName,@MiddleName,@LastName,@Image,@Description,@TwitterUrl,@InstagramUrl,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_TEAM')
	  BEGIN
	       UPDATE Teams SET Title=@Title,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,
		   Image=@Image,Description=@Description,TwitterUrl=@TwitterUrl,InstagramUrl=@InstagramUrl,
		   ModifyBy=GETDATE() WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_TEAM')
	  BEGIN
			UPDATE Teams SET IsDeleted=0 WHERE ID=@ID
	  END
	  ------------------BANNER ------------
	  IF(@QueryType='GET_ALL_BANNER')
	  BEGIN
	     SELECT ID,Title,Image FROM Banner WHERE  IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_BANNER')
	  BEGIN
			SELECT ID,Title,Image FROM Banner  WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_BANNER')
	  BEGIN
	       INSERT INTO Banner (Title,Image,IsDeleted,CreatedBy)
		   VALUES(@Title,@Image,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_BANNER')
	  BEGIN
	       UPDATE Banner SET Title=@Title,Image=@Image,ModifyBy=GETDATE() WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_BANNER')
	  BEGIN
			 UPDATE Banner SET IsDeleted=0 WHERE ID=@ID
	  END
      ------------------CLIENT_OPENING ------------
	  IF(@QueryType='GET_ALL_CLIENT')
	  BEGIN
	     SELECT ID,SubTitle,Image,Description,Destination FROM ClientOpening WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_CLIENT')
	  BEGIN
		 SELECT ID,SubTitle,Image,Description,Destination FROM ClientOpening WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_CLIENT')
	  BEGIN
	       INSERT INTO ClientOpening (SubTitle,Image,Description,Destination,IsDeleted,CreatedBy) 
		   VALUES(@SubTitle,@Image,@Description,@Destination,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_CLIENT')
	  BEGIN
	       UPDATE ClientOpening SET SubTitle=@SubTitle,Image=@Image,Description=@Description,
		   Destination=@Destination,ModifyBy=GETDATE() WHERE ID=@ID 
	  END
	  ELSE IF(@QueryType='DELETE_CLIENT')
	  BEGIN
			UPDATE ClientOpening SET IsDeleted=0 WHERE ID=@ID
	  END
	   ------------------BRANDS ------------
	  IF(@QueryType='GET_ALL_BRAND')
	  BEGIN
	     SELECT ID,SubTitle,Image FROM Brands WHERE IsDeleted=1
	  END
	  ELSE IF(@QueryType='GET_BRAND')
	  BEGIN
		SELECT ID,SubTitle,Image FROM Brands WHERE ID=@ID AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='ADD_BRAND')
	  BEGIN
	       INSERT INTO Brands (SubTitle,Image,IsDeleted,CreatedBy) VALUES(@SubTitle,@Image,1,GETDATE())
	  END
	  ELSE IF(@QueryType='UPDATE_BRAND')
	  BEGIN
	       UPDATE Brands SET SubTitle=@SubTitle,Image=@Image WHERE ID=@ID  AND IsDeleted=1
	  END
	  ELSE IF(@QueryType='DELETE_BRAND')
	  BEGIN
			 UPDATE Brands SET IsDeleted=0 WHERE ID=@ID
	  END


END
GO
USE [master]
GO
ALTER DATABASE [BeautyParlour] SET  READ_WRITE 
GO
