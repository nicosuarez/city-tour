USE [CityTour]
GO

DELETE FROM [dbo].[AudioGuide];
DELETE FROM [dbo].[Reservation];
DELETE FROM [dbo].[BookingCommerce];
DELETE FROM [dbo].[TourEvent];
DELETE FROM [dbo].[Tour];
DELETE FROM [dbo].[Event];
DELETE FROM [dbo].[Commerce];
DELETE FROM [dbo].[Company];
DELETE FROM [dbo].[Business];
DELETE FROM [dbo].[CommerceQuery];
DELETE FROM [dbo].[Location];
DELETE FROM [dbo].[Person];
DELETE FROM [dbo].[PersonAudioGuide];
DELETE FROM [dbo].[PersonAudioGuideEvent];

/****** Object:  Table [dbo].[Person]    Script Date: 08/05/2012 18:40:37 ******/
SET IDENTITY_INSERT [dbo].[Person] ON
INSERT [dbo].[Person] ([ID], [Name], [EmailAddress], [Created]) VALUES (1, N'Vanesa', N'vanesa@citytour.com', GETDATE())
INSERT [dbo].[Person] ([ID], [Name], [EmailAddress], [Created]) VALUES (2, N'Ruben', N'ruben@citytour.com', GETDATE())
INSERT [dbo].[Person] ([ID], [Name], [EmailAddress], [Created]) VALUES (3, N'Leandro', N'leandro@citytour.com', GETDATE())
INSERT [dbo].[Person] ([ID], [Name], [EmailAddress], [Created]) VALUES (4, N'Nestor', N'nestor@citytour.com', GETDATE())
INSERT [dbo].[Person] ([ID], [Name], [EmailAddress], [Created]) VALUES (5, N'Nicolás', N'nicolas@citytour.com', GETDATE())
INSERT [dbo].[Person] ([ID], [Name], [EmailAddress], [Created]) VALUES (6, N'Sebastian', N'sebastian@citytour.com', GETDATE())
INSERT [dbo].[Person] ([ID], [Name], [EmailAddress], [Created]) VALUES (7, N'Diego', N'diego@citytour.com', GETDATE())
SET IDENTITY_INSERT [dbo].[Person] OFF
/****** Object:  Table [dbo].[Location]    Script Date: 08/05/2012 18:40:37 ******/
SET IDENTITY_INSERT [dbo].[Location] ON
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (1, CAST(-34.651944000 AS Decimal(18, 9)), CAST(-58.440278000 AS Numeric(18, 9)), N'Cancha de San Lorenzo de Almagro')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (2, CAST(-34.643333000 AS Decimal(18, 9)), CAST(-58.396667000 AS Numeric(18, 9)), N'Cancha de Huracán')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (3, CAST(-34.635556000 AS Decimal(18, 9)), CAST(-58.364722000 AS Numeric(18, 9)), N'Cancha de Boca')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (4, CAST(-34.615171000 AS Decimal(18, 9)), CAST(-58.402934000 AS Numeric(18, 9)), N'Business Hotel & Wellness SPA "OLMO DORADO"')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (5, CAST(-34.627416696 AS Decimal(18, 9)), CAST(-58.369288444 AS Numeric(18, 9)), N'Parque Lezama')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (6, CAST(-34.626745737 AS Decimal(18, 9)), CAST(-58.370972871 AS Numeric(18, 9)), N'Museo Histórico Nacional')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (7, CAST(-34.622196753 AS Decimal(18, 9)), CAST(-58.371195495 AS Numeric(18, 9)), N'Museo del Cine Pablo C. Ducros Hicken')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (8, CAST(-34.621995895 AS Decimal(18, 9)), CAST(-58.370530307 AS Numeric(18, 9)), N'Museo de Arte Moderno de Buenos Aires')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (9, CAST(-34.620867988 AS Decimal(18, 9)), CAST(-58.370425701 AS Numeric(18, 9)), N'Museo de la Iglesia Parroquial San Pedro Telmo')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (10, CAST(-34.620494959 AS Decimal(18, 9)), CAST(-58.371841907 AS Numeric(18, 9)), N'Plaza Dorrego')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (11, CAST(-34.617617000 AS Decimal(18, 9)), CAST(-58.368495000 AS Numeric(18, 9)), N'Facultad de Ingeniería de la UBA - Sede Paseo Colón')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (12, CAST(-34.603640000 AS Decimal(18, 9)), CAST(-58.381552000 AS Numeric(18, 9)), N'Obelisco')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (13, CAST(-34.592802000 AS Decimal(18, 9)), CAST(-58.372765000 AS Numeric(18, 9)), N'Sheraton Retiro')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (14, CAST(-34.588399000 AS Decimal(18, 9)), CAST(-58.396277000 AS Numeric(18, 9)), N'Facultad de Ingeniería de la UBA - Sede Las Heras')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (15, CAST(-34.585721 AS Decimal(18, 9)), CAST(-58.393216 AS Numeric(18, 9)), N'Hard Rock Cafe')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (16, CAST(-34.545278000 AS Decimal(18, 9)), CAST(-58.449722000 AS Numeric(18, 9)), N'Cancha de River')
INSERT [dbo].[Location] ([ID], [Latitude], [Longitud], [Name]) VALUES (17, CAST(-34.617012 AS Decimal(18, 9)), CAST(-58.370141 AS Numeric(18, 9)), N'El Viejo Almacén')
SET IDENTITY_INSERT [dbo].[Location] OFF
/****** Object:  Table [dbo].[Business]    Script Date: 08/05/2012 18:40:37 ******/
SET IDENTITY_INSERT [dbo].[Business] ON
INSERT [dbo].[Business] ([ID], [Name]) VALUES (1, N'Cine')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (2, N'Bar')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (3, N'Restaurant')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (4, N'Museo')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (5, N'Teatro')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (6, N'Taxi')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (7, N'Hotel')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (8, N'Institución Deportiva')
INSERT [dbo].[Business] ([ID], [Name]) VALUES (9, N'Institución Pública')
SET IDENTITY_INSERT [dbo].[Business] OFF
/****** Object:  Table [dbo].[Tour]    Script Date: 08/05/2012 18:40:37 ******/
SET IDENTITY_INSERT [dbo].[Tour] ON
INSERT [dbo].[Tour] ([ID], [PersonID], [Created], [ScheduleReminder]) VALUES (1, 1, GETDATE(), NULL)
SET IDENTITY_INSERT [dbo].[Tour] OFF
/****** Object:  Table [dbo].[Company]    Script Date: 08/05/2012 18:40:37 ******/
SET IDENTITY_INSERT [dbo].[Company] ON
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (1, N'Club San Lorenzo de Almagro', N'Club San Lorenzo de Almagro, de Boedo para toda la Argentina y el Mundo.', N'123456789', 8)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (2, N'Club Huracán', N'Con el Globo a todas partes!!', N'123456789  ', 8)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (3, N'Club Boca Juniors', N'Podran imitarnos pero igualarnos jamas. Como no somos los únicos decidimos ser los mejores.', N'123456789', 8)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (4, N'Business Hotel & Wellness SPA "OLMO DORADO"', N'Disfrute de lo moderno y lo confortable de nuestro hotel de negocios y bienestar en el centro de Buenos Aires. Estamos a una cuadra del subterraneo y a 10 minutos del Obelisco y la Av. 9 de Julio.', N'123456789', 7)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (5, N'Gobierno de la Ciudad de Buenos Aires', N'Haciendo Buenos Aires. Jede de Gobierno Mauricio Macri.', N'123456789', 9)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (6, N'Dirección de Museos', N'Dirección de Museos de la República Argentina. Visite los Museos.', N'123456789', 4)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (7, N'Universidad de Buenos Aires', N'Universidad Pública y gratuita. La mejor de latino america.', N'123456789', 9)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (8, N'Sheraton Buenos Aires Hotel & Convention Center', N'Located in the heart of the city, the Sheraton Buenos Aires Hotel & Convention Center is a landmark for international travelers. Spectacular views of Buenos Aires and the Río de la Plata.', N'123456789', 7)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (9, N'Hard Rock Cafe', N'Hard Rock Cafe Buenos Aires. Donde vive la música.', N'123456789', 2)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (10, N'Club River Plate', N'El más grande sigue siendo River Plate, el campeón más poderoso de la historia (de la B).', N'123456789', 8)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (11, N'Taxi Premium', N'Usted viaja con máxima seguridad ya que nuestro sistema de identificación digital, nos permite monitorear el vehículo durante todo el trayecto, desde nuestra base operativa.', N'123456789', 6)
INSERT [dbo].[Company] ([ID], [Name], [Description], [CUIT], [BusinessID]) VALUES (12, N'El Viejo Almacén', N'Donde el Tango vive.', N'123456789', 3)
SET IDENTITY_INSERT [dbo].[Company] OFF
/****** Object:  Table [dbo].[Commerce]    Script Date: 08/05/2012 18:40:37 ******/
SET IDENTITY_INSERT [dbo].[Commerce] ON
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (1, N'Cancha de San Lorenzo de Almagro', (SELECT [Description] FROM [Company] WHERE [ID] = 1), 1, N'Av Perito Moreno 1702-2380', 1)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (2, N'Cancha de Huracán', (SELECT [Description] FROM [Company] WHERE [ID] = 2), 2, N'Av Amancio Alcorta 2502-2600', 2)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (3, N'Cancha de Boca Juniors', (SELECT [Description] FROM [Company] WHERE [ID] = 3), 3, N'Dr. del Valle Iberlucea 701-799', 3)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (4, N'Business Hotel & Wellness SPA "OLMO DORADO"', (SELECT [Description] FROM [Company] WHERE [ID] = 4), 4, N'Saavedra esquina Venezuela', 4)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (5, N'Parque Lezama', N'El Parque Lezama es un tradicional paseo en la Ciudad de Buenos Aires. Se caracteriza por sus avenidas arboladas, su anfiteatro y la barranca. Allí se encuentra el Museo Histórico Nacional.', 5, N'Av Martín García 199-249', 5)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (6, N'Museo Histórico Nacional', N'Recreación de la historia del país, a través del acopio, conservación, investigación y difusión del patrimonio.', 6, N'Defensa 1601-1699', 6)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (7, N'Museo del Cine Pablo C. Ducros Hicken', N'El Museo del Cine Pablo Ducrós Hicken es el único en nuestro país dedicado al cine argentino y pionero en su género en Latinoamérica.', 7, N'Defensa 1202-1300', 6)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (8, N'Museo de Arte Moderno de Buenos Aires', N'Más de 7.000 obras vanguardistas e innovadoras del siglo XX y XXI, argentinas e internacionales, nuevamente al alcance de todos en un modernizado edificio.', 8, N'Av San Juan 302-400', 6)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (9, N'Museo de la Iglesia Parroquial San Pedro Telmo', N'En una iglesia de más de 200 años de sólidas y anchas paredes construidas por los Jesuitas, se exponen imágenes, esculturas y valiosos documentos pertenecientes a tres siglos de historia.', 9, N'Humberto Primo 302-400', 6)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (10, N'Plaza Dorrego', N'Antiguamente a este lugar se lo denominaba Hueco del Alto o Alto de las carretas, pues era allí donde los carros tirados por bueyes se detenían antes de cruzar el arroyo Tercero del Sur.', 10, N'Bethlem 402-450', 5)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (11, N'Facultad de Ingeniería de la UBA - Sede Paseo Colón', N'Esta sede fue diseñada, construida e inaugurada originariamente por la Fundación Eva Perón. En 1956, luego del Golpe de Estado de 1955, es destinada al estudio de la ingeniería.', 11, N'Av Paseo Colón 850', 7)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (12, N'Obelisco', N'Es un monumento considerado un ícono de la ciudad de Buenos Aires, construido en 1936 con motivo del cuarto centenario de la fundación de la ciudad.', 12, N'Av Corrientes y Av 9 de Julio', 5)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (13, N'Sheraton Buenos Aires Hotel & Convention Center', (SELECT [Description] FROM [Company] WHERE [ID] = 8), 13, N'San Martín 1211-1299', 8)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (14, N'Facultad de Ingeniería de la UBA - Sede Las Heras', N'El edificio de Las Heras 2214 fue concebido entre los años 1909 y 1910 para albergar a la Facultad de Derecho y Ciencias Sociales.', 14, N'Av Gral. Las Heras 2202-2250', 7)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (15, N'Hard Rock Cafe', (SELECT [Description] FROM [Company] WHERE [ID] = 9), 15, N'Shopping Buenos Aires Design', 9)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (16, N'Cancha de River', (SELECT [Description] FROM [Company] WHERE [ID] = 10), 16, N'Av Guillermo Udaondo 912-1200', 10)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (17, N'Taxi Premium', (SELECT [Description] FROM [Company] WHERE [ID] = 11), NULL, N'', 11)
INSERT [dbo].[Commerce] ([ID], [Name], [Description], [LocationID], [Address], [CompanyID]) VALUES (18, N'El Viejo Almacén', (SELECT [Description] FROM [Company] WHERE [ID] = 12), 17, N'Balcarce y Av. Independencia', 12)
SET IDENTITY_INSERT [dbo].[Commerce] OFF
/****** Object:  Table [dbo].[Event]    Script Date: 08/05/2012 18:40:37 ******/
/*
SET IDENTITY_INSERT [dbo].[Event] ON
INSERT [dbo].[Event] ([ID], [EventDate], [Description], [CommerceID]) VALUES (1, GETDATE(), N'Vamos a la cancha del ciclón!!', 1)
INSERT [dbo].[Event] ([ID], [EventDate], [Description], [CommerceID]) VALUES (2, GETDATE(), N'Vamos a la cancha del globo!!', 2)
SET IDENTITY_INSERT [dbo].[Event] OFF
*/
/****** Object:  Table [dbo].[BookingCommerce]    Script Date: 08/05/2012 18:40:37 ******/
INSERT [dbo].[BookingCommerce] ([ID], [ContactPhone], [WebServiceURL], [ContactMail]) VALUES (17, N'5238-0000', NULL, N'info@taxipremium.com')
/****** Object:  Table [dbo].[AudioGuide]    Script Date: 08/05/2012 18:40:37 ******/
SET IDENTITY_INSERT [dbo].[AudioGuide] ON
INSERT [dbo].[AudioGuide] ([ID], [Description], [CommerceID], [Link]) VALUES (1, N'El Viejo Almacén', 18, N'santelmo/03-El Viejo Almacén (Balcarce y Av. Independencia).mp3')
INSERT [dbo].[AudioGuide] ([ID], [Description], [CommerceID], [Link]) VALUES (2, N'Introducción a San Telmo', 10, N'santelmo/01-Introducción a San Telmo (Defensa y Bethlem).mp3')
INSERT [dbo].[AudioGuide] ([ID], [Description], [CommerceID], [Link]) VALUES (3, N'Monumento del Canto al Trabajo y  Facultad de Ingeniería', 11, N'santelmo/04-Monumento del Canto al Trabajo y  Facultad de Ingeniería.mp3')
INSERT [dbo].[AudioGuide] ([ID], [Description], [CommerceID], [Link]) VALUES (4, N'Plaza Dorrego y Feria de Antigüedades', 10, N'santelmo/07-Plaza Dorrego y Feria de Antigüedades  (Defensa y Humberto 1º).mp3')
INSERT [dbo].[AudioGuide] ([ID], [Description], [CommerceID], [Link]) VALUES (5, N'Iglesia de San Pedro Telmo', 9, N'santelmo/09-Iglesia de San Pedro Telmo (Humberto 1º 340).mp3')
INSERT [dbo].[AudioGuide] ([ID], [Description], [CommerceID], [Link]) VALUES (6, N'Parque Lezama y Museo Histórico Nacional', 5, N'santelmo/11-Parque Lezama -  Museo Histórico Nacional (Defensa y Brasil).mp3')
SET IDENTITY_INSERT [dbo].[AudioGuide] OFF
/****** Object:  Table [dbo].[CommerceQuery]    Script Date: 08/05/2012 18:40:37 ******/
/****** Object:  Table [dbo].[TourEvent]    Script Date: 08/05/2012 18:40:37 ******/
/*
INSERT [dbo].[TourEvent] ([TourID], [EventID]) VALUES (1, 1)
INSERT [dbo].[TourEvent] ([TourID], [EventID]) VALUES (1, 2)
*/
/****** Object:  Table [dbo].[Reservation]    Script Date: 08/05/2012 18:40:37 ******/
/*
SET IDENTITY_INSERT [dbo].[Reservation] ON
INSERT [dbo].[Reservation] ([ID], [ReservationDate], [PersonID], [BookingCommerceID], [Price], [CancellationDate], [Accepted], [Detail]) VALUES (1, GETDATE(), 1, 17, 0, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[Reservation] OFF
*/
/****** Object:  Table [dbo].[PersonAudioGuideEvent]    Script Date: 08/05/2012 18:40:37 ******/
/****** Object:  Table [dbo].[PersonAudioGuide]    Script Date: 08/05/2012 18:40:37 ******/

