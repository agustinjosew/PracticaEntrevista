CREATE TABLE [dbo].[Clientes]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [varchar] (50) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
