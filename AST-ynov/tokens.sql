CREATE TABLE [dbo].[Users] (
    [Id]        INT           NOT NULL,
    [Email]     NVARCHAR (50) NULL,
    [CreatedAt] DATETIME      DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Token] FOREIGN KEY ([Id]) REFERENCES [dbo].[Tokens] ([Id])
);
GO
CREATE TABLE [dbo].[Tokens] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Token] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
