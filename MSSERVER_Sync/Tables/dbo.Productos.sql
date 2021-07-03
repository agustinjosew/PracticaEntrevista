CREATE TABLE [dbo].[Productos]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [varchar] (50) COLLATE Modern_Spanish_CI_AS NULL,
[Precio] [decimal] (18, 2) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Productos] ADD CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
