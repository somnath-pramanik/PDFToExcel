
CREATE TABLE [dbo].[GROUP](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GroupTitle] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[PrimaryConsultant] [int] NULL,
 CONSTRAINT [PK_GROUP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERLOG]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERLOG](
	[EXUSER] [char](10) NOT NULL,
	[EENT_DATE] [datetime] NOT NULL,
	[EOUT_DATE] [datetime] NOT NULL,
	[FAILURE] [bit] NULL,
	[SY_OBJ_NAME] [char](20) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[SY_DOCNO] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbTimeZoneInfo]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbTimeZoneInfo](
	[TimeZoneID] [int] IDENTITY(1,1) NOT NULL,
	[Display] [nvarchar](255) NOT NULL,
	[Bias] [smallint] NOT NULL,
	[StdBias] [smallint] NOT NULL,
	[DltBias] [smallint] NOT NULL,
	[StdMonth] [smallint] NOT NULL,
	[StdDayOfWeek] [smallint] NOT NULL,
	[StdWeek] [smallint] NOT NULL,
	[StdHour] [smallint] NOT NULL,
	[DltMonth] [smallint] NOT NULL,
	[DltDayOfWeek] [smallint] NOT NULL,
	[DltWeek] [smallint] NOT NULL,
	[DltHour] [smallint] NOT NULL,
	[ZoneId] [varchar](100) NULL,
	[timeoffset] [char](10) NOT NULL,
 CONSTRAINT [PK_tbTimeZoneInfo] PRIMARY KEY CLUSTERED 
(
	[TimeZoneID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbTimeZoneInfo] ON
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (1, N'(GMT-12:00) International Date Line West', 720, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Dateline Standard Time', N'-12:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (2, N'(GMT-11:00) Midway Island, Samoa', 660, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Samoa Standard Time', N'-11:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (3, N'(GMT-10:00) Hawaii', 600, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Hawaiian Standard Time', N'-10:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (4, N'(GMT-09:00) Alaska', 540, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Alaskan Standard Time', N'-09:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (5, N'(GMT-08:00) Pacific Time (US & Canada); Tijuana', 480, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Pacific Standard Time', N'-08:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (6, N'(GMT-07:00) Chihuahua, La Paz, Mazatlan', 420, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Mountain Standard Time (Mexico)', N'-07:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (7, N'(GMT-07:00) Mountain Time (US & Canada)', 420, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Mountain Standard Time', N'-07:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (8, N'(GMT-07:00) Arizona', 420, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'US Mountain Standard Time', N'-07:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (9, N'(GMT-06:00) Guadalajara, Mexico City, Monterrey', 360, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Central Standard Time (Mexico)', N'-06:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (10, N'(GMT-06:00) Saskatchewan', 360, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Canada Central Standard Time', N'-06:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (11, N'(GMT-06:00) Central America', 360, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Central America Standard Time', N'-06:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (12, N'(GMT-06:00) Central Time (US & Canada)', 360, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Central Standard Time', N'-06:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (13, N'(GMT-05:00) Eastern Time (US & Canada)', 300, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Eastern Standard Time ', N'-05:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (14, N'(GMT-05:00) Bogota, Lima, Quito', 300, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'SA Pacific Standard Time', N'-05:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (15, N'(GMT-05:00) Indiana (East)', 300, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'US Eastern Standard Time', N'-05:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (16, N'(GMT-04:00) Caracas, La Paz', 240, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Atlantic Standard Time', N'-04:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (17, N'(GMT-04:00) Santiago', 240, 0, -60, 3, 6, 2, 0, 10, 6, 2, 0, N'Pacific SA Standard Time', N'-04:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (18, N'(GMT-04:00) Atlantic Time (Canada)', 240, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Atlantic Standard Time', N'-04:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (19, N'(GMT-03:30) Newfoundland', 210, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Newfoundland Standard Time', N'-03:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (20, N'(GMT-03:00) Buenos Aires, Georgetown', 180, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Argentina Standard Time', N'-03:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (21, N'(GMT-03:00) Brasilia', 180, 0, -60, 2, 0, 2, 2, 10, 0, 3, 2, N'E. South America Standard Time', N'-03:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (22, N'(GMT-03:00) Greenland', 180, 0, -60, 10, 0, 5, 2, 4, 0, 1, 2, N'Greenland Standard Time', N'-03:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (23, N'(GMT-02:00) Mid-Atlantic', 120, 0, -60, 9, 0, 5, 2, 3, 0, 5, 2, N'Mid-Atlantic Standard Time', N'-02:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (24, N'(GMT-01:00) Azores', 60, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Azores Standard Time', N'-01:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (25, N'(GMT-01:00) Cape Verde Is.', 60, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Cape Verde Standard Time', N'-01:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (26, N'(GMT) Casablanca, Monrovia', 0, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Morocco Standard Time', N') Casa    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (27, N'(GMT) Greenwich Mean Time : Dublin, Edinburgh, Lisbon, London', 0, 0, -60, 10, 0, 5, 2, 3, 0, 5, 1, N'GMT Standard Time', N') Gree    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (28, N'(GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague', -60, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Central Europe Standard Time', N'+01:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (29, N'(GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb', -60, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Central European Standard Time', N'+01:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (30, N'(GMT+01:00) Brussels, Copenhagen, Madrid, Paris', -60, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Romance Standard Time', N'+01:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (31, N'(GMT+01:00) West Central Africa', -60, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'W. Central Africa Standard Time', N'+01:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (32, N'(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna', -60, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'W. Europe Standard Time', N'+01:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (33, N'(GMT+02:00) Harare, Pretoria', -120, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'South Africa Standard Time', N'+02:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (34, N'(GMT+02:00) Jerusalem', -120, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Israel Standard Time', N'+02:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (35, N'(GMT+02:00) Athens, Beirut, Istanbul, Minsk', -120, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'GTB Standard Time', N'+02:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (36, N'(GMT+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius', -120, 0, -60, 10, 0, 5, 4, 3, 0, 5, 3, N'FLE Standard Time', N'+02:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (37, N'(GMT+02:00) Bucharest', -120, 0, -60, 10, 0, 5, 1, 3, 0, 5, 0, N'GTB Standard Time', N'+02:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (38, N'(GMT+02:00) Cairo', -120, 0, -60, 9, 3, 5, 2, 5, 5, 1, 2, N'Egypt Standard Time', N'+02:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (39, N'(GMT+03:00) Nairobi', -180, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'E. Africa Standard Time', N'+03:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (40, N'(GMT+03:00) Kuwait, Riyadh', -180, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Arab Standard Time', N'+03:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (41, N'(GMT+03:00) Baghdad', -180, 0, -60, 10, 0, 1, 4, 4, 0, 1, 3, N'Arabic Standard Time', N'+03:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (42, N'(GMT+03:00) Moscow, St. Petersburg, Volgograd', -180, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Russian Standard Time', N'+03:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (43, N'(GMT+03:30) Tehran', -210, 0, -60, 9, 2, 4, 2, 3, 0, 1, 2, N'Iran Standard Time', N'+03:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (44, N'(GMT+04:00) Abu Dhabi, Muscat', -240, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Arabian Standard Time', N'+04:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (45, N'(GMT+04:00) Baku, Tbilisi, Yerevan', -240, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Azerbaijan Standard Time', N'+04:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (46, N'(GMT+04:30) Kabul', -270, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Afghanistan Standard Time', N'+04:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (47, N'(GMT+05:00) Ekaterinburg', -300, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Ekaterinburg Standard Time', N'+05:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (48, N'(GMT+05:00) Islamabad, Karachi, Tashkent', -300, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Pakistan Standard Time', N'+05:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (49, N'(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi', -330, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'India Standard Time', N'+05:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (50, N'(GMT+05:45) Kathmandu', -345, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Nepal Standard Time', N'+05:45    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (51, N'(GMT+06:00) Almaty, Novosibirsk', -360, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'N. Central Asia Standard Time', N'+06:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (52, N'(GMT+05:30) Sri Jayawardenepura', 330, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Sri Lanka Standard Time', N'+05:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (53, N'(GMT+06:00) Astana, Dhaka', -360, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Central Asia Standard Time', N'+06:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (54, N'(GMT+06:30) Rangoon', -390, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Myanmar Standard Time', N'+06:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (55, N'(GMT+07:00) Krasnoyarsk', -420, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'North Asia Standard Time', N'+07:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (56, N'(GMT+07:00) Bangkok, Hanoi, Jakarta', -420, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'SE Asia Standard Time', N'+07:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (57, N'(GMT+08:00) Kuala Lumpur, Singapore', -480, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Singapore Standard Time', N'+08:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (58, N'(GMT+08:00) Taipei', -480, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Taipei Standard Time', N'+08:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (59, N'(GMT+08:00) Irkutsk, Ulaan Bataar', -480, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'North Asia East Standard Time', N'+08:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (60, N'(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi', -480, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'China Standard Time', N'+08:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (61, N'(GMT+08:00) Perth', -480, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'W. Australia Standard Time', N'+08:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (62, N'(GMT+09:00) Yakutsk', -540, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Yakutsk Standard Time', N'+09:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (63, N'(GMT+09:00) Seoul', -540, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Korea Standard Time', N'+09:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (64, N'(GMT+09:00) Osaka, Sapporo, Tokyo', -540, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Tokyo Standard Time', N'+09:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (65, N'(GMT+09:30) Darwin', -570, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'AUS Central Standard Time', N'+09:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (66, N'(GMT+09:30) Adelaide', -570, 0, -60, 3, 0, 5, 3, 10, 0, 5, 2, N'Cen. Australia Standard Time', N'+09:30    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (67, N'(GMT+10:00) Canberra, Melbourne, Sydney', -600, 0, -60, 3, 0, 5, 3, 10, 0, 5, 2, N'AUS Eastern Standard Time', N'+10:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (68, N'(GMT+10:00) Brisbane', -600, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'E. Australia Standard Time', N'+10:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (69, N'(GMT+10:00) Guam, Port Moresby', -600, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'West Pacific Standard Time', N'+10:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (70, N'(GMT+10:00) Hobart', -600, 0, -60, 3, 0, 5, 3, 10, 0, 1, 2, N'Tasmania Standard Time', N'+10:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (71, N'(GMT+10:00) Vladivostok', -600, 0, -60, 10, 0, 5, 3, 3, 0, 5, 2, N'Vladivostok Standard Time', N'+10:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (72, N'(GMT+11:00) Magadan, Solomon Is., New Caledonia', -660, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Central Pacific Standard Time', N'+11:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (73, N'(GMT+12:00) Fiji, Kamchatka, Marshall Is.', -720, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Fiji Standard Time', N'+12:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (74, N'(GMT+12:00) Auckland, Wellington', -720, 0, -60, 3, 0, 3, 2, 10, 0, 1, 2, N'New Zealand Standard Time', N'+12:00    ')
INSERT [dbo].[tbTimeZoneInfo] ([TimeZoneID], [Display], [Bias], [StdBias], [DltBias], [StdMonth], [StdDayOfWeek], [StdWeek], [StdHour], [DltMonth], [DltDayOfWeek], [DltWeek], [DltHour], [ZoneId], [timeoffset]) VALUES (75, N'(GMT+13:00) Nuku''alofa', -780, 0, -60, 0, 0, 0, 0, 0, 0, 0, 0, N'Tonga Standard Time', N'+13:00    ')
SET IDENTITY_INSERT [dbo].[tbTimeZoneInfo] OFF
/****** Object:  Table [dbo].[EX_USER_NEW]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EX_USER_NEW](
	[EXUSER] [char](10) NOT NULL,
	[USERGROUP] [nchar](10) NOT NULL,
	[PASS] [nchar](20) NOT NULL,
	[USER_FNAME] [nvarchar](50) NOT NULL,
	[USER_LNAME] [nvarchar](50) NOT NULL,
	[E_MAIL] [varchar](255) NOT NULL,
	[WELCOM_MSG] [nvarchar](max) NULL,
	[REPASSWORD] [nvarchar](50) NULL,
	[IsAdministration] [bit] NOT NULL,
	[IsManager] [bit] NOT NULL,
	[IsMember] [bit] NOT NULL,
	[IsClient] [bit] NOT NULL,
	[USR_ID] [int] IDENTITY(1,1) NOT NULL,
	[IsTaskAssign] [bit] NOT NULL,
	[IsTaskCreate] [bit] NOT NULL,
	[UserStatus] [int] NULL,
	[group_id] [int] NULL,
	[UserImg] [nvarchar](max) NULL,
	[RoleMasterId] [int] NULL,
	[IsInternalOrExternal] [bit] NULL,
	[IsSelfAccess] [bit] NULL,
	[IsTeamAccess] [bit] NULL,
	[IsGlobalAccess] [bit] NULL,
	[TicketAccess] [nvarchar](50) NOT NULL,
	[TimeZoneId] [int] NOT NULL
) ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[EX_USER_NEW] ADD [hm_ph_ext] [varchar](20) NULL
ALTER TABLE [dbo].[EX_USER_NEW] ADD [of_ph_ext] [varchar](20) NULL
ALTER TABLE [dbo].[EX_USER_NEW] ADD [IsChangeAdmin] [bit] NOT NULL
ALTER TABLE [dbo].[EX_USER_NEW] ADD  CONSTRAINT [pk_UserID] PRIMARY KEY CLUSTERED 
(
	[USR_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EX_USER_NEW] ON
INSERT [dbo].[EX_USER_NEW] ([EXUSER], [USERGROUP], [PASS], [USER_FNAME], [USER_LNAME], [E_MAIL], [WELCOM_MSG], [REPASSWORD], [IsAdministration], [IsManager], [IsMember], [IsClient], [USR_ID], [IsTaskAssign], [IsTaskCreate], [UserStatus], [group_id], [UserImg], [RoleMasterId], [IsInternalOrExternal], [IsSelfAccess], [IsTeamAccess], [IsGlobalAccess], [TicketAccess], [TimeZoneId], [hm_ph_ext], [of_ph_ext], [IsChangeAdmin]) VALUES (N'          ', N'          ', N'ÐÈÙÅÚÅÓÉÞ           ', N'Kajal', N'Hazra', N'kajalhazra08@gmail.com', NULL, N'ÍÊÖÇ×ÇÐËÛ¦™—', 0, 0, 0, 0, 63, 0, 0, 0, NULL, N'63IMG_20150130_165343494.jpg', 2, 1, 0, 1, 0, N'TeamAccess', 49, N'773773779922', N'832763783773', 0)
SET IDENTITY_INSERT [dbo].[EX_USER_NEW] OFF
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime] NULL,
	[RoleName] [nvarchar](150) NULL,
	[IsCategory] [bit] NULL,
	[IsNewTicket] [bit] NULL,
	[IsGrouopClientMapping] [bit] NULL,
	[IsFieldAccess] [bit] NULL,
	[IsUserAccess] [bit] NULL,
	[IsChangeStatus] [bit] NULL,
	[IsViewInternalDiscussion] [bit] NULL,
	[IsAssignTo] [bit] NULL,
	[IsApproval] [bit] NULL,
	[IsPriority] [bit] NULL,
	[IsCreateUser] [bit] NULL,
	[IsCreateUserGroup] [bit] NULL,
	[IsCreateCustomer] [bit] NULL,
	[IsViewGroupTicket] [bit] NULL,
	[IsShowLayOut] [bit] NULL,
	[Description] [nvarchar](max) NULL,
	[IsUserClientMapping] [bit] NULL,
	[IsClientUserMapping] [bit] NULL,
	[IsTeam] [bit] NOT NULL,
	[IsSlaPolicy] [bit] NOT NULL,
	[IsBusinessCalendar] [bit] NOT NULL,
	[IsTeamUserModule] [bit] NOT NULL,
	[IsExport] [bit] NOT NULL,
	[reportlist] [varchar](200) NOT NULL,
	[IsAddRelease] [bit] NOT NULL,
	[IsAddNews] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] ON
INSERT [dbo].[RoleMaster] ([Id], [DateCreated], [RoleName], [IsCategory], [IsNewTicket], [IsGrouopClientMapping], [IsFieldAccess], [IsUserAccess], [IsChangeStatus], [IsViewInternalDiscussion], [IsAssignTo], [IsApproval], [IsPriority], [IsCreateUser], [IsCreateUserGroup], [IsCreateCustomer], [IsViewGroupTicket], [IsShowLayOut], [Description], [IsUserClientMapping], [IsClientUserMapping], [IsTeam], [IsSlaPolicy], [IsBusinessCalendar], [IsTeamUserModule], [IsExport], [reportlist], [IsAddRelease], [IsAddNews]) VALUES (1, CAST(0x0000A50F00990F80 AS DateTime), N'ADMIN', 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, NULL, 1, 1, 1, 1, 1, 1, 1, N'1,2,3,4,5,9,7,6,', 1, 1)
INSERT [dbo].[RoleMaster] ([Id], [DateCreated], [RoleName], [IsCategory], [IsNewTicket], [IsGrouopClientMapping], [IsFieldAccess], [IsUserAccess], [IsChangeStatus], [IsViewInternalDiscussion], [IsAssignTo], [IsApproval], [IsPriority], [IsCreateUser], [IsCreateUserGroup], [IsCreateCustomer], [IsViewGroupTicket], [IsShowLayOut], [Description], [IsUserClientMapping], [IsClientUserMapping], [IsTeam], [IsSlaPolicy], [IsBusinessCalendar], [IsTeamUserModule], [IsExport], [reportlist], [IsAddRelease], [IsAddNews]) VALUES (2, CAST(0x0000A4A50062C0F6 AS DateTime), N'Developer', 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0)
INSERT [dbo].[RoleMaster] ([Id], [DateCreated], [RoleName], [IsCategory], [IsNewTicket], [IsGrouopClientMapping], [IsFieldAccess], [IsUserAccess], [IsChangeStatus], [IsViewInternalDiscussion], [IsAssignTo], [IsApproval], [IsPriority], [IsCreateUser], [IsCreateUserGroup], [IsCreateCustomer], [IsViewGroupTicket], [IsShowLayOut], [Description], [IsUserClientMapping], [IsClientUserMapping], [IsTeam], [IsSlaPolicy], [IsBusinessCalendar], [IsTeamUserModule], [IsExport], [reportlist], [IsAddRelease], [IsAddNews]) VALUES (3, CAST(0x0000A4A50062EA06 AS DateTime), N'External', 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, NULL, 0, 0, 0, 0, 0, 0, 0, N'', 0, 0)
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
/****** Object:  Table [dbo].[Priority]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Priority](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [Priority_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Priority] ON
INSERT [dbo].[Priority] ([ID], [Name]) VALUES (1, N'Normal')
INSERT [dbo].[Priority] ([ID], [Name]) VALUES (2, N'Low')
INSERT [dbo].[Priority] ([ID], [Name]) VALUES (3, N'High')
INSERT [dbo].[Priority] ([ID], [Name]) VALUES (4, N'Urgent')
SET IDENTITY_INSERT [dbo].[Priority] OFF
/****** Object:  Table [dbo].[PdfConvertRecord]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PdfConvertRecord](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[pdffilename] [nvarchar](500) NULL,
	[xlsfilename] [nvarchar](500) NULL,
	[datecreated] [datetime] NULL,
	[isactive] [bit] NULL,
 CONSTRAINT [PdfConvertRecord_pk] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PdfConvertRecord] ON
INSERT [dbo].[PdfConvertRecord] ([ID], [UserId], [pdffilename], [xlsfilename], [datecreated], [isactive]) VALUES (1, 0, N'c295f750-1073-415b-ad12-29d51ea66d03636330440526346779.pdf', N'c295f750-1073-415b-ad12-29d51ea66d03636330440526346779.pdf', NULL, 1)
INSERT [dbo].[PdfConvertRecord] ([ID], [UserId], [pdffilename], [xlsfilename], [datecreated], [isactive]) VALUES (2, 9, N'd6d46e09-bbc0-496a-8236-a71464652d33636330466520486074.pdf', N'd6d46e09-bbc0-496a-8236-a71464652d33636330466520486074.pdf', NULL, 1)
INSERT [dbo].[PdfConvertRecord] ([ID], [UserId], [pdffilename], [xlsfilename], [datecreated], [isactive]) VALUES (3, 9, N'd6743d9b-e0d6-40a1-88a3-6670c4e8112e636330467290836074.pdf', N'd6743d9b-e0d6-40a1-88a3-6670c4e8112e636330467290836074.pdf', NULL, 1)
INSERT [dbo].[PdfConvertRecord] ([ID], [UserId], [pdffilename], [xlsfilename], [datecreated], [isactive]) VALUES (4, 63, N'ee273d63-e5aa-40b1-89ad-f8658534c06b636330467624606074.pdf', N'ee273d63-e5aa-40b1-89ad-f8658534c06b636330467624606074.pdf', NULL, 1)
SET IDENTITY_INSERT [dbo].[PdfConvertRecord] OFF
/****** Object:  Table [dbo].[notifications]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime] NULL,
	[type] [int] NULL,
	[parent_type] [int] NULL,
	[NotificationMsg] [varchar](max) NULL,
	[NotificationTitle] [varchar](max) NULL,
	[ForProject] [int] NULL,
	[parent_id] [int] NULL,
	[sender_id] [int] NULL,
	[sender_name] [nvarchar](255) NULL,
	[sender_email] [nvarchar](255) NULL,
	[created_on] [datetime] NULL,
	[raw_additional_properties] [nvarchar](255) NULL,
	[OwnerID] [int] NULL,
	[UserID] [int] NULL,
	[UserToID] [int] NULL,
	[ch_status] [nvarchar](15) NULL,
	[ch_priority] [nvarchar](15) NULL,
	[ch_category] [nvarchar](15) NULL,
	[msgsuffix] [varchar](200) NULL,
	[msgsuffforexternal] [varchar](200) NULL,
	[ticket_no] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NotificationNews]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationNews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime] NULL,
	[NotificationMsg] [nvarchar](max) NOT NULL,
	[NotificationTitle] [nvarchar](max) NULL,
	[recepiant_id] [int] NULL,
	[sender_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notification_recipients]    Script Date: 06/14/2017 14:39:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notification_recipients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCreated] [datetime] NULL,
	[recipient_name] [nvarchar](255) NULL,
	[recipient_email] [nvarchar](255) NULL,
	[seen_on] [datetime] NULL,
	[read_on] [datetime] NULL,
	[ForProject] [int] NULL,
	[ForCompany] [int] NULL,
	[ForTask] [int] NULL,
	[OwnerID] [int] NULL,
	[UserID] [int] NULL,
	[notificatio_Id] [int] NULL,
	[recipient_id] [int] NULL,
	[isRead] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDaylightStandardDateTime]    Script Date: 06/14/2017 14:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  FUNCTION [dbo].[GetDaylightStandardDateTime]
(
    @Year int,        -- a valid year value
    @Month int,        -- 1..12
    @DayOfWeek smallint,    -- 1..7
    @Week smallint,      -- 1..5, 1 - first week, 2 - second, etc.,  5 - the last week
    @Hour smallint -- hour value when daylight or standard time begins.
)
RETURNS datetime
AS
BEGIN
    DECLARE @FirstOfMonth datetime
    DECLARE @DoW smallint
    DECLARE @Ret datetime

    -- find day of the week of the first day of a given month:
    SET @FirstOfMonth = CAST( @Year AS NVARCHAR ) + '/' +  CAST( @Month AS NVARCHAR ) + '/01'

    -- 5th week means the last week of the month, so go one month forth, then one week back
    IF @Week = 5
    BEGIN
        SET @FirstOfMonth = DATEADD( Month, 1, @FirstOfMonth )
    END

    SET @DoW = DATEPART( weekday, @FirstOfMonth )

    -- find first given day of the week of the given month:
    IF @DoW > @DayOfWeek
        SET @Ret = DATEADD( Day, 7 + @DayOfWeek - @DoW , @FirstOfMonth )
    ELSE
        SET @Ret = DATEADD( Day, @DayOfWeek - @DoW , @FirstOfMonth )

    -- advance to the given week ( 5th week means the last one of the month )
    IF @Week < 5
    BEGIN
        SET @Ret = DATEADD( Week, @Week - 1, @Ret )
    END
    ELSE
    BEGIN
        -- the last week of the previous month; go one week backward
        SET @Ret = DATEADD( Week, -1, @Ret )
    END


   SET @Ret = DATEADD( Hour, @Hour, @Ret )

    RETURN @Ret
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetLocalDateTime]    Script Date: 06/14/2017 14:39:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
CREATE FUNCTION [dbo].[GetLocalDateTime]
(
@UTCDate DATETIME,
@TimeZoneID SMALLINT
)

RETURNS NVARCHAR(500)
AS
BEGIN

--DECLARE @TimeZoneID SMALLINT
DECLARE @LocalDateTime DATETIME
DECLARE @DltBiasFactor SMALLINT

DECLARE @Display NVARCHAR(50)
DECLARE @Bias INT
DECLARE @DltBias INT
DECLARE @StdMonth SMALLINT
DECLARE @StdDow SMALLINT
DECLARE @StdWeek SMALLINT
DECLARE @StdHour SMALLINT
DECLARE @DltMonth SMALLINT
DECLARE @DltDow SMALLINT
DECLARE @DltWeek SMALLINT
DECLARE @DltHour SMALLINT

DECLARE @DaylightDate DATETIME
DECLARE @StandardDate DATETIME

SET @DltBiasFactor = 0

SELECT 
@Display = Display,
@Bias = (-1 * Bias), 
@DltBias = (-1 * DltBias) ,
@StdMonth  = StdMonth,
@StdDow = StdDayOfWeek + 1,
@StdWeek = StdWeek,
@StdHour = StdHour,
@DltMonth = DltMonth,
@DltDow = DltDayOfWeek + 1,
@DltWeek = DltWeek,
@DltHour = DltHour
FROM 
tbTimeZoneInfo 
WHERE 
TimeZoneID = @TimeZoneID


IF @StdMonth = 0
BEGIN
	SET @LocalDateTime = DateAdd( minute, @Bias , @UTCDate)
END
ELSE
BEGIN
	SET @StandardDate =  dbo.GetDaylightStandardDateTime( DATEPART( year, @UTCDate ), @StdMonth, @StdDow, @StdWeek, @StdHour )
	SET @DaylightDate = dbo. GetDaylightStandardDateTime( DATEPART( year, @UTCDate ), @DltMonth, @DltDow, @DltWeek, @DltHour )

	
	IF (  @StandardDate > @DaylightDate )
	BEGIN
		IF ( DATEADD( minute, @Bias, @UTCDate )  BETWEEN @DaylightDate AND @StandardDate   )
		BEGIN
			SET @DltBiasFactor = 1
		END
	END
	ELSE
	BEGIN
		IF ( DATEADD( minute, @Bias, @UTCDate )  BETWEEN @StandardDate AND @DaylightDate )
		BEGIN
			SET @DltBiasFactor = 0
		END
	END

	SET @LocalDateTime = DATEADD( minute, @Bias + ( @DltBiasFactor * @DltBias ) , @UTCDate )

END

	RETURN   @LocalDateTime 

END
GO
/****** Object:  Default [DF__GROUP__GroupTitl__40F9A68C]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[GROUP] ADD  DEFAULT ('') FOR [GroupTitle]
GO
/****** Object:  Default [DF__GROUP__Descripti__41EDCAC5]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[GROUP] ADD  DEFAULT ('') FOR [Description]
GO
/****** Object:  Default [DF__userlog__EXUSER__61123BBA]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[USERLOG] ADD  CONSTRAINT [DF__userlog__EXUSER__61123BBA]  DEFAULT ('') FOR [EXUSER]
GO
/****** Object:  Default [DF__userlog__EENT_DA__63EEA865]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[USERLOG] ADD  CONSTRAINT [DF__userlog__EENT_DA__63EEA865]  DEFAULT (getdate()) FOR [EENT_DATE]
GO
/****** Object:  Default [DF__userlog__EOUT_DA__66CB1510]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[USERLOG] ADD  CONSTRAINT [DF__userlog__EOUT_DA__66CB1510]  DEFAULT (getdate()) FOR [EOUT_DATE]
GO
/****** Object:  Default [DF__userlog__Failure__68B35D82]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[USERLOG] ADD  CONSTRAINT [DF__userlog__Failure__68B35D82]  DEFAULT ((0)) FOR [FAILURE]
GO
/****** Object:  Default [DF__USERLOG__SY_OBJ___467D75B8]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[USERLOG] ADD  DEFAULT ('') FOR [SY_OBJ_NAME]
GO
/****** Object:  Default [DF__tbTimeZon__timeo__7BE56230]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[tbTimeZoneInfo] ADD  DEFAULT ('') FOR [timeoffset]
GO
/****** Object:  Default [DF__ex_user_new__EXUSER__0C31A3E9]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  CONSTRAINT [DF__ex_user_new__EXUSER__0C31A3E9]  DEFAULT (' ') FOR [EXUSER]
GO
/****** Object:  Default [DF__ex_user_new__USERGRO]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  CONSTRAINT [DF__ex_user_new__USERGRO]  DEFAULT (' ') FOR [USERGROUP]
GO
/****** Object:  Default [DF__ex_user_new__PASS]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  CONSTRAINT [DF__ex_user_new__PASS]  DEFAULT (' ') FOR [PASS]
GO
/****** Object:  Default [DF__ex_user_new__USER_FN]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  CONSTRAINT [DF__ex_user_new__USER_FN]  DEFAULT ('') FOR [USER_FNAME]
GO
/****** Object:  Default [DF__ex_user__USER_LN_new]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  CONSTRAINT [DF__ex_user__USER_LN_new]  DEFAULT ('') FOR [USER_LNAME]
GO
/****** Object:  Default [DF__ex_user__E_MAIL_new]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  CONSTRAINT [DF__ex_user__E_MAIL_new]  DEFAULT ('') FOR [E_MAIL]
GO
/****** Object:  Default [DF__EX_USER_N__IsAdm__19DFD96B]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsAdministration]
GO
/****** Object:  Default [DF__EX_USER_N__IsMan__1AD3FDA4]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsManager]
GO
/****** Object:  Default [DF__EX_USER_N__IsMem__1BC821DD]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsMember]
GO
/****** Object:  Default [DF__EX_USER_N__IsCli__1CBC4616]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsClient]
GO
/****** Object:  Default [DF__EX_USER_N__IsTas__1DB06A4F]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsTaskAssign]
GO
/****** Object:  Default [DF__EX_USER_N__IsTas__1EA48E88]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsTaskCreate]
GO
/****** Object:  Default [DF__EX_USER_N__UserS__2180FB33]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [UserStatus]
GO
/****** Object:  Default [DF__EX_USER_N__IsSel__22751F6C]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsSelfAccess]
GO
/****** Object:  Default [DF__EX_USER_N__IsTea__236943A5]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsTeamAccess]
GO
/****** Object:  Default [DF__EX_USER_N__IsGlo__245D67DE]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsGlobalAccess]
GO
/****** Object:  Default [DF__EX_USER_N__Ticke__25518C17]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ('') FOR [TicketAccess]
GO
/****** Object:  Default [DF__EX_USER_N__TimeZ__640DD89F]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((49)) FOR [TimeZoneId]
GO
/****** Object:  Default [DF__EX_USER_N__IsCha__0D0FEE32]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW] ADD  DEFAULT ((0)) FOR [IsChangeAdmin]
GO
/****** Object:  Default [DF__RoleMaste__IsTea__16CE6296]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ((0)) FOR [IsTeam]
GO
/****** Object:  Default [DF__RoleMaste__IsSla__17C286CF]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ((0)) FOR [IsSlaPolicy]
GO
/****** Object:  Default [DF__RoleMaste__IsBus__18B6AB08]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ((0)) FOR [IsBusinessCalendar]
GO
/****** Object:  Default [DF__RoleMaste__IsTea__5C6CB6D7]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ((0)) FOR [IsTeamUserModule]
GO
/****** Object:  Default [DF__RoleMaste__IsExp__1C5231C2]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ((0)) FOR [IsExport]
GO
/****** Object:  Default [DF__RoleMaste__repor__1D4655FB]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ('') FOR [reportlist]
GO
/****** Object:  Default [DF__RoleMaste__IsAdd__27C3E46E]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ((0)) FOR [IsAddRelease]
GO
/****** Object:  Default [DF__RoleMaste__IsAdd__28B808A7]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  DEFAULT ((0)) FOR [IsAddNews]
GO
/****** Object:  Default [DF__notificat__paren__11158940]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT ((0)) FOR [parent_id]
GO
/****** Object:  Default [DF__notificat__sende__1209AD79]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT ((0)) FOR [sender_id]
GO
/****** Object:  Default [DF__notificat__sende__12FDD1B2]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT (NULL) FOR [sender_name]
GO
/****** Object:  Default [DF__notificat__sende__13F1F5EB]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT (NULL) FOR [sender_email]
GO
/****** Object:  Default [DF__notificat__raw_a__14E61A24]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT (NULL) FOR [raw_additional_properties]
GO
/****** Object:  Default [DF__notificat__msgsu__084B3915]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT ('') FOR [msgsuffix]
GO
/****** Object:  Default [DF__notificat__msgsu__093F5D4E]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT ('') FOR [msgsuffforexternal]
GO
/****** Object:  Default [DF__notificat__ticke__0A338187]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notifications] ADD  DEFAULT ('') FOR [ticket_no]
GO
/****** Object:  Default [DF__notificat__recip__0D44F85C]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notification_recipients] ADD  DEFAULT (NULL) FOR [recipient_name]
GO
/****** Object:  Default [DF__notificat__recip__0E391C95]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notification_recipients] ADD  DEFAULT (NULL) FOR [recipient_email]
GO
/****** Object:  Default [DF__notificat__isRea__1A69E950]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[notification_recipients] ADD  DEFAULT ((0)) FOR [isRead]
GO
/****** Object:  ForeignKey [fk_PrimaryConsultant]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[GROUP]  WITH CHECK ADD  CONSTRAINT [fk_PrimaryConsultant] FOREIGN KEY([PrimaryConsultant])
REFERENCES [dbo].[EX_USER_NEW] ([USR_ID])
GO
ALTER TABLE [dbo].[GROUP] CHECK CONSTRAINT [fk_PrimaryConsultant]
GO
/****** Object:  ForeignKey [FK_EX_USER_NEW_RoleMaster]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW]  WITH CHECK ADD  CONSTRAINT [FK_EX_USER_NEW_RoleMaster] FOREIGN KEY([RoleMasterId])
REFERENCES [dbo].[RoleMaster] ([Id])
GO
ALTER TABLE [dbo].[EX_USER_NEW] CHECK CONSTRAINT [FK_EX_USER_NEW_RoleMaster]
GO
/****** Object:  ForeignKey [fk_group_id]    Script Date: 06/14/2017 14:39:51 ******/
ALTER TABLE [dbo].[EX_USER_NEW]  WITH CHECK ADD  CONSTRAINT [fk_group_id] FOREIGN KEY([group_id])
REFERENCES [dbo].[GROUP] ([ID])
GO
ALTER TABLE [dbo].[EX_USER_NEW] CHECK CONSTRAINT [fk_group_id]
GO
