CREATE TABLE [dbo].[AttendanceSchemes] (
    [AttendanceSchemeId] INT             IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (250) NOT NULL,
    CONSTRAINT [PK_AttendanceSchemes] PRIMARY KEY CLUSTERED ([AttendanceSchemeId] ASC)
);

