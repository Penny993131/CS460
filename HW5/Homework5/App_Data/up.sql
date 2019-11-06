CREATE TABLE [dbo].[Homeworks]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[Priority]  NVARCHAR(64)            NOT NULL,
	[DueDate]   DATETIME		        NOT NULL,
	[DueTime]	TIME		        NOT NULL,
	[Department] TEXT			    NOT NULL,
	[Course#]    TEXT               NOT NULL,
	[Homework Title] TEXT           NOT NULL,
	[Notes]      TEXT               NOT NULL,
	CONSTRAINT [PK_dbo.Homeworks] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Homeworks] (Priority, DueDate, DueTime,Department,Course#,HomeworkTitle,Notes) VALUES
	('1','11-01-2019','23:59','Math','Complete Graph','  '),
	('2','12-31-2019','23:59''CS''Photoshop','  '),
	('3','09-15-2018','23:59''Art''Oil Painting','  '),
	('2''10-01-2018','23:59''Music''Broadway Music','  '),	
	('1''08-08-2019','23:59''Education''Education Setting','  ')
GO