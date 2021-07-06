CREATE TABLE [dbo].[Clientes]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [varchar] (50) COLLATE Modern_Spanish_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Clientes', 'SCHEMA', N'dbo', 'TABLE', N'Clientes', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador cliente', 'SCHEMA', N'dbo', 'TABLE', N'Clientes', 'COLUMN', N'Id'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre cliente', 'SCHEMA', N'dbo', 'TABLE', N'Clientes', 'COLUMN', N'Nombre'
GO
