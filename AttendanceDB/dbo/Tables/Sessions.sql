CREATE TABLE [dbo].[Sessions] (
    [SessionId]   INT             IDENTITY (1, 1) NOT NULL,
    [SessionName] NVARCHAR (250) NOT NULL,
    [Description] NVARCHAR (4000) NOT NULL,
    [RegisterId]  INT             NULL,
    CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED ([SessionId] ASC),
    CONSTRAINT [FK_Sessions_Registers_0] FOREIGN KEY ([RegisterId]) REFERENCES [dbo].[Registers] ([RegisterId])
);

