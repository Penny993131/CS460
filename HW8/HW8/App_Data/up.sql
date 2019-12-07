

CREATE TABLE [dbo].[Teams]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Title]	NVARCHAR (50)		NOT NULL,
	[Coach]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Athletes]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Name]	NVARCHAR (50)		NOT NULL,
	[Gender]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
);

CREATE TABLE [dbo].[TeamsandAthletes]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[TeamID]	INT    NOT NULL,
	[AthleteID]	INT    NOT NULL,
	CONSTRAINT [PK_dbo.TeamsandAthletes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.TeamsandAthletes_dbo.Teams_ID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams] ([ID]),
	CONSTRAINT [FK_dbo.TeamsandAthletes_dbo.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([ID])
);

CREATE TABLE [dbo].[Locations]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[Located]	NVARCHAR (50)		NOT NULL,
	[MeetDate]	DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Events]
(
	[ID]	INT IDENTITY (1,1)	NOT NULL,
	[EventTitle]	NVARCHAR (50)		NOT NULL,
	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([ID] ASC),
);


CREATE TABLE [dbo].[RaceResults]
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[AthleteID]	INT    NOT NULL,
	[EventID]	INT NOT NULL,   
	[LocationID] INT    NOT NULL,
	[RaceTime]	NVARCHAR (256)	NOT NULL

	CONSTRAINT [PK_dbo.RaceResults] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.RaceResults_dbo.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([ID]),
	CONSTRAINT [FK_dbo.RaceResults_dbo.Events_ID] FOREIGN KEY ([EventID]) REFERENCES [dbo].[Events] ([ID]),
	CONSTRAINT [FK_dbo.Events_dbo.Locations_ID] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Locations] ([ID])
);



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