USE [master]
GO
/****** Object:  Database [EduHomeProject]    Script Date: 7/6/2020 11:27:22 PM ******/
CREATE DATABASE [EduHomeProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EduHomeProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EduHomeProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EduHomeProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\EduHomeProject_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EduHomeProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EduHomeProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EduHomeProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EduHomeProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EduHomeProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EduHomeProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EduHomeProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [EduHomeProject] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EduHomeProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EduHomeProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EduHomeProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EduHomeProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EduHomeProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EduHomeProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EduHomeProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EduHomeProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EduHomeProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EduHomeProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EduHomeProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EduHomeProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EduHomeProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EduHomeProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EduHomeProject] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EduHomeProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EduHomeProject] SET RECOVERY FULL 
GO
ALTER DATABASE [EduHomeProject] SET  MULTI_USER 
GO
ALTER DATABASE [EduHomeProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EduHomeProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EduHomeProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EduHomeProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EduHomeProject] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EduHomeProject', N'ON'
GO
ALTER DATABASE [EduHomeProject] SET QUERY_STORE = OFF
GO
USE [EduHomeProject]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Abouts]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Abouts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WelcomeMessage1] [nvarchar](500) NOT NULL,
	[WelcomeMessage2] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[Title1] [nvarchar](20) NOT NULL,
	[Title2] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_dbo.Abouts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Firstname] [nvarchar](30) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](150) NULL,
 CONSTRAINT [PK_dbo.Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BGImages]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BGImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TItle] [nvarchar](50) NOT NULL,
	[Page] [nvarchar](20) NOT NULL,
	[Image] [nvarchar](150) NULL,
 CONSTRAINT [PK_dbo.BGImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogCategories]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_dbo.BlogCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blogs]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Image] [nvarchar](150) NULL,
	[Content] [ntext] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReplyCount] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[BlogCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commons]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](150) NOT NULL,
	[Phone1] [nvarchar](50) NOT NULL,
	[Phone2] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[LogoFooter] [nvarchar](150) NULL,
	[LogoHeader] [nvarchar](150) NULL,
	[BookLogoWhite] [nvarchar](150) NULL,
	[BookLogoRed] [nvarchar](150) NULL,
	[Site] [nvarchar](50) NOT NULL,
	[Video] [nvarchar](250) NOT NULL,
	[ImageVBG] [nvarchar](150) NULL,
	[Image] [nvarchar](250) NULL,
	[Slogan] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Commons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NULL,
	[AddressLogo1] [nvarchar](150) NULL,
	[AddressLogo2] [nvarchar](150) NULL,
	[PhoneLogo] [nvarchar](150) NULL,
	[Address3] [nvarchar](100) NULL,
 CONSTRAINT [PK_dbo.Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseCategories]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_dbo.CourseCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Image] [nvarchar](150) NULL,
	[Content] [ntext] NOT NULL,
	[Link] [nvarchar](150) NOT NULL,
	[StartDate] [nvarchar](30) NOT NULL,
	[CourseDuration] [tinyint] NOT NULL,
	[ClassDuration] [tinyint] NOT NULL,
	[SkillLevel] [nvarchar](20) NOT NULL,
	[Language] [nvarchar](20) NOT NULL,
	[StudentsCount] [int] NOT NULL,
	[Assessments] [nvarchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CourseCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Courses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventCategories]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Content] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_dbo.EventCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Image] [nvarchar](150) NULL,
	[Content] [ntext] NOT NULL,
	[EventDate] [nvarchar](20) NOT NULL,
	[EventTime] [nvarchar](20) NOT NULL,
	[EventVenue] [nvarchar](20) NOT NULL,
	[Link] [nvarchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[EventCategoryId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventSpeakers]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventSpeakers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpeakerId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.EventSpeakers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](30) NOT NULL,
	[Text] [nvarchar](150) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UserId] [int] NULL,
	[BlogId] [int] NULL,
	[EventId] [int] NULL,
	[CourseId] [int] NULL,
	[ContactId] [int] NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_dbo.Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Positions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Progress] [tinyint] NOT NULL,
 CONSTRAINT [PK_dbo.Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Text] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](150) NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialCommons]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialCommons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Icon] [nvarchar](20) NOT NULL,
	[Link] [nvarchar](150) NOT NULL,
	[CommonId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SocialCommons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialTeachers]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialTeachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Icon] [nvarchar](20) NOT NULL,
	[Link] [nvarchar](150) NOT NULL,
	[TeacherId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SocialTeachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Speakers]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Speakers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Speakers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscribes]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscribes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Subscribes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](150) NULL,
	[About] [nvarchar](500) NOT NULL,
	[Degree] [nvarchar](20) NOT NULL,
	[Experience] [nvarchar](20) NOT NULL,
	[Hobbies] [nvarchar](100) NOT NULL,
	[Faculty] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](20) NULL,
	[Skype] [nvarchar](30) NULL,
	[PositionId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherSkills]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[SkillId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.TeacherSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestMorials]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestMorials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[ImageBG] [nvarchar](250) NULL,
	[Text] [nvarchar](250) NOT NULL,
	[Fullname] [nvarchar](50) NOT NULL,
	[Occupation] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_dbo.TestMorials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/6/2020 11:27:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Image] [nvarchar](150) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Firstname] [nvarchar](30) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogCategoryId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlogCategoryId] ON [dbo].[Blogs]
