--CREATE DATABASE CallAppDB;
--GO

--USE CallAppDB;
--GO

--CREATE TABLE Users (
--    Id INT IDENTITY(1,1) PRIMARY KEY,
--    UserName NVARCHAR(255) NOT NULL,
--    Password NVARCHAR(255) NOT NULL,
--    Email NVARCHAR(255) NOT NULL UNIQUE,
--    IsActive BIT NOT NULL
--);
--GO

--CREATE TABLE UserProfiles (
--    Id INT IDENTITY(1,1),
--    UserId INT NOT NULL UNIQUE,
--    FirstName NVARCHAR(255) NOT NULL,
--    LastName NVARCHAR(255) NOT NULL,
--    PersonalNumber NVARCHAR(11) NOT NULL UNIQUE,
--    CONSTRAINT FK_UserProfiles_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
--    CONSTRAINT PK_UserProfiles PRIMARY KEY (Id)
--);
--GO

CREATE PROCEDURE CreateUser
    @UserName NVARCHAR(255),
    @Password NVARCHAR(255),
    @Email NVARCHAR(255),
    @IsActive BIT
AS
BEGIN
    INSERT INTO Users (UserName, Password, Email, IsActive)
    VALUES (@UserName, @Password, @Email, @IsActive)
END
GO

CREATE PROCEDURE GetUserById
    @UserId INT
AS
BEGIN
    SELECT * FROM Users WHERE Id = @UserId
END
GO

CREATE PROCEDURE UpdateUser
    @UserId INT,
    @UserName NVARCHAR(255),
    @Email NVARCHAR(255),
    @IsActive BIT
AS
BEGIN
    UPDATE Users
    SET UserName = @UserName, Email = @Email, IsActive = @IsActive
    WHERE Id = @UserId
END
GO

CREATE PROCEDURE DeleteUser
    @UserId INT
AS
BEGIN
    DELETE FROM Users WHERE Id = @UserId
END
GO

CREATE PROCEDURE CreateUserProfile
    @UserId INT,
    @FirstName NVARCHAR(255),
    @LastName NVARCHAR(255),
    @PersonalNumber NVARCHAR(11)
AS
BEGIN
    INSERT INTO UserProfiles (UserId, FirstName, LastName, PersonalNumber)
    VALUES (@UserId, @FirstName, @LastName, @PersonalNumber)
END
GO


CREATE PROCEDURE GetUserProfileById
    @UserProfileId INT
AS
BEGIN
    SELECT * FROM UserProfiles WHERE Id = @UserProfileId
END
GO


CREATE PROCEDURE UpdateUserProfile
    @UserProfileId INT,
    @FirstName NVARCHAR(255),
    @LastName NVARCHAR(255),
    @PersonalNumber NVARCHAR(11)
AS
BEGIN
    UPDATE UserProfiles
    SET FirstName = @FirstName, LastName = @LastName, PersonalNumber = @PersonalNumber
    WHERE Id = @UserProfileId
END
GO


CREATE PROCEDURE DeleteUserProfile
    @UserProfileId INT
AS
BEGIN
    DELETE FROM UserProfiles WHERE Id = @UserProfileId
END
GO

