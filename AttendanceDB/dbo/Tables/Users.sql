CREATE TABLE [dbo].[Users] (
    [UserId]    INT             IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (250) NOT NULL,
    [LastName]  NVARCHAR (250) NOT NULL,
    [Email]     NVARCHAR (250) NOT NULL,
    [Address]   NVARCHAR (250) NOT NULL,
    [Password]  NVARCHAR (250) NOT NULL,
    [Role] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

