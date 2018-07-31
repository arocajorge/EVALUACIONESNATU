CREATE TABLE [dbo].[rol_empleado_x_correo_x_periodo] (
    [IdPeriodo]      INT           NOT NULL,
    [IdEmpleado]     NUMERIC (18)  NOT NULL,
    [Secuencia]      INT           NOT NULL,
    [Correo_enviado] BIT           NULL,
    [Observacion]    VARCHAR (500) NULL,
    CONSTRAINT [PK_rol_empleado_x_correo_x_periodo] PRIMARY KEY CLUSTERED ([IdPeriodo] ASC, [IdEmpleado] ASC, [Secuencia] ASC)
);

