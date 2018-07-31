
CREATE PROCEDURE [dbo].[sp_cerrar_periodo]  
--	-- Add the parameters for the stored procedure here
	@IdPeriodo int
	
AS


--declare
-- @IdPeriodo int 
-- set @IdPeriodo=1


BEGIN

declare 


 @re_ponderacion numeric,
 @ep_ponderacion numeric,
 @Idempleado numeric,
 @IdEmpleado_evaluado numeric,
 @IdFormulario int,
 @ef_ponderacion numeric,
 @ef_calificacion numeric,
 @bandera_si_realizo_evaluacion bit
 

DECLARE Cur_empleado CURSOR FOR -- cursoe empleado, recorrer los empleados por formularios
    SELECT Idempleado,Idempleado_evaluado,IdFormulario,ef_ponderacion From rol_empleado_x_formulario
	where  IdPeriodo=@IdPeriodo;
    OPEN Cur_empleado
    FETCH NEXT FROM Cur_empleado INTO @Idempleado,@IdEmpleado_evaluado,@IdFormulario,@ef_ponderacion;
    WHILE @@FETCH_STATUS = 0
    BEGIN
    select @ef_calificacion=0,@bandera_si_realizo_evaluacion=0;
		 DECLARE Cur_preguntas CURSOR FOR -- reccorro las preguntas por empleados que han sido evaluados 
     
			 SELECT preguntas.ep_ponderacion, resolucion_det.re_ponderacion
			 FROM   dbo.enc_formulario_pregunta AS preguntas INNER JOIN
					dbo.enc_resolucion_formulario_det AS resolucion_det ON preguntas.IdPregunta = resolucion_det.IdPregunta INNER JOIN
					dbo.enc_resolucion_formulario AS resolucion ON resolucion_det.IdResolucion = resolucion.IdResolucion
					where resolucion.IdEmpleado_evaluado=@IdEmpleado_evaluado
					and IdEmpleado=@Idempleado
					and IdFormulario=@IdFormulario
					OPEN Cur_preguntas;
				FETCH NEXT FROM Cur_preguntas INTO @ep_ponderacion,@re_ponderacion;
					WHILE @@FETCH_STATUS = 0
						 BEGIN	 
							select @bandera_si_realizo_evaluacion=1-- seteo valor de uno para saber si el empleado realizo la evaluacion
							select  @ef_calificacion +=((@ep_ponderacion*@re_ponderacion))/100-- acumulo el valor por pregunta 			
							FETCH NEXT FROM Cur_preguntas INTO @ep_ponderacion,@re_ponderacion;
						 END;
						 -- actualizo el valor acumulado por las preguntas del evaluado, si el valor es mayor a cero fue evaluado
						 if(@bandera_si_realizo_evaluacion=1)
							update rol_empleado_x_formulario set ef_calificacion=@ef_calificacion, ef_calificacion_ponderacion=(ef_ponderacion*@ef_calificacion)/100
							where IdEmpleado_evaluado=@IdEmpleado_evaluado
							and IdEmpleado=@Idempleado
						    and IdFormulario=@IdFormulario ;
							else
							-- si elempleado no fue evaludo se le aplica elvalor dela ponderacion del formulario 
							update rol_empleado_x_formulario set ef_calificacion=100, ef_calificacion_ponderacion=ef_ponderacion
							where IdEmpleado_evaluado=@IdEmpleado_evaluado
							and IdEmpleado=@Idempleado
						    and IdFormulario=@IdFormulario ;

			 CLOSE Cur_preguntas;
			 DEALLOCATE Cur_preguntas;
FETCH NEXT FROM Cur_empleado INTO  @Idempleado,@IdEmpleado_evaluado,@IdFormulario,@ef_ponderacion;
END;
CLOSE Cur_empleado;
DEALLOCATE Cur_empleado;

	

-- Isertado tabla historica de calificacion global por empleado
delete enc_resolucion_calificacion where IdPeriodo=@IdPeriodo
insert into enc_resolucion_calificacion
select Idempleado_evaluado,IdPeriodo,round(SUM(ef_calificacion_ponderacion),2),1,round(SUM(ef_calificacion_ponderacion),2) from rol_empleado_x_formulario
where IdPeriodo=@IdPeriodo
group by 
Idempleado_evaluado,IdPeriodo

update enc_resolucion_calificacion set calificacion_final = 0, factor_cumplimiento = 0
where not exists(
SELECT IdPeriodo, IdEmpleado FROM enc_resolucion_formulario 
WHERE enc_resolucion_calificacion.IdPeriodo = @IdPeriodo
AND enc_resolucion_calificacion.IdEmpleado = enc_resolucion_formulario.IdEmpleado
AND enc_resolucion_formulario.IdPeriodo = @IdPeriodo
group by IdPeriodo, IdEmpleado
)

END