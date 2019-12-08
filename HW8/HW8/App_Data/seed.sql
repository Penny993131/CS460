 -- ################### SEED DATA ######################

-- Extract data from .csv file and load into our db

-- Create a staging table to hold all the seed data.  We'll query this 
-- table in order to extract what we need to then insert into our real
-- tables.
CREATE TABLE [dbo].[AllData]
(
	[Located] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[MyEvent] NVARCHAR(20),
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
--INSERT INTO [dbo].[Coaches] ([Name])
--	SELECT DISTINCT Coach from [dbo].[AllData];

-- Load Team data, a team has a coach so we need to find the correct entry in the 
-- Coaches table so we can set the foreign key appropriately

INSERT INTO [dbo].[Teams]([Title],[Coach])
	SELECT DISTINCT Team, Coach from [dbo].[AllData];
		
INSERT INTO [dbo].[Athletes]([Name])
	SELECT DISTINCT Athlete from [dbo].[AllData];	

INSERT INTO [dbo].[TeamsandAthletes] ([Gender],[TeamID],[AthleteID])
	SELECT DISTINCT ad.Gender, team.ID, athlete.ID
		FROM AllData ad	--AllData is going to be nicknamed "ad" while Teams is going to be nicknamed "team"
		INNER JOIN Teams team ON ad.Team = team.Title -- Where ad [Team] is the same as team [Title], Join the two tables
		INNER JOIN Athletes athlete ON ad.Athlete = athlete.Name;
		--Nicknaming Athletes as "athlete"
		--Now add on to the table where ad [Athlete] is the same as athlete [Name]

INSERT INTO [dbo].[Locations]([Located],[MeetDate])                                             
	SELECT DISTINCT Located, MeetDate from [dbo].[AllData];

INSERT INTO [dbo].[Events]([EventTitle])
	SELECT DISTINCT MyEvent from [dbo].[AllData];


-- Load all the other tables in a similar fashion.  Race results is the hardest since
-- it has several FK's.  Think joins.
INSERT INTO [dbo].[RaceResults]([RaceTime],[AthleteID],[EventID],[LocationID])
    SELECT DISTINCT ad.RaceTime, athlete.ID, myevent.ID, mylocation.ID
		FROM AllData ad	
		INNER JOIN Athletes athlete ON ad.Athlete = athlete.Name
		INNER JOIN Events myevent ON ad.MyEvent = myevent.EventTitle
		INNER JOIN Locations mylocation ON ad.Located = mylocation.Located;
