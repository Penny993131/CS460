-- ################### SEED DATA ######################

-- Extract data from .csv file and load into our db

-- Create a staging table to hold all the seed data.  We'll query this 
-- table in order to extract what we need to then insert into our real
-- tables.
CREATE TABLE [dbo].[AllData]
(
	[Location] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[Event] NVARCHAR(20),
	[Gender] NVARCHAR(20),
	[Athlete] NVARCHAR(50),
	[RaceTime] REAL
);
-- Hard code the full path to the csv file.  It'll be better this way 
-- when we run this in HW 9 to build an Azure db 
BULK INSERT [dbo].[AllData]
	FROM 'C:\Users\19712\Documents\CS460\CS460-F19-Penny993131\HW8\racetimes.csv'
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2
	);

-- Load coaches data, no foreign keys here to worry about so we can 
-- do a straight insert of just the distinct values
INSERT INTO [dbo].[Coaches] ([Name])
	SELECT DISTINCT Coach from [dbo].[AllData];

-- Load Team data, a team has a coach so we need to find the correct entry in the 
-- Coaches table so we can set the foreign key appropriately
INSERT INTO [dbo].[Teams]
	(Name,CoachID)
	SELECT DISTINCT ad.Team,cs.ID
		FROM dbo.AllData as ad, dbo.Coaches as cs
		WHERE ad.Coach = cs.Name;

INSERT INTO [dbo].[Locations]
	SELECT DISTINCT Location from [dbo].[AllData];

INSERT INTO [dbo].[MeetDates]
	(Name,CoachID)
	SELECT DISTINCT ad.Team,cs.ID
		FROM dbo.AllData as ad, dbo.Coaches as cs
		WHERE ad.Coach = cs.Name;

INSERT INTO [dbo].[Events]
	SELECT DISTINCT Event from [dbo].[AllData];

INSERT INTO [dbo].[Genders]
	SELECT DISTINCT Gender from [dbo].[AllData];

INSERT INTO [dbo].[Athletes]
	SELECT DISTINCT Athlete from [dbo].[AllData];

-- Load all the other tables in a similar fashion.  Race results is the hardest since
-- it has several FK's.  Think joins.
INSERT INTO [dbo].[RaceTimes]
     (Name,AthleteID)
	(Name,LocationID)
--	SELECT DISTINCT ad.Team,cs.ID
	--	FROM dbo.AllData as ad, dbo.Coaches as cs
	--	WHERE ad.Coach = cs.Name;
