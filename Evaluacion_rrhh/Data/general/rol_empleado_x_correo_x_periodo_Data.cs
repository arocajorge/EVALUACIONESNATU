using System;
using System.Collections.Generic;
using System.Linq;
using Info.general;
using System.Net;
using System.Net.Mail;
namespace Data.general
{
  public  class rol_empleado_x_correo_x_periodo_Data
    {
        public bool EnviarCorreo(List<rol_empleado_Info> lista)
        {
            try
            {
                int sec = 0;
                tbl_parametros_correo_Info infoParametros = new tbl_parametros_correo_Info();
                tbl_parametros_correo_Data data = new tbl_parametros_correo_Data();

                infoParametros = data.GetInfo();

                using (Entities_general entity = new Entities_general())
                {
                    foreach (var item in lista)
                    {
                        sec++;
                        rol_empleado_x_correo_x_periodo infocorreo = new rol_empleado_x_correo_x_periodo();
                        MailMessage mail = new MailMessage();
                        mail.To.Add(item.re_correo);
                        mail.From = new MailAddress(infoParametros.ep_correo);
                        mail.Subject = "Evaluación de personal";

                        string Body = "Estimado colaborador \n";
                        Body += "Saludos \n";
                        Body += "DEGERENCIA LES INVITA A REALIZAR LA EVALUACIÓN PARA SUS COMPAÑEROS DE LABORES QUE TENDRA COMO FECHA INICIO" + item.fechaI.ToString().Substring(0, 10) + " HASTA " + item.fechaF.ToString().Substring(0, 10);
                        Body += "PARA REALIZAR LA EVALUACIÓN DEBE ACCEDER AL SIGUIENTE LINK \n";

                        Body += "http://encuestas.degeremcia.com/ \n";
                        Body += "Usuario:  " + item.re_codigo;
                        Body += "Contraseña:  " + item.re_cedula;


                        mail.Body = Body;
                        mail.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = infoParametros.ep_dominio;
                        smtp.EnableSsl = infoParametros.ep_permite_sll;
                        smtp.Port = infoParametros.ep_puerto;
                        smtp.Credentials = new NetworkCredential(infoParametros.ep_correo, infoParametros.ep_contrasenia);
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        try
                        {
                            smtp.Send(mail);
                        }
                        catch (Exception ex)
                        {

                            // Guardar envio de Correo
                            infocorreo.IdEmpleado = item.IdPeriodo;
                            infocorreo.IdEmpleado = item.IdEmpleado;
                            infocorreo.Secuencia = sec;
                            infocorreo.Correo_enviado = false;
                            infocorreo.Observacion = "Notificación enviada ha " + item.re_apellidos + " " + item.re_nombres;
                            entity.rol_empleado_x_correo_x_periodo.Add(infocorreo);
                        }
                        // Guardar envio de Correo
                        infocorreo.IdEmpleado = item.IdPeriodo;
                        infocorreo.IdEmpleado = item.IdEmpleado;
                        infocorreo.Secuencia = sec;
                        infocorreo.Correo_enviado = true;
                        infocorreo.Observacion = "Notificación enviada ha " + item.re_apellidos + " " + item.re_nombres;
                        entity.rol_empleado_x_correo_x_periodo.Add(infocorreo);
                    }
                    entity.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<rol_empleado_Info> GetList_emp_a_notificar()
        {

            try
            {

                List<rol_empleado_Info> lista = new List<rol_empleado_Info>();
                using (Entities_general entity = new Entities_general())
                {

                    lista = (from emp_evalua in entity.rol_empleado
                             join emp_x_form in entity.rol_empleado_x_formulario
                             on emp_evalua.IdEmpleado equals emp_x_form.Idempleado

                             join cargo in entity.rol_cargo
                             on emp_evalua.IdCargo equals cargo.IdCargo

                             join periodo in entity.tbl_periodo_evaluacion
                             on emp_x_form.IdPeriodo equals periodo.IdPeriodo
                             where periodo.estado_cierre == false

                             group emp_evalua by new { emp_evalua, cargo, periodo } into nuevo
                             select new rol_empleado_Info
                             {
                                 IdEmpleado = nuevo.Key.emp_evalua.IdEmpleado,
                                 re_codigo = nuevo.Key.emp_evalua.re_codigo,
                                 re_cedula = nuevo.Key.emp_evalua.re_cedula,
                                 re_nombres = nuevo.Key.emp_evalua.re_nombres,
                                 re_apellidos = nuevo.Key.emp_evalua.re_nombres,
                                 re_correo = nuevo.Key.emp_evalua.re_correo,
                                 IdPeriodo = nuevo.Key.periodo.IdPeriodo,
                                 Cargo = nuevo.Key.cargo.rc_descripcion,
                                 fechaI = nuevo.Key.periodo.pe_fecha_ini,
                                 fechaF = nuevo.Key.periodo.pe_fecha_fin



                             }

                        ).ToList();

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool GuardarDB()
        {
            try
            {

                using (Entities_general contex=new Entities_general())
                {


                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool EnviarCorreo(rol_empleado_Info item)
        {
            try
            {
                int sec = 0;
                tbl_parametros_correo_Info infoParametros = new tbl_parametros_correo_Info();
                tbl_parametros_correo_Data data = new tbl_parametros_correo_Data();

                infoParametros = data.GetInfo();

                using (Entities_general entity = new Entities_general())
                {

                    sec++;
                    rol_empleado_x_correo_x_periodo infocorreo = new rol_empleado_x_correo_x_periodo();
                    MailMessage mail = new MailMessage();
                    mail.To.Add(item.re_correo);
                    mail.From = new MailAddress(infoParametros.ep_correo);
                    mail.Subject = "Evaluación de personal";

                    string Body = "Estimado colaborador <br/><br/>";
                    Body += "Degeremcia le invita a evaluar a sus compañeros de labores durante el periodo de evaluación vigente:";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "<table>";
                    Body += "<tr>";
                    Body += "<td><strong>Fecha inicio:</strong></td>";
                    Body += "<td><strong>" + item.fechaI.ToShortDateString() + "</strong></td>";                    
                    Body += "</tr>";
                    Body += "<tr>";
                    Body += "<td><strong>Fecha fin:</strong></td>";
                    Body += "<td><strong>" + item.fechaF.ToShortDateString() + "</strong></td>";
                    Body += "</tr>";
                    Body += "</table>";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "Para realizar la evaluación debe acceder al siguiente link:<br/><br/>";
                    Body += "<a href='http://evaluaciones.degeremcia.com/" + "Resolucion_formulario/LoginID?p1=" + item.IdEmpleado + "'>Encuestar colaboradores</a>";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "<table>";
                    Body += "<tr>";
                    Body += "<td><strong>Usuario:</strong></td>";
                    Body += "<td>" + item.re_codigo + "</td>";
                    Body += "</tr>";
                    Body += "<tr>";
                    Body += "<td><strong>Contraseña:</strong></td>";
                    Body += "<td>" + item.re_cedula + "</td>";
                    Body += "</tr>";
                    Body += "</table>";


                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
                    mail.AlternateViews.Add(htmlView);

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = infoParametros.ep_dominio;
                    smtp.EnableSsl = infoParametros.ep_permite_sll;
                    smtp.Port = infoParametros.ep_puerto;
                    smtp.Credentials = new NetworkCredential(infoParametros.ep_correo, infoParametros.ep_contrasenia);
                    smtp.Send(mail);

                    // Guardar envio de Correo
                    infocorreo.IdPeriodo = item.IdPeriodo;
                    infocorreo.IdEmpleado = item.IdEmpleado;
                    infocorreo.Secuencia = sec;
                    infocorreo.Correo_enviado = true;
                    infocorreo.Observacion = "Notificación enviada ha " + item.re_apellidos + " " + item.re_nombres;
                    entity.rol_empleado_x_correo_x_periodo.Add(infocorreo);
                    var empleado = entity.rol_empleado.Where(q => q.IdEmpleado == item.IdEmpleado).FirstOrDefault();
                    if (empleado != null)
                    {
                        empleado.FechaUltCorreo = DateTime.Now;
                    }

                    entity.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
