CREATE TABLE [dbo].[tbl_parametros_correo] (
    [IdParametros]   INT           NOT NULL,
    [ep_correo]      VARCHAR (200) NOT NULL,
    [ep_contrasenia] VARCHAR (200) NOT NULL,
    [ep_puerto]      INT           NOT NULL,
    [ep_permite_sll] BIT           NOT NULL,
    [ep_dominio]     VARCHAR (500) NOT NULL,
    [ep_observacion] VARCHAR (800) NULL,
    CONSTRAINT [PK_tbl_parametros_correo] PRIMARY KEY CLUSTERED ([IdParametros] ASC)
);

