CREATE TABLE [dbo].[Answers] (
    [Id] CHAR (36) NOT NULL PRIMARY KEY,
    [DateTime] DATE NOT NULL, 
    [TestId] CHAR(36) NOT NULL, 
    [SeriesNumber] INT NOT NULL, 
    [UserId] CHAR(36) NULL, 
);

CREATE TABLE [dbo].[Tests]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
    [FirstQuestionAddSeconds] INT NOT NULL, 
    [SecondQuestionAddSeconds] INT NOT NULL, 
    [ThirdQuestionAddSeconds] INT NOT NULL, 
    [FourthQuestionAddSeconds] INT NOT NULL, 
    [CompletedSeriesCounter] INT NOT NULL, 
    [TimeToFillTestAddSeconds] INT NOT NULL
);

CREATE TABLE [dbo].[Secrets]
(
	[Id] CHAR(36) NOT NULL PRIMARY KEY, 
    [UserId] CHAR(36) NOT NULL, 
    [SeriesNumber] INT NOT NULL
);

CREATE TABLE [dbo].[TestTimes]
(
	[Id] CHAR(36) NOT NULL PRIMARY KEY, 
    [DateTime] DATE NOT NULL, 
    [TestId] CHAR(36) NOT NULL
);

CREATE TABLE [dbo].[Users]
(
	[Id] CHAR(36) NOT NULL PRIMARY KEY, 
    [Key] CHAR(256) NOT NULL, 
    [EmailAddress] CHAR(256) NOT NULL, 
    [Active] BIT NOT NULL, 
    [Sex] INT NOT NULL, 
    [TestId] INT NOT NULL
);