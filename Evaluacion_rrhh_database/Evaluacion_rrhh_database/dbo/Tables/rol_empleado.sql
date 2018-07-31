CREATE TABLE [dbo].[rol_empleado] (
    [IdEmpleado]   NUMERIC (18)  NOT NULL,
    [re_codigo]    VARCHAR (50)  NULL,
    [re_apellidos] VARCHAR (200) NOT NULL,
    [re_nombres]   VARCHAR (200) NOT NULL,
    [re_cedula]    VARCHAR (20)  NOT NULL,
    [re_correo]    VARCHAR (200) NOT NULL,
    [re_telefonos] VARCHAR (200) NULL,
    [re_direccion] VARCHAR (500) NULL,
    [IdCargo]      INT           NOT NULL,
    [estado]       BIT           NOT NULL,
    CONSTRAINT [PK_rol_empleado_1] PRIMARY KEY CLUSTERED ([IdEmpleado] ASC),
    CONSTRAINT [FK_rol_empleado_rol_cargo] FOREIGN KEY ([IdCargo]) REFERENCES [dbo].[rol_cargo] ([IdCargo])
);



