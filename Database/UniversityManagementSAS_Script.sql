--USE [Master]
--USE [UniversityManagementSAS]
--GO

/****** Object:  Database [UniversityManagementSAS]    Script Date: 12/20/2018 19:15:14 ******/
--CREATE DATABASE [UniversityManagementSAS] ON  PRIMARY 
--( NAME = N'UniversityManagementSAS', FILENAME = N'D:\Srb\CSharp\UCRMS\Database\UniversityManagementSAS.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'UniversityManagementSAS_log', FILENAME = N'D:\Srb\CSharp\UCRMS\Database\UniversityManagementSAS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
--GO

ALTER DATABASE [UniversityManagementSAS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagementSAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagementSAS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET ARITHABORT OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [UniversityManagementSAS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [UniversityManagementSAS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [UniversityManagementSAS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET  DISABLE_BROKER
GO
ALTER DATABASE [UniversityManagementSAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [UniversityManagementSAS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [UniversityManagementSAS] SET  READ_WRITE
GO
ALTER DATABASE [UniversityManagementSAS] SET RECOVERY FULL
GO
ALTER DATABASE [UniversityManagementSAS] SET  MULTI_USER
GO
ALTER DATABASE [UniversityManagementSAS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [UniversityManagementSAS] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'UniversityManagementSAS', N'ON'
GO
USE [UniversityManagementSAS]
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Designation] ON
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (3, N'Associate Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (4, N'Lecturer')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (5, N'Teaching Assistant')
SET IDENTITY_INSERT [dbo].[Designation] OFF
/****** Object:  Table [dbo].[Department]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](7) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Department_Code] UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Department_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science & Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2, N'EEE', N'Electrical & Electronics Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (3, N'CE', N'Civil Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (4, N'ME', N'Mechanical Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (6, N'Pharm', N'Pharmacy')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (7, N'ELL', N'English Language & Literature')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (8, N'MATH', N'Mathematics')
SET IDENTITY_INSERT [dbo].[Department] OFF
/****** Object:  Table [dbo].[Room]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Room] ON
INSERT [dbo].[Room] ([Id], [Name]) VALUES (1, N'S-101')
INSERT [dbo].[Room] ([Id], [Name]) VALUES (2, N'S-102')
INSERT [dbo].[Room] ([Id], [Name]) VALUES (3, N'A-101')
INSERT [dbo].[Room] ([Id], [Name]) VALUES (4, N'A-102')
INSERT [dbo].[Room] ([Id], [Name]) VALUES (5, N'SX-401')
INSERT [dbo].[Room] ([Id], [Name]) VALUES (6, N'SX-402')
SET IDENTITY_INSERT [dbo].[Room] OFF
/****** Object:  Table [dbo].[Grade]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Grade] ON
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (4, N'B+')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (5, N'B')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (6, N'B-')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (7, N'C+')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (8, N'C')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (9, N'C-')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (10, N'D+')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (11, N'D')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (12, N'D-')
INSERT [dbo].[Grade] ([Id], [Name]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grade] OFF
/****** Object:  Table [dbo].[Semester]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Semester] ON
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
/****** Object:  Table [dbo].[WeekDay]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WeekDay](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_WeekDay] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[WeekDay] ON
INSERT [dbo].[WeekDay] ([Id], [Name]) VALUES (1, N'Sat')
INSERT [dbo].[WeekDay] ([Id], [Name]) VALUES (2, N'Sun')
INSERT [dbo].[WeekDay] ([Id], [Name]) VALUES (3, N'Mon')
INSERT [dbo].[WeekDay] ([Id], [Name]) VALUES (4, N'Tue')
INSERT [dbo].[WeekDay] ([Id], [Name]) VALUES (5, N'Wed')
INSERT [dbo].[WeekDay] ([Id], [Name]) VALUES (6, N'Thu')
INSERT [dbo].[WeekDay] ([Id], [Name]) VALUES (7, N'Fri')
SET IDENTITY_INSERT [dbo].[WeekDay] OFF
/****** Object:  Table [dbo].[Student]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[RegDate] [varchar](50) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RegNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE UNIQUE NONCLUSTERED INDEX [UK_Student] ON [dbo].[Student] 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (1, N'Abbas', N'abbas@gmail.com', N'01823456789', N'2018-12-09', N'chawk', 1, N'CSE-2018-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (2, N'Ali', N'ali@gmail.com', N'01723456789', N'2018-12-09', N'chawk', 1, N'CSE-2018-002')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (3, N'Khan', N'khan@gmail.com', N'01623456789', N'2018-12-10', N'anderkilla', 2, N'EEE-2018-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (4, N'KhanAli', N'khanali@gmail.com', N'01653456789', N'2018-12-12', N'Banderkilla', 3, N'ETE-2018-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (5, N'Shresta Biswas', N'shrestabiswas@gmail.com', N'+8801823971551', N'2018-11-18', N'Chawk', 1, N'CSE-2018-003')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (6, N'Shresta Biswas', N'shresta@gmail.com', N'+8801823971551', N'2018-11-18', N'jhg', 1, N'CSE-2018-004')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (7, N'Ayon Biswas', N'ayon@gmail.com', N'+8801823971551', N'2018-11-18', N'assdsd', 1, N'CSE-2018-005')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (8, N'Ayon Biswas', N'ayonkhan@gmail.com', N'+8801723971551', N'2019-01-01', N'assdsd', 1, N'CSE-2017-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (9, N'monkey ayon', N'monkey@gmail.com', N'+8801723971550', N'2019-01-02', N'chawk', 1, N'CSE-2017-002')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (10, N'Bipul Biswas', N'bipul@gmail.com', N'+8801829971551', N'2018-11-18', N'askjgh', 1, N'CSE-2018-006')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (11, N'Shahadat Biswas', N'shahadat@gmail.com', N'+8801823971551', N'2018-11-18', N'kg', 1, N'CSE-2018-007')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (12, N'Shahadat Biswas', N'biswas@gmail.com', N'+8801673971551', N'2018-11-18', N'chek', 1, N'CSE-2018-008')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (13, N'lal miya', N'lal@gmail.com', N'+8801723971578', N'2018-11-18', N'kjhg', 2, N'EEE-2018-002')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (14, N'Jahedul Houque', N'jahed@gmail.com', N'+8801523971551', N'2018-11-18', N'muradpur', 1, N'CSE-2018-009')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (15, N'Jahedul Houque', N'jahed@ymail.com', N'+8801623971451', N'2018-11-18', N'asdfg', 1, N'CSE-2018-010')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (16, N'Jahedul Houqe Tuku', N'jahed@yahoo.com', N'+8801829071552', N'2018-11-20', N'Muradpur', 1, N'CSE-2018-011')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [RegDate], [Address], [DepartmentId], [RegNo]) VALUES (17, N'Shadat Hossain', N'shadat@gmail.com', N'+8801723901578', N'2018-12-20', N'Muradpur', 1, N'CSE-2018-012')
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditToBeTaken] [decimal](5, 2) NOT NULL,
	[RemainingCredit] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (4, N'Tayeb', N'shjk', N'akjs@kjnas.com', N'+8801823971551', 1, 1, CAST(15.00 AS Decimal(5, 2)), CAST(15.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (6, N'Shresta', N'Chawkbazar', N'sh@gmail.com', N'09876543211', 2, 2, CAST(12.00 AS Decimal(5, 2)), CAST(12.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (7, N'Avishek', N'Chawkbazar', N'avi@gm.com', N'01892345617', 3, 3, CAST(20.00 AS Decimal(5, 2)), CAST(20.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (8, N'Avishek Ayon', N'Chawkbazar', N'aviA@gm.com', N'01892345619', 3, 3, CAST(20.00 AS Decimal(5, 2)), CAST(20.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (9, N'Tayeb Ali', N'CTG', N'asd@hmau.com', N'98674678', 2, 1, CAST(21.00 AS Decimal(5, 2)), CAST(21.00 AS Decimal(5, 2)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken], [RemainingCredit]) VALUES (10, N'Shahadat Hossain', N'Chawkbazar', N'shahadathossain@gmail.com', N'+8801723901078', 1, 1, CAST(3.00 AS Decimal(5, 2)), CAST(3.00 AS Decimal(5, 2)))
SET IDENTITY_INSERT [dbo].[Teacher] OFF
/****** Object:  Table [dbo].[Course]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Credit] [decimal](5, 2) NOT NULL,
	[Description] [varchar](200) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [UK_Course_Code] ON [dbo].[Course] 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [UK_Course_Name] ON [dbo].[Course] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Course] ON
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (1, N'CSE-1101', N'Computer Fundamental', CAST(2.00 AS Decimal(5, 2)), N'Computer Fundamental', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (2, N'EEE-1101', N'Electronics Fundamental', CAST(2.00 AS Decimal(5, 2)), N'Electonics Fundamental', 2, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (3, N'ME-101', N'Mechanical Fundamental', CAST(3.00 AS Decimal(5, 2)), N'Mechanical', 4, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (4, N'CSE-1201', N'C Lang', CAST(3.00 AS Decimal(5, 2)), N'C Languange', 1, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (5, N'EEE-1201', N'Basic Drives', CAST(3.00 AS Decimal(5, 2)), N'Drives', 2, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (6, N'Math-1101', N'Basic Mathematics', CAST(2.00 AS Decimal(5, 2)), N'Basic Mathematics', 8, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (7, N'CSE-2301', N'C++', CAST(3.00 AS Decimal(5, 2)), N'C++', 1, 3)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (8, N'CSE-2401', N'Java', CAST(3.00 AS Decimal(5, 2)), N'Java', 1, 4)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartmentId], [SemesterId]) VALUES (9, N'CSE-2402', N'Java Sessional', CAST(2.00 AS Decimal(5, 2)), N'Java Lab', 1, 4)
SET IDENTITY_INSERT [dbo].[Course] OFF
/****** Object:  Table [dbo].[AssignedCourseToTeacher]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignedCourseToTeacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[TeacherId] [int] NULL,
	[Assigned] [int] NOT NULL,
 CONSTRAINT [PK_AssignCourseToTeacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AssignedCourseToTeacher] ON
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (2, 1, 4, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (14, 2, 6, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (16, 4, 9, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (17, 1, 4, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (18, 1, 4, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (19, 1, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (20, 4, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (21, 7, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (22, 8, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (23, 9, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (24, 1, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (25, 4, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (26, 8, 10, 0)
INSERT [dbo].[AssignedCourseToTeacher] ([Id], [CourseId], [TeacherId], [Assigned]) VALUES (27, 7, 10, 0)
SET IDENTITY_INSERT [dbo].[AssignedCourseToTeacher] OFF
/****** Object:  Table [dbo].[AllocatedClassRoom]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AllocatedClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[WeekDayId] [int] NULL,
	[FromTime] [varchar](50) NULL,
	[ToTime] [varchar](50) NULL,
	[Allocated] [int] NOT NULL,
 CONSTRAINT [PK_AllocateClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AllocatedClassRoom] ON
INSERT [dbo].[AllocatedClassRoom] ([Id], [CourseId], [RoomId], [WeekDayId], [FromTime], [ToTime], [Allocated]) VALUES (3, 1, 1, 1, N'12:00 AM', N'12:30 AM', 0)
INSERT [dbo].[AllocatedClassRoom] ([Id], [CourseId], [RoomId], [WeekDayId], [FromTime], [ToTime], [Allocated]) VALUES (4, 1, 3, 2, N'11:00 AM', N'12:00 PM', 0)
INSERT [dbo].[AllocatedClassRoom] ([Id], [CourseId], [RoomId], [WeekDayId], [FromTime], [ToTime], [Allocated]) VALUES (5, 1, 3, 3, N'1:30 AM', N'2:30 AM', 0)
SET IDENTITY_INSERT [dbo].[AllocatedClassRoom] OFF
/****** Object:  Table [dbo].[EnrolledCourseToStudent]    Script Date: 12/20/2018 19:15:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EnrolledCourseToStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[EnrolledDate] [varchar](50) NOT NULL,
	[GradeId] [int] NULL,
	[Assigned] [int] NOT NULL,
 CONSTRAINT [PK_EnrollCourseToStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EnrolledCourseToStudent] ON
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (2, 1, 1, N'2018-12-09', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (3, 1, 1, N'2018-12-09', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (4, 1, 4, N'2018-12-13', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (5, 2, 3, N'2018-12-13', 4, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (6, 1, 3, N'2018-12-14', NULL, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (7, 1, 1, N'2018-11-18', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (8, 2, 1, N'2018-11-18', 2, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (9, 1, 1, N'2018-11-19', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (10, 2, 1, N'2018-11-19', 2, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (11, 3, 2, N'2018-11-19', NULL, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (12, 3, 5, N'2018-11-19', NULL, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (13, 1, 1, N'2018-11-20', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (14, 2, 1, N'2018-11-20', 2, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (15, 1, 4, N'2018-11-20', NULL, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (16, 2, 4, N'2018-11-20', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (17, 8, 1, N'2018-11-20', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (18, 8, 4, N'2018-11-20', 1, 0)
INSERT [dbo].[EnrolledCourseToStudent] ([Id], [StudentId], [CourseId], [EnrolledDate], [GradeId], [Assigned]) VALUES (19, 9, 4, N'2018-11-20', NULL, 0)
SET IDENTITY_INSERT [dbo].[EnrolledCourseToStudent] OFF
/****** Object:  View [dbo].[StudentCourseDetailsView]    Script Date: 12/20/2018 19:15:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentCourseDetailsView]
AS
SELECT     dbo.EnrolledCourseToStudent.Id, dbo.EnrolledCourseToStudent.StudentId, dbo.Student.RegNo, dbo.Student.Name AS StudentName, dbo.Student.Email, dbo.Department.Name AS Department, 
                      dbo.Course.Id AS CourseId, dbo.Course.Code, dbo.Course.Name AS CourseName, dbo.Grade.Name AS Grade, dbo.EnrolledCourseToStudent.Assigned
FROM         dbo.EnrolledCourseToStudent INNER JOIN
                      dbo.Student ON dbo.EnrolledCourseToStudent.StudentId = dbo.Student.Id INNER JOIN
                      dbo.Department ON dbo.Student.DepartmentId = dbo.Department.Id LEFT OUTER JOIN
                      dbo.Course ON dbo.Department.Id = dbo.Course.DepartmentId AND dbo.EnrolledCourseToStudent.CourseId = dbo.Course.Id LEFT OUTER JOIN
                      dbo.Grade ON dbo.EnrolledCourseToStudent.GradeId = dbo.Grade.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[25] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "EnrolledCourseToStudent"
            Begin Extent = 
               Top = 3
               Left = 223
               Bottom = 195
               Right = 383
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Student"
            Begin Extent = 
               Top = 5
               Left = 571
               Bottom = 211
               Right = 731
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 7
               Left = 785
               Bottom = 112
               Right = 945
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 201
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Grade"
            Begin Extent = 
               Top = 109
               Left = 401
               Bottom = 199
               Right = 561
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseDetailsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseDetailsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCourseDetailsView'
GO
/****** Object:  View [dbo].[ScheduleInformation]    Script Date: 12/20/2018 19:15:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ScheduleInformation]
AS
SELECT     dbo.Course.DepartmentId, dbo.Course.Code, dbo.Course.Name, dbo.Room.Name AS Room, dbo.WeekDay.Name AS Day, dbo.AllocatedClassRoom.FromTime, dbo.AllocatedClassRoom.ToTime
FROM         dbo.Course LEFT OUTER JOIN
                      dbo.AllocatedClassRoom ON dbo.Course.Id = dbo.AllocatedClassRoom.CourseId LEFT OUTER JOIN
                      dbo.Room ON dbo.AllocatedClassRoom.RoomId = dbo.Room.Id LEFT OUTER JOIN
                      dbo.WeekDay ON dbo.AllocatedClassRoom.WeekDayId = dbo.WeekDay.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Course"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 173
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "AllocatedClassRoom"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 167
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Room"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 102
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WeekDay"
            Begin Extent = 
               Top = 102
               Left = 454
               Bottom = 198
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ScheduleInformation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ScheduleInformation'
GO
/****** Object:  View [dbo].[CourseStatisticsView]    Script Date: 12/20/2018 19:15:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CourseStatisticsView]
AS
SELECT        dbo.Course.Code, dbo.Course.Name, dbo.Semester.Name AS Semester, dbo.Teacher.Name AS AssignedTo, dbo.AssignedCourseToTeacher.Assigned, dbo.Course.DepartmentId
FROM            dbo.Course LEFT OUTER JOIN
                         dbo.AssignedCourseToTeacher ON dbo.Course.Id = dbo.AssignedCourseToTeacher.CourseId LEFT OUTER JOIN
                         dbo.Semester ON dbo.Course.SemesterId = dbo.Semester.Id LEFT OUTER JOIN
                         dbo.Teacher ON dbo.AssignedCourseToTeacher.TeacherId = dbo.Teacher.Id
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Course"
            Begin Extent = 
               Top = 0
               Left = 273
               Bottom = 120
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "AssignedCourseToTeacher"
            Begin Extent = 
               Top = 3
               Left = 510
               Bottom = 210
               Right = 670
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Semester"
            Begin Extent = 
               Top = 15
               Left = 15
               Bottom = 142
               Right = 175
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Teacher"
            Begin Extent = 
               Top = 4
               Left = 781
               Bottom = 216
               Right = 952
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseStatisticsView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CourseStatisticsView'
GO
/****** Object:  Default [DF_AssignedCourseToTeacher_Assigned]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[AssignedCourseToTeacher] ADD  CONSTRAINT [DF_AssignedCourseToTeacher_Assigned]  DEFAULT ((1)) FOR [Assigned]
GO
/****** Object:  Default [DF_AllocatedClassRoom_Allocated]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[AllocatedClassRoom] ADD  CONSTRAINT [DF_AllocatedClassRoom_Allocated]  DEFAULT ((1)) FOR [Allocated]
GO
/****** Object:  Default [DF_EnrolledCourseToStudent_Assigned]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[EnrolledCourseToStudent] ADD  CONSTRAINT [DF_EnrolledCourseToStudent_Assigned]  DEFAULT ((1)) FOR [Assigned]
GO
/****** Object:  ForeignKey [FK_Student_Department]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
/****** Object:  ForeignKey [FK_Teacher_Department]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
/****** Object:  ForeignKey [FK_Teacher_Designation]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
/****** Object:  ForeignKey [FK_Course_Department]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
/****** Object:  ForeignKey [FK_Course_Semester]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
/****** Object:  ForeignKey [FK_AssignCourseToTeacher_Course]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[AssignedCourseToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_AssignCourseToTeacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AssignedCourseToTeacher] CHECK CONSTRAINT [FK_AssignCourseToTeacher_Course]
GO
/****** Object:  ForeignKey [FK_AssignCourseToTeacher_Teacher]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[AssignedCourseToTeacher]  WITH CHECK ADD  CONSTRAINT [FK_AssignCourseToTeacher_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[AssignedCourseToTeacher] CHECK CONSTRAINT [FK_AssignCourseToTeacher_Teacher]
GO
/****** Object:  ForeignKey [FK_AllocateClassRoom_Course]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[AllocatedClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AllocatedClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Course]
GO
/****** Object:  ForeignKey [FK_AllocateClassRoom_Room]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[AllocatedClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([Id])
GO
ALTER TABLE [dbo].[AllocatedClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Room]
GO
/****** Object:  ForeignKey [FK_AllocateClassRoom_WeekDay]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[AllocatedClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_WeekDay] FOREIGN KEY([WeekDayId])
REFERENCES [dbo].[WeekDay] ([Id])
GO
ALTER TABLE [dbo].[AllocatedClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_WeekDay]
GO
/****** Object:  ForeignKey [FK_EnrollCourseToStudent_Course]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[EnrolledCourseToStudent]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourseToStudent_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[EnrolledCourseToStudent] CHECK CONSTRAINT [FK_EnrollCourseToStudent_Course]
GO
/****** Object:  ForeignKey [FK_EnrollCourseToStudent_Student]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[EnrolledCourseToStudent]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourseToStudent_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[EnrolledCourseToStudent] CHECK CONSTRAINT [FK_EnrollCourseToStudent_Student]
GO
/****** Object:  ForeignKey [FK_EnrolledCourseToStudent_Grade]    Script Date: 12/20/2018 19:15:17 ******/
ALTER TABLE [dbo].[EnrolledCourseToStudent]  WITH CHECK ADD  CONSTRAINT [FK_EnrolledCourseToStudent_Grade] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grade] ([Id])
GO
ALTER TABLE [dbo].[EnrolledCourseToStudent] CHECK CONSTRAINT [FK_EnrolledCourseToStudent_Grade]
GO
