CREATE TABLE [dbo].[Facturas]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Id_Cliente] [int] NULL,
[IVA] [int] NULL,
[SubTotal] [decimal] (18, 2) NULL,
[Total] [decimal] (18, 2) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Facturas] ADD CONSTRAINT [PK_Faciras] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Facturas] ADD CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[Clientes] ([Id])
GO
