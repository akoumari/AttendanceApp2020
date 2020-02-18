CREATE TABLE [dbo].[Participants] (
    [ParticipantId] INT             IDENTITY (1, 1) NOT NULL,
    [Email]         NVARCHAR (250) NOT NULL,
    [FirstName]     NVARCHAR (250) NOT NULL,
    [LastName]      NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_Participants] PRIMARY KEY CLUSTERED ([ParticipantId] ASC)
);

