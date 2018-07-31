CREATE TABLE [dbo].[enc_formulario] (
    [IdFormulario]   NUMERIC (18)   NOT NULL,
    [IdPeriodo]      INT            NOT NULL,
    [ef_codigo]      VARCHAR (50)   NULL,
    [ef_descripcion] VARCHAR (1000) NOT NULL,
    [estado]         BIT            NOT NULL,
    CONSTRAINT [PK_enc_formulario_1] PRIMARY KEY CLUSTERED ([IdFormulario] ASC, [IdPeriodo] ASC),
    CONSTRAINT [FK_enc_formulario_tbl_periodo_evaluacion] FOREIGN KEY ([IdPeriodo]) REFERENCES [dbo].[tbl_periodo_evaluacion] ([IdPeriodo])
);



