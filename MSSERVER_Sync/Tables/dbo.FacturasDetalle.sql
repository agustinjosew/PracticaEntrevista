CREATE TABLE [dbo].[FacturasDetalle]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Id_Factura] [int] NOT NULL,
[Id_Producto] [int] NOT NULL,
[Cantidad] [int] NOT NULL,
[Precio] [decimal] (18, 2) NOT NULL,
[IVA] [int] NOT NULL,
[SubTotal] [decimal] (18, 2) NOT NULL,
[Total] [decimal] (18, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FacturasDetalle] ADD CONSTRAINT [PK_FacturasDetalle] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FacturasDetalle] ADD CONSTRAINT [FK_FacturasDetalle_Facturas] FOREIGN KEY ([Id_Factura]) REFERENCES [dbo].[Facturas] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacturasDetalle] ADD CONSTRAINT [FK_FacturasDetalle_Productos] FOREIGN KEY ([Id_Producto]) REFERENCES [dbo].[Productos] ([Id])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Detalle de facturas generadas', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Cantidad del producto comercializado en ID factura maestra', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'Cantidad'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador detalle de factura', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'Id'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador ID asociado a factura maestra', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'Id_Factura'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador ID asociado a producto maestro', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'Id_Producto'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Impuesto valor agregado asociado a este detalle de facura', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'IVA'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Precio unitario ID producto', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'Precio'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Total suma de (ID Producto*Cantidad )', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'SubTotal'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Subtotal + IVA', 'SCHEMA', N'dbo', 'TABLE', N'FacturasDetalle', 'COLUMN', N'Total'
GO
