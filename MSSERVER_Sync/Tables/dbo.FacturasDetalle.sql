CREATE TABLE [dbo].[FacturasDetalle]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Id_Factura] [int] NULL,
[Id_Producto] [int] NULL,
[Cantidad] [int] NULL,
[Precio] [decimal] (18, 2) NULL,
[IVA] [int] NULL,
[SubTotal] [decimal] (18, 2) NULL,
[Total] [decimal] (18, 2) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FacturasDetalle] ADD CONSTRAINT [PK_FacturasDetalle] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FacturasDetalle] ADD CONSTRAINT [FK_FacturasDetalle_Facturas] FOREIGN KEY ([Id_Factura]) REFERENCES [dbo].[Facturas] ([Id])
GO
ALTER TABLE [dbo].[FacturasDetalle] ADD CONSTRAINT [FK_FacturasDetalle_Productos] FOREIGN KEY ([Id_Producto]) REFERENCES [dbo].[Productos] ([Id])
GO
