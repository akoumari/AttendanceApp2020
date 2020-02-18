CREATE TABLE [dbo].[Statuses] (
    [StatueId]           INT             IDENTITY (1, 1) NOT NULL,
    [Symbol]             NVARCHAR (250) NOT NULL,
    [StatusName]         NVARCHAR (250) NOT NULL,
    [AssignedPercent]    INT             NOT NULL,
    [AttendanceSchemeId] INT             NULL,
    CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED ([StatueId] ASC),
    CONSTRAINT [FK_Statuses_AttendanceSchemes_0] FOREIGN KEY ([AttendanceSchemeId]) REFERENCES [dbo].[AttendanceSchemes] ([AttendanceSchemeId])
);

