using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.general;
namespace Data.general
{
   public class enc_formulario_pregunta_Data
    {
        tbl_periodo_evaluacion_Data data_periodo = new tbl_periodo_evaluacion_Data();
        public bool validar(enc_formulario_pregunta_Info i_validar, ref string msg)
        {
            try
            {
                if (i_validar.IdFormulario == 0)
                {
                    msg = "El campo formulario es obligatorio";
                    return false;
                }
                if (i_validar.ep_descripcion == null)
                {
                    msg = "El campo descripción es obligatorio";
                    return false;
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public decimal get_id()
        {
            try
            {
                decimal ID = 1;

                using (Entities_general contex = new Entities_general())
                {
                    var lst = from q in contex.enc_formulario_pregunta
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdPregunta) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(enc_formulario_pregunta_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    enc_formulario_pregunta Entity = new enc_formulario_pregunta
                    {
                        IdFormulario = info.IdFormulario,
                        IdPregunta = info.IdPregunta = get_id(),
                        ep_descripcion = info.ep_descripcion,
                        IdPeriodo = data_periodo.GetInfoPeriodoActivo().IdPeriodo,
                        ep_ponderacion = info.ep_ponderacion,
                        estado = info.estado = true,
                        ep_calificacion = info.ep_calificacion
                    };
                    contex.enc_formulario_pregunta.Add(Entity);
                    contex.SaveChanges();
                }

                return true;
            }
            catch (Exception EX)
            {

                throw;
            }
        }
        public bool modificarDB(enc_formulario_pregunta_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    enc_formulario_pregunta Entity = contex.enc_formulario_pregunta.FirstOrDefault(q => q.IdPregunta == info.IdPregunta);
                    if (Entity == null)
                        return false;
                    Entity.ep_descripcion = info.ep_descripcion;
                    Entity.ep_ponderacion = info.ep_ponderacion;
                    Entity.ep_calificacion = info.ep_calificacion;
                    contex.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(enc_formulario_pregunta_Info info)
        {
            try
            {
                using (Entities_general contex = new Entities_general())
                {
                    enc_formulario_pregunta Entity = contex.enc_formulario_pregunta.FirstOrDefault(q => q.IdPregunta == info.IdPregunta);
                    if (Entity == null)
                        return false;
                    Entity.estado = info.estado = false;
                    contex.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public enc_formulario_pregunta_Info get_info(decimal IdPregunta)
        {
            try
            {
                enc_formulario_pregunta_Info info = new enc_formulario_pregunta_Info();

                using (Entities_general contex = new Entities_general())
                {
                    enc_formulario_pregunta q = contex.enc_formulario_pregunta.FirstOrDefault(v => v.IdPregunta == IdPregunta);
                    if (q == null) return null;
                    info = new enc_formulario_pregunta_Info
                    {
                        IdFormulario = q.IdFormulario,
                        ep_descripcion = q.ep_descripcion,
                        estado = q.estado,
                        IdPeriodo = q.IdPeriodo,
                        IdPregunta = q.IdPregunta,
                        ep_ponderacion = q.ep_ponderacion,
                        ep_calificacion = q.ep_calificacion 

                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
      
        public double valiadrSumatoria(decimal IdFormulario = 0)
        {
            try
            {
                double suma = 0;
                using (Entities_general contex = new Entities_general())
                {
                    var model = (from q in contex.enc_formulario_pregunta
                                 where q.IdFormulario == IdFormulario
                                 && q.estado == true
                                 select new enc_formulario_pregunta_Info
                                 {

                                     ep_ponderacion = q.ep_ponderacion
                                 }).ToList();
                    suma = model.Sum(v => v.ep_ponderacion);
                }

                return suma;
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public List<enc_formulario_pregunta_Info> get_list( decimal IdFormulario, int IdPEriodo)
        {
            try
            {
                List<enc_formulario_pregunta_Info> lista = new List<enc_formulario_pregunta_Info>();
                using (Entities_general Context = new Entities_general())
                {
                    lista = (from q in Context.enc_formulario_pregunta
                             where q.IdFormulario == IdFormulario
                             && q.estado == true
                             && q.IdPeriodo==IdPEriodo
                             select new enc_formulario_pregunta_Info
                             {
                                 IdFormulario = q.IdFormulario,
                                 ep_descripcion = q.ep_descripcion,
                                 estado = q.estado,
                                 IdPeriodo = q.IdPeriodo,
                                 IdPregunta = q.IdPregunta,
                                 ep_ponderacion = q.ep_ponderacion,
                                 ep_calificacion = q.ep_calificacion
                             }).ToList();
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
