CREATE TABLE [dbo].[Usuario] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [NomeUsuario] NVARCHAR (100) NULL,
    [Login]       NVARCHAR (20)  NULL,
    [Salt]        NVARCHAR (10)  NULL,
    [Hash]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);