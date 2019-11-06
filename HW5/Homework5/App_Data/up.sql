CREATE TABLE [dbo].[Homeworks]
(
	[ID]		INT IDENTITY (1,1)	NOT NULL,
	[ThePriority]  INT                 NOT NULL,
	[DueDate]   DATE		        NOT NULL,
	[DueTime]	TIME		        NOT NULL,
	[Department] TEXT	            NOT NULL,
	[Course#]    TEXT               NOT NULL,
	[HomeworkTitle] TEXT            NOT NULL,
	[Notes]     TEXT                 NOT NULL,
	CONSTRAINT [PK_dbo.Homeworks] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Homeworks] (ThePriority, DueDate, DueTime, Department, Course#, HomeworkTitle,Notes) VALUES
	(1,'11-01-2019','23:59','Math','MTH354','Complete Graph', 'Graded')
	(2,'12-31-2019','23:59','CS','CS121','Photoshop','unGraded'),
	(3,'09-15-2018','23:59','Art','Art231','Oil Painting','Graded'),
	(2,'10-01-2018','23:59''Music','Music110','Broadway Music','unGraded'),	
	(1,'08-08-2019','23:59','Education','ED380','Education Setting','Graded')
GO