CREATE TABLE [dbo].[tbl_periodo_evaluacion] (
    [IdPeriodo]      INT           NOT NULL,
    [pe_fecha_ini]   DATETIME      NOT NULL,
    [pe_fecha_fin]   DATETIME      NOT NULL,
    [pe_observacion] VARCHAR (500) NULL,
    [estado]         BIT           NOT NULL,
    [estado_cierre]  BIT           NOT NULL,
    CONSTRAINT [PK_tbl_periodo_evaluacion_1] PRIMARY KEY CLUSTERED ([IdPeriodo] ASC)
);