(
	[BlogCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Blogs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseCategoryId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseCategoryId] ON [dbo].[Courses]
(
	[CourseCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EventCategoryId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_EventCategoryId] ON [dbo].[Events]
(
	[EventCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EventId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_EventId] ON [dbo].[EventSpeakers]
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SpeakerId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_SpeakerId] ON [dbo].[EventSpeakers]
(
	[SpeakerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_BlogId] ON [dbo].[Messages]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ContactId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ContactId] ON [dbo].[Messages]
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CourseId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_CourseId] ON [dbo].[Messages]
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_EventId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_EventId] ON [dbo].[Messages]
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Messages]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CommonId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_CommonId] ON [dbo].[SocialCommons]
(
	[CommonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[SocialTeachers]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PositionId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_PositionId] ON [dbo].[Teachers]
(
	[PositionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SkillId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_SkillId] ON [dbo].[TeacherSkills]
(
	[SkillId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherId]    Script Date: 7/6/2020 11:27:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherId] ON [dbo].[TeacherSkills]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Abouts] ADD  DEFAULT ('') FOR [Title1]
GO
ALTER TABLE [dbo].[Abouts] ADD  DEFAULT ('') FOR [Title2]
GO
ALTER TABLE [dbo].[Admins] ADD  DEFAULT ('') FOR [Firstname]
GO
ALTER TABLE [dbo].[Admins] ADD  DEFAULT ('') FOR [Lastname]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT ('') FOR [Name]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT ('') FOR [Email]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('') FOR [Firstname]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('') FOR [Lastname]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Blogs_dbo.BlogCategories_BlogCategoryId] FOREIGN KEY([BlogCategoryId])
REFERENCES [dbo].[BlogCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_dbo.Blogs_dbo.BlogCategories_BlogCategoryId]
GO
ALTER TABLE [dbo].[Blogs]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Blogs_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Blogs] CHECK CONSTRAINT [FK_dbo.Blogs_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Courses_dbo.CourseCategories_CourseCategoryId] FOREIGN KEY([CourseCategoryId])
REFERENCES [dbo].[CourseCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_dbo.Courses_dbo.CourseCategories_CourseCategoryId]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Events_dbo.EventCategories_EventCategoryId] FOREIGN KEY([EventCategoryId])
REFERENCES [dbo].[EventCategories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_dbo.Events_dbo.EventCategories_EventCategoryId]
GO
ALTER TABLE [dbo].[EventSpeakers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventSpeakers_dbo.Events_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventSpeakers] CHECK CONSTRAINT [FK_dbo.EventSpeakers_dbo.Events_EventId]
GO
ALTER TABLE [dbo].[EventSpeakers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EventSpeakers_dbo.Speakers_SpeakerId] FOREIGN KEY([SpeakerId])
REFERENCES [dbo].[Speakers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EventSpeakers] CHECK CONSTRAINT [FK_dbo.EventSpeakers_dbo.Speakers_SpeakerId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.Blogs_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blogs] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.Blogs_BlogId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.Contacts_ContactId] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.Contacts_ContactId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.Courses_CourseId] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.Courses_CourseId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.Events_EventId] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.Events_EventId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Messages_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_dbo.Messages_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[SocialCommons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SocialCommons_dbo.Commons_CommonId] FOREIGN KEY([CommonId])
REFERENCES [dbo].[Commons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SocialCommons] CHECK CONSTRAINT [FK_dbo.SocialCommons_dbo.Commons_CommonId]
GO
ALTER TABLE [dbo].[SocialTeachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SocialTeachers_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SocialTeachers] CHECK CONSTRAINT [FK_dbo.SocialTeachers_dbo.Teachers_TeacherId]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Teachers_dbo.Positions_PositionId] FOREIGN KEY([PositionId])
REFERENCES [dbo].[Positions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_dbo.Teachers_dbo.Positions_PositionId]
GO
ALTER TABLE [dbo].[TeacherSkills]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeacherSkills_dbo.Skills_SkillId] FOREIGN KEY([SkillId])
REFERENCES [dbo].[Skills] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSkills] CHECK CONSTRAINT [FK_dbo.TeacherSkills_dbo.Skills_SkillId]
GO
ALTER TABLE [dbo].[TeacherSkills]  WITH CHECK ADD  CONSTRAINT [FK_dbo.TeacherSkills_dbo.Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSkills] CHECK CONSTRAINT [FK_dbo.TeacherSkills_dbo.Teachers_TeacherId]
GO
USE [master]
GO
ALTER DATABASE [EduHomeProject] SET  READ_WRITE 
GO
