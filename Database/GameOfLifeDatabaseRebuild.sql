USE [GameOfLife]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

PRINT 'Drop Tables'
DROP TABLE [dbo].[LocationOffer]
DROP TABLE [dbo].[Offer]
DROP TABLE [dbo].[Location]
DROP TABLE [dbo].[Store]

PRINT 'Create Tables'
CREATE TABLE [dbo].[Store](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Location]
(
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[StoreID] [INT] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Address1] [varchar](250) NOT NULL,
	[Address2] [varchar](250) NULL,
	[City] [varchar](250) NOT NULL,
	[State] [varchar](100) NOT NULL,
	[ZipCode] [varchar](14) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED
 (
	[LocationID] ASC
 ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Location] WITH CHECK ADD CONSTRAINT [FK_Location_Store] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Store] ([StoreID])
GO

ALTER TABLE [dbo].[Location] CHECK CONSTRAINT [FK_Location_Store]
GO

CREATE TABLE [dbo].[Offer](
	[OfferID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Details] [varchar](max) NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[OfferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[LocationOffer]
(
	[LocationID] [int] NOT NULL,
	[OfferID] [int] NOT NULL,
	[DaysOfWeek] [varchar](250) NOT NULL,
 CONSTRAINT [PK_LocationOffer] PRIMARY KEY CLUSTERED
(
	[LocationID] ASC, [OfferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LocationOffer] WITH CHECK ADD CONSTRAINT [FK_LocationOffer_Location] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([LocationID])
GO

ALTER TABLE [dbo].[LocationOffer] CHECK CONSTRAINT [FK_LocationOffer_Location]
GO

ALTER TABLE [dbo].[LocationOffer] WITH CHECK ADD CONSTRAINT [FK_LocationOffer_Offer] FOREIGN KEY([OfferID])
REFERENCES [dbo].[Offer] ([OfferID])
GO

ALTER TABLE [dbo].[LocationOffer] CHECK CONSTRAINT [FK_LocationOffer_Offer]
GO

SET ANSI_PADDING OFF
GO

PRINT 'Insert Data into tables'

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Moes Southwestern Grill');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('The Loop');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Mama Fus');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Cabana Grill');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Steak N Shake');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Sticky Fingers');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Zaxbys');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Applebees');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Hurricanes');

INSERT INTO [dbo].[Store]
(Name)
VALUES
('Mellow Mushroom');

INSERT INTO [dbo].[Offer]
(Name, Details)
VALUES
('Kids Eat Free', 'Kids eat free with the purchase of an adult meal');

INSERT INTO [dbo].[Offer]
(Name, Details)
VALUES
('Bulletin Day', '10% off entire order with church bulletin');

INSERT INTO [dbo].[Offer]
(Name, Details)
VALUES
('Zaxbys Family Day', '4 Meal Deals and 4 cookies for $20');

INSERT INTO [dbo].[Offer]
(Name, Details)
VALUES
('Kids Half Off', 'Kids meal 50% off');

INSERT INTO [dbo].[Offer]
(Name, Details)
VALUES
('All Kids Meal $1.99', 'All kids meal $1.99');

INSERT INTO [dbo].[Offer]
(Name, Details)
VALUES
('Kids Meal Free with Adult Purchase', 'Kids eat free for every $8 spent');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(1, 'Southside Avenues', '9960 Southside Blvd.', '', 'Jacksonville', 'FL', '32256');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(1, 'Mandarin', '11105 San Jose Blvd', '', 'Jacksonville', 'FL', '32223');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(2, 'Southside Baymeadows', '8221 Southside Blvd', '', 'Jacksonville', 'FL', '32256');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(2, 'Mandarin', '9965 San Jose Blvd', '', 'Jacksonville', 'FL', '32257');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(2, 'Towncenter', '4413 Town Center Parkway North', '', 'Jacksonville', 'FL', '32246');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(3, 'Mandarin', '11105 San Jose Blvd', '', 'Jacksonville', 'FL', '32223');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(4, 'Mandarin', '10422 San Jose Blvd', '', 'Jacksonville', 'FL', '32257');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(5, 'Mandarin', '10661 San Jose Boulevard', '', 'Jacksonville', 'FL', '32257');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(5, 'Phillips Highway', '9431 Phillips Highway', '', 'Jacksonville', 'FL', '32256');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(6, 'Baymeadows 9A', '8129 Point Meadows Way', '', 'Jacksonville', 'FL', '32256');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(7, 'South Mandarin', '9612 San Jose Blvd.', '', 'Jacksonville', 'FL', '32257');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(7, 'North Mandarin', '12301 San Jose Blvd.', '', 'Jacksonville', 'FL', '32223');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(7, 'Bartram', '13973 Village Lake Cir', '', 'Jacksonville', 'FL', '32258');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(8, 'Bartram', '14560 Old Saint Augustine Road', '', 'Jacksonville', 'FL', '32258');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(9, 'Baymeadows 9A', '10920 Baymeadows Rd', '', 'Jacksonville', 'FL', '32256');

INSERT INTO [dbo].[Location]
(StoreID, Name, Address1, Address2, City, State, ZipCode)
VALUES
(10, 'Southside', '9734 Deer Lake Ct #1', '', 'Jacksonville', 'FL', '32246');

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(1, 1, 'Tu')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(2, 1, 'Tu')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(3, 5, 'Sat')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(4, 1, 'Mo')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(4, 5, 'Sat')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(5, 5, 'Mo,We')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(6, 1, 'Mo,Sat')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(7, 1, 'Tu')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(8, 6, 'Sa,Su')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(9, 6, 'Sa,Su')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(10, 1, 'Mo')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(11, 3, 'Mo')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(11, 1, 'We')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(11, 2, 'Su')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(12, 1, 'Mo')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(12, 2, 'Su')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(13, 1, 'Sa')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(14, 5, 'Su')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(15, 1, 'Tu')

INSERT INTO [dbo].[LocationOffer]
(LocationID, OfferID, DaysOfWeek)
VALUES
(16, 4, 'We')


SELECT *
FROM Store

SELECT *
FROM Location

SELECT *
FROM Offer

SELECT *
FROM LocationOffer