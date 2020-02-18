CREATE TABLE [dbo].[ParticipantRegisters] (
    [RegisterId]    INT NOT NULL,
    [ParticipantId] INT NOT NULL,
    CONSTRAINT [PK_ParticipantRegisters] PRIMARY KEY CLUSTERED ([RegisterId] ASC, [ParticipantId] ASC),
    CONSTRAINT [FK_ParticipantRegisters_Participants_1] FOREIGN KEY ([ParticipantId]) REFERENCES [dbo].[Participants] ([ParticipantId]),
    CONSTRAINT [FK_ParticipantRegisters_Registers_0] FOREIGN KEY ([RegisterId]) REFERENCES [dbo].[Registers] ([RegisterId])
);

