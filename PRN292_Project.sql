USE [master]
GO
/****** Object:  Database [PRN292_Project]    Script Date: 28-Jul-21 2:45:19 PM ******/
CREATE DATABASE [PRN292_Project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PRN292_Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRN292_Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PRN292_Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PRN292_Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PRN292_Project] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PRN292_Project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PRN292_Project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PRN292_Project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PRN292_Project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PRN292_Project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PRN292_Project] SET ARITHABORT OFF 
GO
ALTER DATABASE [PRN292_Project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PRN292_Project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PRN292_Project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PRN292_Project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PRN292_Project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PRN292_Project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PRN292_Project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PRN292_Project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PRN292_Project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PRN292_Project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PRN292_Project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PRN292_Project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PRN292_Project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PRN292_Project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PRN292_Project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PRN292_Project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PRN292_Project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PRN292_Project] SET RECOVERY FULL 
GO
ALTER DATABASE [PRN292_Project] SET  MULTI_USER 
GO
ALTER DATABASE [PRN292_Project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PRN292_Project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PRN292_Project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PRN292_Project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PRN292_Project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PRN292_Project] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PRN292_Project', N'ON'
GO
ALTER DATABASE [PRN292_Project] SET QUERY_STORE = OFF
GO
USE [PRN292_Project]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 28-Jul-21 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](250) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[DayOfWeeks] [nvarchar](250) NULL,
	[RoomID] [int] NULL,
	[SlotStudy] [nvarchar](250) NULL,
	[TotalSlot] [int] NULL,
	[SlotRemain] [int] NULL,
	[LecturerID] [int] NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecturers]    Script Date: 28-Jul-21 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecturers](
	[LecturerID] [int] IDENTITY(1,1) NOT NULL,
	[LecturerName] [nvarchar](250) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Lecturers] PRIMARY KEY CLUSTERED 
