using Microsoft.Extensions.Configuration;
using OneCore.API.DataModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace OneCore.API.Services
{
    public static class EmailSender
    {
        private static string from = "pruebaonecore@gmail.com";
        private static string displayName = "One Core Team";
        private static string subject = "Carga de productos";
        private static string SMTPCliente = "smtp.gmail.com";
        private static int SMTPPort = 587;
        private static string password = "";
        private static string filename = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Excel")["Local"];

        public static bool EnviarCorreo(Cliente cliente,List<Producto> productos)
        {            
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(cliente.CorreoContacto);
                mail.Subject = subject;
                mail.Body = BodyHTML(cliente, productos);
                mail.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(SMTPCliente, SMTPPort);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(from, password);
                client.EnableSsl = true;
                client.Send(mail);
                client.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool EnviarCorreoAdjunto(Cliente cliente, int cantidadProductos)
        {
            Attachment data = new Attachment(filename, MediaTypeNames.Application.Octet);
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(cliente.CorreoContacto);
                mail.Subject = subject;
                mail.Body = BodyHTMLAdjunto(cliente, cantidadProductos);
                mail.IsBodyHtml = true;
                mail.Attachments.Add(data);

                EnviarCorreo(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static void EnviarCorreo(MailMessage mail) 
        {
            SmtpClient client = new SmtpClient(SMTPCliente, SMTPPort);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(from, password);
            client.EnableSsl = true;
            client.Send(mail);
            client.Dispose();
        }

        private static string BodyHTML(Cliente cliente, List<Producto> productos) 
        {
            string tr = string.Empty;
            foreach (var item in productos)
            {
                tr += "<tr>" +
                        "<td> " + item.Descripcion + " </td>" +
                        "<td> " + item.Cantidad + " </td>" +
                        "<td> " + item.Precio + " </td>" +
                        "<td> " + item.Total + " </td>" +
                        "</tr>";
            }
            string estilos = @"<!DOCTYPE html>
                            <html>
                              <head>
                                <title>Hello World!</title>
                                <link rel=""stylesheet"" href=""styles.css"" />
                              </head>
                              <style>
                              body{
                                        padding: 25px;
                             }
                            .title{
                                        color: #5C6AC4;
                            }
                            
                            #productos{
                                        font-family: Arial, Helvetica, sans-serif;
                                        border-collapse: collapse;
                                    width:100%;
                                    }
                            
                            #productos td, #productos th{
                                    border: 1px solid #ddd;
                              padding: 8px;
                            }
                            
                            #productos tr:nth-child(even){background-color: #f2f2f2;}
                            
                            #productos tr:hover {background-color: #ddd;}
                            
                            #productos th{
                                padding-top: 12px;
                              padding-bottom: 12px;
                              text-align: left;
                              background-color: #04AA6D;
                              color: white;
                            }
                              </style> ";

                        string body = @"<body>
                  <h3 class=""title"">"+DateTime.Now+ @"</h3>
                  <h3 class=""title"">Estimado cliente: " + cliente.Nombre + @" </h3>
                  <h3 class=""title"">Se han agregado " + productos.Count+@" productos</h3>
              <table id=""productos"">
              <tr>
                <th> Cantidad </th>
                <th> Descripcion </th>
                <th> Precio unitario</th>
                <th>Total</th>
              </tr>
              "+tr+@"
            </table>
              </body>
            </html>";          


            return $"{estilos}{body}";

        }

        private static string BodyHTMLAdjunto(Cliente cliente, int cantidadProductos) 
        {
            string estilos = @"<!DOCTYPE html>
                            <html>
                              <head>
                                <title>Hello World!</title>
                                <link rel=""stylesheet"" href=""styles.css"" />
                              </head>
                              <style>
                              body{
                                        padding: 25px;
                             }
                            .title{
                                        color: #5C6AC4;
                            }
                            
                            #productos{
                                        font-family: Arial, Helvetica, sans-serif;
                                        border-collapse: collapse;
                                    width:100%;
                                    }
                            
                            #productos td, #productos th{
                                    border: 1px solid #ddd;
                              padding: 8px;
                            }
                            
                            #productos tr:nth-child(even){background-color: #f2f2f2;}
                            
                            #productos tr:hover {background-color: #ddd;}
                            
                            #productos th{
                                padding-top: 12px;
                              padding-bottom: 12px;
                              text-align: left;
                              background-color: #04AA6D;
                              color: white;
                            }
                              </style> ";

            string body = @"<body>
                  <h3 class=""title"">" + DateTime.Now + @"</h3>
                  <h3 class=""title"">Estimado cliente: "+ cliente.Nombre +@" </h3>
                  <h3 class=""title"">Se han agregado " + cantidadProductos + @" productos</h3>              
              </body>
            </html>";
            return $"{estilos}{body}";
        }
    }
}
