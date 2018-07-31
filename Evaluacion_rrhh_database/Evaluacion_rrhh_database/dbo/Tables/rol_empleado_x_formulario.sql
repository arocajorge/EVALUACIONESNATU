CREATE TABLE [dbo].[rol_empleado_x_formulario] (
    [IdPeriodo]                   INT          NOT NULL,
    [Secuencia]                   INT          NOT NULL,
    [Idempleado]                  NUMERIC (18) NOT NULL,
    [Idempleado_evaluado]         NUMERIC (18) NOT NULL,
    [IdFormulario]                NUMERIC (18) NOT NULL,
    [ef_ponderacion]              FLOAT (53)   NOT NULL,
    [ef_calificacion]             FLOAT (53)   NULL,
    [ef_calificacion_ponderacion] FLOAT (53)   NULL,
    CONSTRAINT [PK_rol_empleado_x_formuulario] PRIMARY KEY CLUSTERED ([IdPeriodo] ASC, [Secuencia] ASC, [Idempleado] ASC),
    CONSTRAINT [FK_rol_empleado_x_formulario_enc_formulario] FOREIGN KEY ([IdFormulario], [IdPeriodo]) REFERENCES [dbo].[enc_formulario] ([IdFormulario], [IdPeriodo]),
    CONSTRAINT [FK_rol_empleado_x_formulario_rol_empleado] FOREIGN KEY ([Idempleado]) REFERENCES [dbo].[rol_empleado] ([IdEmpleado]),
    CONSTRAINT [FK_rol_empleado_x_formulario_rol_empleado1] FOREIGN KEY ([Idempleado_evaluado]) REFERENCES [dbo].[rol_empleado] ([IdEmpleado])
);