(
	[LecturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matrix]    Script Date: 28-Jul-21 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matrix](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ButtonLocationI] [int] NULL,
	[ButtonLocationJ] [int] NULL,
	[ISlotOfColumn] [int] NULL,
	[JDayOfWeek] [int] NULL,
 CONSTRAINT [PK_Matrix] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAssign]    Script Date: 28-Jul-21 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAssign](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NULL,
	[ClassID] [int] NULL,
	[LecturerID] [int] NULL,
	[SlotID] [int] NULL,
	[Time] [date] NULL,
 CONSTRAINT [PK_RoomAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 28-Jul-21 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slots]    Script Date: 28-Jul-21 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slots](
	[SlotID] [int] IDENTITY(1,1) NOT NULL,
	[SlotName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Slots] PRIMARY KEY CLUSTERED 
(
	[SlotID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28-Jul-21 2:45:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Classes] ON 

INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (1, N'PRN292', CAST(N'2021-05-05' AS Date), CAST(N'2021-05-29' AS Date), N'Wednesday, Thursday, Friday', 4, N'1', 32, 20, 2)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (2, N'PRJ321', CAST(N'2021-05-10' AS Date), CAST(N'2021-07-26' AS Date), N'Monday, Wednesday, Friday', 1, N'1', 30, 0, 1)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (3, N'PRF192', CAST(N'2021-05-10' AS Date), CAST(N'2021-07-25' AS Date), N'Monday, Wednesday, Friday', 1, N'1', 30, 0, 1)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (4, N'PRM291', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (5, N'MAS291', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (6, N'ACC101', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (7, N'ECO101', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (8, N'PMG201c', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (9, N'MAE101', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (10, N'DBW301', CAST(N'2021-05-05' AS Date), CAST(N'2021-05-12' AS Date), N'Wednesday, Thursday, Friday, Monday, Tuesday', 9, N'1', 30, 24, 6)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (11, N'CEA201', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (12, N'ISC301', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (13, N'PRX301', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
INSERT [dbo].[Classes] ([ClassID], [ClassName], [StartDate], [EndDate], [DayOfWeeks], [RoomID], [SlotStudy], [TotalSlot], [SlotRemain], [LecturerID]) VALUES (14, N'PRJ321', NULL, NULL, NULL, NULL, NULL, 30, 30, NULL)
SET IDENTITY_INSERT [dbo].[Classes] OFF
GO
SET IDENTITY_INSERT [dbo].[Lecturers] ON 

INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (1, N'Le Phuong Chi', 2)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (2, N'Luong Trung Kien', 3)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (3, N'Dang The Hung', 4)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (4, N'Tran Thanh Tung', 5)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (5, N'Phan Lac Tra', 6)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (6, N'Do Ngoc Thinh', 7)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (7, N'Ha Thi Khuyen', 8)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (8, N'Dang Dinh Hong', 9)
INSERT [dbo].[Lecturers] ([LecturerID], [LecturerName], [UserID]) VALUES (9, N'Dang Phuong Thuy', 10)
SET IDENTITY_INSERT [dbo].[Lecturers] OFF
GO
SET IDENTITY_INSERT [dbo].[Matrix] ON 

INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (1, 0, 0, 0, 0)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (2, 106, 0, 0, 1)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (3, 212, 0, 0, 2)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (4, 318, 0, 0, 3)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (5, 424, 0, 0, 4)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (6, 530, 0, 0, 5)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (7, 636, 0, 0, 6)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (8, 0, 50, 1, 0)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (9, 106, 50, 1, 1)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (10, 212, 50, 1, 2)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (11, 318, 50, 1, 3)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (12, 424, 50, 1, 4)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (13, 530, 50, 1, 5)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (14, 636, 50, 1, 6)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (15, 0, 100, 2, 0)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (16, 106, 100, 2, 1)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (17, 212, 100, 2, 2)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (18, 318, 100, 2, 3)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (19, 424, 100, 2, 4)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (20, 530, 100, 2, 5)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (21, 636, 100, 2, 6)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (22, 0, 150, 3, 0)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (23, 106, 150, 3, 1)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (24, 212, 150, 3, 2)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (25, 318, 150, 3, 3)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (26, 424, 150, 3, 4)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (27, 530, 150, 3, 5)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (28, 636, 150, 3, 6)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (29, 0, 200, 4, 0)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (30, 106, 200, 4, 1)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (31, 212, 200, 4, 2)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (32, 318, 200, 4, 3)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (33, 424, 200, 4, 4)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (34, 530, 200, 4, 5)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (35, 636, 200, 4, 6)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (36, 0, 250, 5, 0)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (37, 106, 250, 5, 1)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (38, 212, 250, 5, 2)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (39, 318, 250, 5, 3)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (40, 424, 250, 5, 4)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (41, 530, 250, 5, 5)
INSERT [dbo].[Matrix] ([ID], [ButtonLocationI], [ButtonLocationJ], [ISlotOfColumn], [JDayOfWeek]) VALUES (42, 636, 250, 5, 6)
SET IDENTITY_INSERT [dbo].[Matrix] OFF
GO
SET IDENTITY_INSERT [dbo].[RoomAssign] ON 

INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (323, 1, 3, 1, 1, CAST(N'2021-05-10' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (324, 1, 3, 1, 1, CAST(N'2021-05-12' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (325, 1, 3, 1, 1, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (326, 1, 3, 1, 1, CAST(N'2021-05-17' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (327, 1, 3, 1, 1, CAST(N'2021-05-19' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (328, 1, 3, 1, 1, CAST(N'2021-05-21' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (329, 1, 3, 1, 1, CAST(N'2021-05-24' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (330, 1, 3, 1, 1, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (331, 1, 3, 1, 1, CAST(N'2021-05-28' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (332, 1, 3, 1, 1, CAST(N'2021-05-31' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (333, 1, 3, 1, 1, CAST(N'2021-06-02' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (334, 1, 3, 1, 1, CAST(N'2021-06-04' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (335, 1, 3, 1, 1, CAST(N'2021-06-07' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (336, 1, 3, 1, 1, CAST(N'2021-06-09' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (337, 1, 3, 1, 1, CAST(N'2021-06-11' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (338, 1, 3, 1, 1, CAST(N'2021-06-14' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (339, 1, 3, 1, 1, CAST(N'2021-06-16' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (340, 1, 3, 1, 1, CAST(N'2021-06-18' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (341, 1, 3, 1, 1, CAST(N'2021-06-21' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (342, 1, 3, 1, 1, CAST(N'2021-06-23' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (343, 1, 3, 1, 1, CAST(N'2021-06-25' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (344, 1, 3, 1, 1, CAST(N'2021-06-28' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (345, 1, 3, 1, 1, CAST(N'2021-06-30' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (346, 1, 3, 1, 1, CAST(N'2021-07-02' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (347, 1, 3, 1, 1, CAST(N'2021-07-05' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (348, 1, 3, 1, 1, CAST(N'2021-07-07' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (349, 1, 3, 1, 1, CAST(N'2021-07-09' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (350, 1, 3, 1, 1, CAST(N'2021-07-12' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (351, 1, 3, 1, 1, CAST(N'2021-07-14' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (352, 1, 3, 1, 1, CAST(N'2021-07-16' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (353, 4, 1, 2, 1, CAST(N'2021-05-05' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (354, 4, 1, 2, 1, CAST(N'2021-05-06' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (355, 4, 1, 2, 1, CAST(N'2021-05-07' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (356, 4, 1, 2, 1, CAST(N'2021-05-12' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (357, 4, 1, 2, 1, CAST(N'2021-05-13' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (358, 4, 1, 2, 1, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (359, 4, 1, 2, 1, CAST(N'2021-05-19' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (360, 4, 1, 2, 1, CAST(N'2021-05-20' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (361, 4, 1, 2, 1, CAST(N'2021-05-21' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (362, 4, 1, 2, 1, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (363, 4, 1, 2, 1, CAST(N'2021-05-27' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (364, 4, 1, 2, 1, CAST(N'2021-05-28' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (365, 9, 10, 6, 1, CAST(N'2021-05-05' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (366, 9, 10, 6, 1, CAST(N'2021-05-06' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (367, 9, 10, 6, 1, CAST(N'2021-05-07' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (368, 9, 10, 6, 1, CAST(N'2021-05-10' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (369, 9, 10, 6, 1, CAST(N'2021-05-11' AS Date))
INSERT [dbo].[RoomAssign] ([ID], [RoomID], [ClassID], [LecturerID], [SlotID], [Time]) VALUES (370, 9, 10, 6, 1, CAST(N'2021-05-12' AS Date))
SET IDENTITY_INSERT [dbo].[RoomAssign] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 

INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (1, N'AL101')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (2, N'AL102')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (3, N'AL103')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (4, N'AL201')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (5, N'AL202')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (6, N'AL203')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (7, N'AL301')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (8, N'AL302')
INSERT [dbo].[Rooms] ([RoomID], [RoomName]) VALUES (9, N'AL303')
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Slots] ON 

INSERT [dbo].[Slots] ([SlotID], [SlotName]) VALUES (1, N'Slot 1 (7h30-9h00)')
INSERT [dbo].[Slots] ([SlotID], [SlotName]) VALUES (2, N'Slot 2 (9h10-10h40)')
INSERT [dbo].[Slots] ([SlotID], [SlotName]) VALUES (3, N'Slot 3 (10h50-12h20)')
INSERT [dbo].[Slots] ([SlotID], [SlotName]) VALUES (4, N'Slot 4 (12h50-14h20)')
INSERT [dbo].[Slots] ([SlotID], [SlotName]) VALUES (5, N'Slot 5 (14h30-16h00)')
INSERT [dbo].[Slots] ([SlotID], [SlotName]) VALUES (6, N'Slot 6 (16h10-17h40)')
SET IDENTITY_INSERT [dbo].[Slots] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (1, N'Canbo', N'123', N'CB')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (2, N'ChiLP', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (3, N'KienLT', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (4, N'HungDT', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (5, N'TungTT', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (6, N'TraPL', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (7, N'ThinhDN', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (8, N'KhuyenHT', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (9, N'HongDD', N'123', N'GV')
INSERT [dbo].[Users] ([ID], [UserName], [PassWord], [Role]) VALUES (10, N'ThuyDP', N'123', N'GV')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [PRN292_Project] SET  READ_WRITE 
GO
