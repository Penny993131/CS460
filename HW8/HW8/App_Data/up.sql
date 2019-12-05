CREATE TABLE [dbo].[Teams]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Name]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Athletes]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Name]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Events]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Title]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Locations]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Name]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Meets]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Date]	DATETIME, NOT NULL,
	CONSTRAINT [PK_dbo.Meets] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[RaceTimes]
(
	[ID]			INT IDENTITY (1001,1)	NOT NULL,
	[Name]			NVARCHAR (50)			NOT NULL,
	[Time]	NVARCHAR (256)	NOT NULL,
	[AthleteID]		INT,
	CONSTRAINT [PK_dbo.RaceTimes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.RaceTimes_dbo.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([ID])
);

/*CREATE TABLE [dbo].[Bids]
(
	[ID]		INT IDENTITY (1,1) NOT NULL,
	[ItemID]	INT,
	[BuyerID]	INT,
	[Price]		DECIMAL (17,2),
	[Timestamp]	DATETIME,
	CONSTRAINT [PK_dbo.Bids] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Bids_dbo.Items_ID] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[Items] ([ID]),
	CONSTRAINT [FK_dbo.Bids_dbo.Buyers_ID] FOREIGN KEY ([BuyerID]) REFERENCES [dbo].[Buyers] ([ID])
);*/

/*INSERT INTO [dbo].[Buyers](Name)
	VALUES
	('Jane Stone'),
	('Tom McMasters'),
	('Otto Vanderwall');

INSERT INTO [dbo].[Sellers](Name)
	VALUES
	('Gayle Hardy'),
	('Lyle Banks'),
	('Pearl Greene');

INSERT INTO [dbo].[Items](Name,Description,SellerID)
	VALUES
	('Abraham Lincoln Hammer','A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln',3),
	('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927',1),
	('Bob Dylan Love Poems','Five versions of an original unpublished, handwritten, love poem by Bob Dylan',2);

INSERT INTO [dbo].[Bids](ItemID,BuyerID,Price,Timestamp)
	VALUES
	(1001,3,250000,	'12/04/2017 09:04:22'),
	(1003,1,95000,  '12/04/2017 08:44:03');
© 2019 GitHub, Inc.*/