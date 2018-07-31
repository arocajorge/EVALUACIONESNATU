CREATE TABLE [dbo].[rol_cargo] (
    [IdCargo]        INT           NOT NULL,
    [rc_codigo]      VARCHAR (50)  NULL,
    [rc_descripcion] VARCHAR (300) NOT NULL,
    [estado]         BIT           NOT NULL,
    CONSTRAINT [PK_rol_cargo_1] PRIMARY KEY CLUSTERED ([IdCargo] ASC)
);

