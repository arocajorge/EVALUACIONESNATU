CREATE TABLE [dbo].[enc_resolucion_formulario_det] (
    [IdResolucion]   NUMERIC (18) NOT NULL,
    [secuencia]      INT          NOT NULL,
    [IdPregunta]     NUMERIC (18) NOT NULL,
    [re_ponderacion] FLOAT (53)   NULL,
    CONSTRAINT [PK_enc_resolucion_formulario_det] PRIMARY KEY CLUSTERED ([IdResolucion] ASC, [secuencia] ASC),
    CONSTRAINT [FK_enc_resolucion_formulario_det_enc_formulario_pregunta] FOREIGN KEY ([IdPregunta]) REFERENCES [dbo].[enc_formulario_pregunta] ([IdPregunta]),
    CONSTRAINT [FK_enc_resolucion_formulario_det_enc_resolucion_formulario] FOREIGN KEY ([IdResolucion]) REFERENCES [dbo].[enc_resolucion_formulario] ([IdResolucion])
);

