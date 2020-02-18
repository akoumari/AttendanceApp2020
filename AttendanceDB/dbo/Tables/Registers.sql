CREATE TABLE [dbo].[Registers] (
    [Name]               NVARCHAR (250) NOT NULL,
    [RegisterId]         INT             NOT NULL,
    [Description]        NVARCHAR (4000) NOT NULL,
    [AttendanceSchemeId] INT             NULL,
    CONSTRAINT [PK_Registers] PRIMARY KEY CLUSTERED ([RegisterId] ASC),
    CONSTRAINT [FK_Registers_AttendanceSchemes_0] FOREIGN KEY ([AttendanceSchemeId]) REFERENCES [dbo].[AttendanceSchemes] ([AttendanceSchemeId])
);

