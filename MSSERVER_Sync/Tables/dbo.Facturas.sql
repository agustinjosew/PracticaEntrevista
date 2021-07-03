CREATE TABLE [dbo].[Facturas]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Id_Cliente] [int] NOT NULL,
[IVA] [int] NOT NULL,
[SubTotal] [decimal] (18, 2) NOT NULL,
[Total] [decimal] (18, 2) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Facturas] ADD CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Facturas] ADD CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[Clientes] ([Id])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Facturas', 'SCHEMA', N'dbo', 'TABLE', N'Facturas', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Identificador de factura generada', 'SCHEMA', N'dbo', 'TABLE', N'Facturas', 'COLUMN', N'Id'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Relacion con el Id de cliente al que se asocia la factura generada', 'SCHEMA', N'dbo', 'TABLE', N'Facturas', 'COLUMN', N'Id_Cliente'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Indice de Impuesto al Valor Agregado que tiene la factura asociada', 'SCHEMA', N'dbo', 'TABLE', N'Facturas', 'COLUMN', N'IVA'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Total menos el Iva', 'SCHEMA', N'dbo', 'TABLE', N'Facturas', 'COLUMN', N'SubTotal'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Total de factura', 'SCHEMA', N'dbo', 'TABLE', N'Facturas', 'COLUMN', N'Total'
GO
