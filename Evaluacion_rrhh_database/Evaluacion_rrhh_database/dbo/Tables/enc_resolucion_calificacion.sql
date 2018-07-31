CREATE TABLE [dbo].[enc_resolucion_calificacion] (
    [IdEmpleado]          NUMERIC (18) NOT NULL,
    [IdPeriodo]           INT          NOT NULL,
    [Calificacion]        FLOAT (53)   NOT NULL,
    [factor_cumplimiento] BIT          NOT NULL,
    [calificacion_final]  FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_rol_empleado_x_periodo_calificacion] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC, [IdPeriodo] ASC),
    CONSTRAINT [FK_enc_resolucion_calificacion_rol_empleado] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[rol_empleado] ([IdEmpleado]),
    CONSTRAINT [FK_enc_resolucion_calificacion_tbl_periodo_evaluacion] FOREIGN KEY ([IdPeriodo]) REFERENCES [dbo].[tbl_periodo_evaluacion] ([IdPeriodo])
);



