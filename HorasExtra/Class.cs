//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HorasExtra
//{
//    public class Class
//    {
//        public static bool AddNewSolicitud(string Vacante_Aplicada, string Nombre, int Numero_Empleado, DateTime Fecha_Ingreso, string Puesto_Actual, string Turno, string Nivel_Educacion, string Experiencia, string Nivel_Ingles, string Habilidades, string Cursos_Certificaciones, string Nivel_Educacion_Actual, string CV, string Categoria, string Operacion, string Comp_Estudios, int Estatus, string Gestionado_Por, string AdjCursos, int Pending, string ComentarioSup, string ComentarioSeguimiento, DateTime Fecha_de_Postulacion, DateTime Fecha_de_Aprobacion, DateTime Fecha_de_Seguimiento, DateTime Fecha_de_Terminacion, string ComentarioTerminacion, string EmailSup)
//        {
//            bool AddR = false;
//            using (var conn = new SqlConnection(Connection.connectionString))
//            {
//                conn.Open();
//                using (var cmd = new SqlCommand("Insertar_Solicitud", conn))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@Vacante_Aplicada", Vacante_Aplicada);
//                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
//                    cmd.Parameters.AddWithValue("@Numero_Empleado", Numero_Empleado);
//                    cmd.Parameters.AddWithValue("@Fecha_Ingreso", Fecha_Ingreso);
//                    cmd.Parameters.AddWithValue("@Puesto_Actual", Puesto_Actual);
//                    cmd.Parameters.AddWithValue("@Turno", Turno);
//                    cmd.Parameters.AddWithValue("@Nivel_Educacion", Nivel_Educacion);
//                    cmd.Parameters.AddWithValue("@Experiencia", Experiencia);
//                    cmd.Parameters.AddWithValue("@Nivel_Ingles", Nivel_Ingles);
//                    cmd.Parameters.AddWithValue("@Habilidades", Habilidades);
//                    cmd.Parameters.AddWithValue("@Cursos_Certificaciones", Cursos_Certificaciones);
//                    cmd.Parameters.AddWithValue("@Nivel_Educacion_Actual", Nivel_Educacion_Actual);
//                    cmd.Parameters.AddWithValue("@CV", CV);
//                    cmd.Parameters.AddWithValue("@Categoria", Categoria);
//                    cmd.Parameters.AddWithValue("@Operacion", Operacion);
//                    cmd.Parameters.AddWithValue("@Comp_Estudios", Comp_Estudios);
//                    cmd.Parameters.AddWithValue("@Estatus", Estatus);
//                    cmd.Parameters.AddWithValue("@Gestionado_Por", Gestionado_Por);
//                    cmd.Parameters.AddWithValue("@AdjCursos", AdjCursos);
//                    cmd.Parameters.AddWithValue("@Pending", Pending);
//                    cmd.Parameters.AddWithValue("@ComentarioSup", ComentarioSup);
//                    cmd.Parameters.AddWithValue("@ComentarioSeguimiento", ComentarioSeguimiento);
//                    cmd.Parameters.AddWithValue("@Fecha_de_Postulacion", Fecha_de_Postulacion);
//                    cmd.Parameters.AddWithValue("@Fecha_de_Aprobacion", "");
//                    cmd.Parameters.AddWithValue("@Fecha_de_Seguimiento", "");
//                    cmd.Parameters.AddWithValue("@Fecha_de_Terminacion", "");
//                    cmd.Parameters.AddWithValue("@ComentarioTerminacion", ComentarioTerminacion);
//                    try
//                    {
//                        var rd = cmd.ExecuteNonQuery();


//                        /*Correo*/

//                        string htmlBody = string.Empty;
//                        htmlBody += $"<!DOCTYPE html>";
//                        htmlBody += $"<html>";
//                        htmlBody += $"<head>";
//                        htmlBody += $"<style>" +
//                            "table{width:100%; border-collapse:collapse; margin-top: 0;}" +
//                            "td, th {padding:6px; text-align:left;}" +
//                            "th {background-color:#0275d8; color: whitesmoke;}" +
//                            "hr {background-color:#0275d8; color:#0275d8;}" +
//                            "div{background-color:#0275d8; color: whitesmoke; text-align:center; padding:6; margin-bottom: 0;}" +
//                            ".badgePreventivo{padding:15px;background-color:#0984e3; color:white; border-radius:5px;}" +
//                            ".badgeOptiFleet{padding:15px;background-color:#636e72; color:white; border-radius:5px;}" +
//                            $"</style>";
//                        htmlBody += $"</head>";
//                        htmlBody += $"<body>";
//                        htmlBody += $"<div>";
//                        htmlBody += $"<h1>Aprobacion pendiente</h1> <hr class='my-0'>";
//                        htmlBody += $"</div>";
//                        htmlBody += $"<table> ";

