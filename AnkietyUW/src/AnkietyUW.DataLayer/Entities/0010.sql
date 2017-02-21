CREATE TABLE [dbo].[Answers] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [DateTime]     DATE             NOT NULL,
    [TestId]       UNIQUEIDENTIFIER NOT NULL,
    [SeriesNumber] INT              NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Tests] (
    [Id]                       UNIQUEIDENTIFIER NOT NULL,
    [FirstQuestionAddSeconds]  INT       NOT NULL,
    [SecondQuestionAddSeconds] INT       NOT NULL,
    [ThirdQuestionAddSeconds]  INT       NOT NULL,
    [FourthQuestionAddSeconds] INT       NOT NULL,
    [CompletedSeriesCounter]   INT       NOT NULL,
    [TimeToFillTestAddSeconds] INT       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Secrets] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [SeriesNumber] INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[TestTimes] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [DateTime] DATE             NOT NULL,
    [TestId]   UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Key]          CHAR (256)       NOT NULL,
    [EmailAddress] CHAR (256)       NULL,
    [Active]       BIT              NOT NULL,
    [Sex]          INT              NOT NULL,
    [TestId]       UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);