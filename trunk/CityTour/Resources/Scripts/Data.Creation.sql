SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Person]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Person](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](100) NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Location]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Location](
	[ID] [uniqueidentifier] NOT NULL,
	[Latitude] [decimal](18, 0) NULL,
	[Longitud] [numeric](18, 0) NULL,
	[Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookingCommerce]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BookingCommerce](
	[ID] [uniqueidentifier] NOT NULL,
	[ContactPhone] [nvarchar](200) NULL,
	[WebServiceURL] [nvarchar](200) NULL,
	[ContactMail] [nvarchar](200) NULL,
 CONSTRAINT [PK_BookingCommerce] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Business]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Business](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Business] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reservation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reservation](
	[ID] [uniqueidentifier] NOT NULL,
	[ReservationDate] [datetime] NOT NULL,
	[PersonID] [uniqueidentifier] NOT NULL,
	[BookingCommerceID] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[CancellationDate] [datetime] NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tour]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tour](
	[ID] [uniqueidentifier] NOT NULL,
	[PersonID] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[ScheduleReminder] [bit] NULL,
 CONSTRAINT [PK_Tour] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CommerceQuery]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CommerceQuery](
	[ID] [uniqueidentifier] NOT NULL,
	[PersonID] [uniqueidentifier] NOT NULL,
	[CommerceID] [uniqueidentifier] NOT NULL,
	[QueryDate] [datetime] NOT NULL,
	[PersonLatitude] [decimal](18, 0) NOT NULL,
	[PersonLongitud] [decimal](18, 0) NOT NULL,
	[ProximityDistance] [int] NOT NULL,
 CONSTRAINT [PK_CommerceQuery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonAudioGuideEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PersonAudioGuideEvent](
	[PersonID] [uniqueidentifier] NOT NULL,
	[AudioGuideID] [uniqueidentifier] NOT NULL,
	[PlayDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonAudioGuideEvent] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[AudioGuideID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersonAudioGuide]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PersonAudioGuide](
	[PersonID] [uniqueidentifier] NOT NULL,
	[AudioGuideID] [uniqueidentifier] NOT NULL,
	[BuyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonAudioGuide] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC,
	[AudioGuideID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commerce]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Commerce](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[LocationID] [uniqueidentifier] NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[CompanyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Commerce] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AudioGuide]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AudioGuide](
	[ID] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CommerceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AudioGuide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Event]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Event](
	[ID] [uniqueidentifier] NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[CommerceID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Company]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Company](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CUIT] [char](11) NOT NULL,
	[BusinessID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TourEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TourEvent](
	[TourID] [uniqueidentifier] NOT NULL,
	[EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TourEvent] PRIMARY KEY CLUSTERED 
(
	[TourID] ASC,
	[EventID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservation_BookingCommerce]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservation]'))
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_BookingCommerce] FOREIGN KEY([BookingCommerceID])
REFERENCES [dbo].[BookingCommerce] ([ID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_BookingCommerce]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reservation_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reservation]'))
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Person]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tour_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tour]'))
ALTER TABLE [dbo].[Tour]  WITH CHECK ADD  CONSTRAINT [FK_Tour_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Tour] CHECK CONSTRAINT [FK_Tour_Person]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CommerceQuery_Commerce]') AND parent_object_id = OBJECT_ID(N'[dbo].[CommerceQuery]'))
ALTER TABLE [dbo].[CommerceQuery]  WITH CHECK ADD  CONSTRAINT [FK_CommerceQuery_Commerce] FOREIGN KEY([CommerceID])
REFERENCES [dbo].[Commerce] ([ID])
GO
ALTER TABLE [dbo].[CommerceQuery] CHECK CONSTRAINT [FK_CommerceQuery_Commerce]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CommerceQuery_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[CommerceQuery]'))
ALTER TABLE [dbo].[CommerceQuery]  WITH CHECK ADD  CONSTRAINT [FK_CommerceQuery_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[CommerceQuery] CHECK CONSTRAINT [FK_CommerceQuery_Person]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonAudioGuideEvent_AudioGuide]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonAudioGuideEvent]'))
ALTER TABLE [dbo].[PersonAudioGuideEvent]  WITH CHECK ADD  CONSTRAINT [FK_PersonAudioGuideEvent_AudioGuide] FOREIGN KEY([AudioGuideID])
REFERENCES [dbo].[AudioGuide] ([ID])
GO
ALTER TABLE [dbo].[PersonAudioGuideEvent] CHECK CONSTRAINT [FK_PersonAudioGuideEvent_AudioGuide]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonAudioGuideEvent_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonAudioGuideEvent]'))
ALTER TABLE [dbo].[PersonAudioGuideEvent]  WITH CHECK ADD  CONSTRAINT [FK_PersonAudioGuideEvent_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonAudioGuideEvent] CHECK CONSTRAINT [FK_PersonAudioGuideEvent_Person]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonAudioGuide_AudioGuide]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonAudioGuide]'))
ALTER TABLE [dbo].[PersonAudioGuide]  WITH CHECK ADD  CONSTRAINT [FK_PersonAudioGuide_AudioGuide] FOREIGN KEY([AudioGuideID])
REFERENCES [dbo].[AudioGuide] ([ID])
GO
ALTER TABLE [dbo].[PersonAudioGuide] CHECK CONSTRAINT [FK_PersonAudioGuide_AudioGuide]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PersonAudioGuide_Person]') AND parent_object_id = OBJECT_ID(N'[dbo].[PersonAudioGuide]'))
ALTER TABLE [dbo].[PersonAudioGuide]  WITH CHECK ADD  CONSTRAINT [FK_PersonAudioGuide_Person] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[PersonAudioGuide] CHECK CONSTRAINT [FK_PersonAudioGuide_Person]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Commerce_BookingCommerce]') AND parent_object_id = OBJECT_ID(N'[dbo].[Commerce]'))
ALTER TABLE [dbo].[Commerce]  WITH CHECK ADD  CONSTRAINT [FK_Commerce_BookingCommerce] FOREIGN KEY([ID])
REFERENCES [dbo].[BookingCommerce] ([ID])
GO
ALTER TABLE [dbo].[Commerce] CHECK CONSTRAINT [FK_Commerce_BookingCommerce]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Commerce_Company]') AND parent_object_id = OBJECT_ID(N'[dbo].[Commerce]'))
ALTER TABLE [dbo].[Commerce]  WITH CHECK ADD  CONSTRAINT [FK_Commerce_Company] FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Company] ([ID])
GO
ALTER TABLE [dbo].[Commerce] CHECK CONSTRAINT [FK_Commerce_Company]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Commerce_Location]') AND parent_object_id = OBJECT_ID(N'[dbo].[Commerce]'))
ALTER TABLE [dbo].[Commerce]  WITH CHECK ADD  CONSTRAINT [FK_Commerce_Location] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([ID])
GO
ALTER TABLE [dbo].[Commerce] CHECK CONSTRAINT [FK_Commerce_Location]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_AudioGuide_Commerce]') AND parent_object_id = OBJECT_ID(N'[dbo].[AudioGuide]'))
ALTER TABLE [dbo].[AudioGuide]  WITH CHECK ADD  CONSTRAINT [FK_AudioGuide_Commerce] FOREIGN KEY([CommerceID])
REFERENCES [dbo].[Commerce] ([ID])
GO
ALTER TABLE [dbo].[AudioGuide] CHECK CONSTRAINT [FK_AudioGuide_Commerce]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Event_Commerce]') AND parent_object_id = OBJECT_ID(N'[dbo].[Event]'))
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Commerce] FOREIGN KEY([CommerceID])
REFERENCES [dbo].[Commerce] ([ID])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Commerce]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Company_Business]') AND parent_object_id = OBJECT_ID(N'[dbo].[Company]'))
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_Business] FOREIGN KEY([BusinessID])
REFERENCES [dbo].[Business] ([ID])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_Business]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TourEvent_Event]') AND parent_object_id = OBJECT_ID(N'[dbo].[TourEvent]'))
ALTER TABLE [dbo].[TourEvent]  WITH CHECK ADD  CONSTRAINT [FK_TourEvent_Event] FOREIGN KEY([EventID])
REFERENCES [dbo].[Event] ([ID])
GO
ALTER TABLE [dbo].[TourEvent] CHECK CONSTRAINT [FK_TourEvent_Event]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TourEvent_Tour]') AND parent_object_id = OBJECT_ID(N'[dbo].[TourEvent]'))
ALTER TABLE [dbo].[TourEvent]  WITH CHECK ADD  CONSTRAINT [FK_TourEvent_Tour] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tour] ([ID])
GO
ALTER TABLE [dbo].[TourEvent] CHECK CONSTRAINT [FK_TourEvent_Tour]
