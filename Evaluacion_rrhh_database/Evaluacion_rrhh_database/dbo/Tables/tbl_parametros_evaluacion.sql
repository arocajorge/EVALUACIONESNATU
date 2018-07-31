CREATE TABLE [dbo].[tbl_parametros_evaluacion] (
    [Id]                     INT            NOT NULL,
    [enc_tipografia_letra]   VARCHAR (50)   NOT NULL,
    [enc_tipografia_color]   VARCHAR (50)   NOT NULL,
    [enc_tipografia_tamanio] VARCHAR (50)   NOT NULL,
    [mensaje_enc_finalizada] VARCHAR (MAX)  NOT NULL,
    [observacion]            VARCHAR (1000) NULL,
    [enc_fondo]              VARCHAR (300)  NULL,
    [enc_logo]               VARCHAR (300)  NULL,
    [enc_fondo_frontal]      VARCHAR (300)  NULL,
    [enc_imagen_cabecera]    VARCHAR (300)  NULL,
    CONSTRAINT [PK_tbl_parametros_evaluacion] PRIMARY KEY CLUSTERED ([Id] ASC)
);

