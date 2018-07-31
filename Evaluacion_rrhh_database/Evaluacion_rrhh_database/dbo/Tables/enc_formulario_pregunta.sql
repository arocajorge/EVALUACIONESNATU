CREATE TABLE [dbo].[enc_formulario_pregunta] (
    [IdPregunta]     NUMERIC (18)   NOT NULL,
    [IdPeriodo]      INT            NOT NULL,
    [IdFormulario]   NUMERIC (18)   NOT NULL,
    [ep_descripcion] VARCHAR (1000) NOT NULL,
    [estado]         BIT            NOT NULL,
    [ep_ponderacion] FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_enc_formulario_pregunta] PRIMARY KEY CLUSTERED ([IdPregunta] ASC),
    CONSTRAINT [FK_enc_formulario_pregunta_enc_formulario] FOREIGN KEY ([IdFormulario], [IdPeriodo]) REFERENCES [dbo].[enc_formulario] ([IdFormulario], [IdPeriodo])
);





