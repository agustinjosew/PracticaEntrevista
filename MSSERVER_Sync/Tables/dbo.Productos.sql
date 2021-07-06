CREATE TABLE [dbo].[Productos]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Nombre] [varchar] (50) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Precio] [decimal] (18, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Productos] ADD CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Lista de productos que se comercializan', 'SCHEMA', N'dbo', 'TABLE', N'Productos', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador producto', 'SCHEMA', N'dbo', 'TABLE', N'Productos', 'COLUMN', N'Id'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nombre del producto a comercializar', 'SCHEMA', N'dbo', 'TABLE', N'Productos', 'COLUMN', N'Nombre'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Precio del producto a comercializar', 'SCHEMA', N'dbo', 'TABLE', N'Productos', 'COLUMN', N'Precio'
GO