//                        //HEAD
//                        htmlBody += $"<thead>";
//                        htmlBody += $"<tr>";
//                        htmlBody += $"<th><h4>Nombre:</h4></th>";
//                        htmlBody += $"<th><h4>Puesto Aplicado:</h4></th>";
//                        htmlBody += $"<th><h4>Operacion:</h4></th>";
//                        htmlBody += $"<th><h4>Categoria:</h4></th>";
//                        htmlBody += $"<th><h4>Fecha:</h4></th>";
//                        htmlBody += $"<th><h4>Revisar</h4></th>";
//                        htmlBody += $"</tr>";
//                        htmlBody += $"</thead>";
//                        //BODY


//                        htmlBody += $"<tbody>";
//                        string copias = string.Empty;
//                        for (int i = 0; i < 1; i++)
//                        {
//                            //copias += "saguero@amphenol-optimize.com" + ", ";
//                            copias += EmailSup + ", ";
//                        }



//                        var evento = db2.Solicitudes.OrderByDescending(s => s.Id_Vacante).FirstOrDefault();
//                        if (evento != null)
//                        {

//                            //string link = String.Format("<a href=\"http://localhost:49885/Home/ConfirmacionEmail?eventoid={0}\">Revisar</a>", evento.Id_Vacante);
//                            //string link = String.Format("<a href=\"http://prowl:8080/OptiVacantes/Home/ConfirmacionEmail?eventoid={0}\">Revisar</a>", evento.Id_Vacante);
//                            string link = String.Format("<a href=\"https://apps.amphenol-optimize.com/OptiVacantes/Home/ConfirmacionEmail?eventoid={0}\">Revisar</a>", evento.Id_Vacante);

//                            htmlBody += $"<tr>";
//                            htmlBody += $"<td style='text-decoration: underline;font-weight:bold;'>{evento.Nombre}</td>  ";
//                            htmlBody += $"<td>{evento.Vacante_Aplicada }</td> ";
//                            htmlBody += $"<td style='text-decoration: underline;'>{evento.Operacion }</td> ";
//                            htmlBody += $"<td style='text-decoration: underline;'>{evento.Categoria }</td> ";
//                            htmlBody += $"<td style='text-decoration: underline;'>{evento.Fecha_de_Postulacion }</td> ";
//                            htmlBody += $"<td>{link}</td>";
//                            htmlBody += $"</tr>";

//                            if (!string.IsNullOrEmpty(copias))
//                            {
//                                copias = copias.Remove(copias.Length - 2, 2);
//                            }
//                            htmlBody += "</tbody>";
//                            htmlBody += $"</table>";
//                            htmlBody += $"</body>";
//                            htmlBody += $"<hr class='my-0'>";

//                            htmlBody += $"<h2>Nota: Este es un correo autogenerado por el sistema OptiVacantes, favor de no responder a este correo.</h2>";

//                            htmlBody += $"</html>";
//                            //EnviarCorreo("Aprobacion pendiente", htmlBody, "saguero@amphenol-optimize.com", copias);
//                            EnviarCorreo("Aprobacion pendiente", htmlBody, EmailSup, copias);
//                        }
//                        /*Correo*/

//                        return true;
//                        //AddR = rd > 0 ? true : false;
//                    }
//                    catch (Exception)
//                    {
//                        return false;
//                    }



//                }
//            }




//            //return AddR;



//        }

//        ///////


//        //ObtenerEmailSupervisor
//        function ObtenerEmailaSup(CB_CODIGO)
//        {
//            $.post('@Url.Action("ObtenerEmail", "Home")', { CB_CODIGO: CB_CODIGO}, function(data) {
//                $.each(data, function(i, v) {
//                    var Email = v.Email;
//                    SistemasConsole(CB_CODIGO, Email);
//                });

//            });
//        }


//        public static List<EmailSup> ObtenerEmails(int CB_CODIGO)
//        {
//            List<EmailSup> infoList = new List<EmailSup>();
//            using (var conn = new SqlConnection(Connections))
//            {
//                conn.Open();
//                using (SqlCommand command = new SqlCommand("SP_Supervisor", conn))
//                {
//                    command.CommandType = CommandType.StoredProcedure;
//                    command.Parameters.AddWithValue("@CB_CODIGO", CB_CODIGO);
//                    command.CommandTimeout = 0;
//                    using (SqlDataReader CL = command.ExecuteReader())
//                    {
//                        while (CL.Read())
//                        {
//                            try
//                            {
//                                var Info = new EmailSup();
//                                Info.FullName = (string)CL["FullName"];
//                                Info.Email = (string)CL["Email"];

//                                infoList.Add(Info);
//                            }
//                            catch (Exception ex)
//                            {
//                                string msg = ex.Message;
//                            }

//                        }
//                    }
//                    return infoList;
//                }
//            }
//        }

//    }
//}
