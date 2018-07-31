CREATE TABLE [dbo].[tbl_usuario] (
    [IdUsuario]        VARCHAR (20) NOT NULL,
    [us_contrasenia]   VARCHAR (50) NOT NULL,
    [estado]           BIT          NOT NULL,
    CONSTRAINT [PK_tbl_usuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC)
);

