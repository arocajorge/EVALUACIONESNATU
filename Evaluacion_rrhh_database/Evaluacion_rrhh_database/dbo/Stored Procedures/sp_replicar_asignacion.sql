
create PROCEDURE [dbo].[sp_replicar_asignacion]  
--	-- Add the parameters for the stored procedure here
	@IdPeriodo int
AS

--declare
-- @IdPeriodo int 
-- set @IdPeriodo=5


BEGIN

declare 
 @Ultimo_periodo int,
 @MaxIdPregunta int
 select @Ultimo_periodo= max(IdPeriodo) from rol_empleado_x_formulario
 group by IdPeriodo


 delete rol_empleado_x_formulario where IdPeriodo=@IdPeriodo
 delete enc_formulario_pregunta where IdPeriodo=@IdPeriodo
 delete enc_formulario where IdPeriodo=@IdPeriodo
  --***********************************************duplicando formularios¨****************************************************************+
 insert into enc_formulario(
 IdFormulario,					IdPeriodo,		ef_codigo,								ef_descripcion,			estado
 )
select 
IdFormulario,	        		@IdPeriodo,			ef_codigo,							ef_descripcion,			estado
from enc_formulario
where IdPeriodo=@Ultimo_periodo


  --***********************************************duplicando preguntas¨****************************************************************+
 select @MaxIdPregunta= idpregunta from enc_formulario_pregunta where IdPeriodo=@Ultimo_periodo
 insert into enc_formulario_pregunta(
 IdPregunta,					IdPeriodo,		IdFormulario,								ep_descripcion,			estado,			ep_ponderacion
 )
select 
@MaxIdPregunta+(Row_number() over(order by @MaxIdPregunta)),	        		   
									@IdPeriodo,		IdFormulario,							  ep_descripcion,			estado,			ep_ponderacion
from enc_formulario_pregunta
where IdPeriodo=@Ultimo_periodo


 --***********************************************duplicando formulario por empleado¨****************************************************************+
 insert into rol_empleado_x_formulario (
 IdPeriodo,					Secuencia,				Idempleado,						Idempleado_evaluado,			IdFormulario,
 ef_ponderacion,			ef_calificacion,		ef_calificacion_ponderacion
)
select 

@IdPeriodo,	        		Secuencia,			f.Idempleado,							Idempleado_evaluado,			IdFormulario,
ef_ponderacion,				0,					0
from rol_empleado_x_formulario f, rol_empleado e
where 
f.Idempleado=e.IdEmpleado
and e.estado=1
and f.IdPeriodo= @Ultimo_periodo



 end
