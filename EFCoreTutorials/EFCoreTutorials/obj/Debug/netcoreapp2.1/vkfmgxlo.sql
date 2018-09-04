IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Courses] (
    [CourseId] int NOT NULL IDENTITY,
    [CourseName] nvarchar(max) NULL,
    CONSTRAINT [PK_Courses] PRIMARY KEY ([CourseId])
);

GO

CREATE TABLE [Students] (
    [StudentId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([StudentId])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180801054355_CreateSchoolDB', N'2.1.1-rtm-30846');

GO

