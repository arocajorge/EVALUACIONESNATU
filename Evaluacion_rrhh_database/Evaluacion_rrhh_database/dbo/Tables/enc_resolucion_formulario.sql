CREATE TABLE [dbo].[enc_resolucion_formulario] (
    [IdResolucion]        NUMERIC (18) NOT NULL,
    [IdPeriodo]           INT          NOT NULL,
    [IdEmpleado]          NUMERIC (18) NOT NULL,
    [IdEmpleado_evaluado] NUMERIC (18) NOT NULL,
    [re_fecha]            DATETIME     NOT NULL,
    CONSTRAINT [PK_enc_resolucion_formulario] PRIMARY KEY CLUSTERED ([IdResolucion] ASC),
    CONSTRAINT [FK_enc_resolucion_formulario_rol_empleado] FOREIGN KEY ([IdEmpleado_evaluado]) REFERENCES [dbo].[rol_empleado] ([IdEmpleado]),
    CONSTRAINT [FK_enc_resolucion_formulario_tbl_periodo_evaluacion] FOREIGN KEY ([IdPeriodo]) REFERENCES [dbo].[tbl_periodo_evaluacion] ([IdPeriodo])
);

