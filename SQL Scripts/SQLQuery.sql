USE [GKazFitness];
GO

-- Create the 'User' table
CREATE TABLE [dbo].[User] (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(200) NOT NULL,
    PhoneNumber NVARCHAR(25) NULL,
    IsTrainer BIT NOT NULL
);

-- Create the 'TrainerProfile' table
CREATE TABLE [dbo].[TrainerProfile] (
    TrainerProfileId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Bio NVARCHAR(1000) NULL,
    ContactEmail NVARCHAR(100) NULL,
    ContactPhone NVARCHAR(25) NULL,
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](UserId) ON DELETE CASCADE
);

-- Create the 'Video' table
CREATE TABLE [dbo].[Video] (
    VideoId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Url NVARCHAR(MAX) NOT NULL,
    Description NVARCHAR(500) NULL,
    Platform NVARCHAR(50) NULL,
    TrainerProfileId INT NULL,
    FOREIGN KEY (TrainerProfileId) REFERENCES [dbo].[TrainerProfile](TrainerProfileId) ON DELETE SET NULL
);

-- Create the 'Appointment' table
CREATE TABLE [dbo].[Appointment] (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    TrainerId INT NOT NULL,
    ClientId INT NOT NULL,
    ScheduledDateTime DATETIME NOT NULL,
    Notes NVARCHAR(500) NULL,
    FOREIGN KEY (TrainerId) REFERENCES [dbo].[User](UserId) ON DELETE CASCADE,
    FOREIGN KEY (ClientId) REFERENCES [dbo].[User](UserId) ON DELETE NO ACTION
);

-- Create the 'FitnessProgram' table
CREATE TABLE [dbo].[FitnessProgram] (
    FitnessProgramId INT IDENTITY(1,1) PRIMARY KEY,
    ProgramName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(3000) NULL,
    IsTemplate BIT NOT NULL,
    UserId INT NULL,
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](UserId) ON DELETE SET NULL
);
GO

-- Reset identity seed to 0 if all rows are deleted
GO
CREATE PROCEDURE ResetIdentity (@TableName NVARCHAR(128))
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = 'DBCC CHECKIDENT(''' + QUOTENAME(@TableName) + ''', RESEED, 0)';
    EXEC sp_executesql @SQL;
END;
GO
