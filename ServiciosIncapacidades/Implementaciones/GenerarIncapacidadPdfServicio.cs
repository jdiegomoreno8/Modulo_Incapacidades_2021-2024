using iTextSharp.text;
using iTextSharp.text.pdf;
using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Globalization;
using System.IO;

namespace ServiciosIncapacidades
{
    public class GenerarIncapacidadPdfServicio : IGenerarIncapacidadPdfServicio
    {

        public MemoryStream GenerarPDF(Incapacidad incapacidad, string pathResources)
        {
            //Se agrega la plantilla
            //Document se exporte de la libreria de itextsharp//Se crea el documento es en ta parte
            Document documento = new Document();
            //tamaño de la página
            documento.SetPageSize(PageSize.Letter);
            //documento.SetMargins(points to cm);

            //Generar el archivo en la memoria RAM 
            MemoryStream archivo = new MemoryStream();


            //Línea de código que escribe el archivo
            PdfWriter escritura = PdfWriter.GetInstance(documento, archivo);
            escritura.CloseStream = false;
            //Se le puede agregar metadatos 
            //documento.AddAuthor("José Fernando Ospina Moreno");
            documento.AddTitle("Incapacidad Paciente");

            //Permite abrir el documento y hacer lectura de su contenido
            documento.Open();

            //Prueba



            //Fin prueba       


            try
            {

                #region

                //Agregar los estilos y fuentes***************************************************** 
                BaseFont fuente = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, true);
                iTextSharp.text.Font Titulo = new iTextSharp.text.Font(fuente, 16f, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font parrafo1 = new iTextSharp.text.Font(fuente, 8f, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font titulofranja = new iTextSharp.text.Font(fuente, 12f, iTextSharp.text.Font.BOLD);//,new BaseColor(255, 255, 255)

                iTextSharp.text.Font parrafo2 = new iTextSharp.text.Font(fuente, 10f, iTextSharp.text.Font.BOLD);

                iTextSharp.text.Font parrafo3 = new iTextSharp.text.Font(fuente, 10f);// iTextSharp.text.Font.TIMES_ROMAN);



                #endregion



                //******************Encabezado**********************************************
                #region        


                //Agregar imagenes
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine(pathResources, "img", "logo.png"));
                logo.ScalePercent(30);//Tamaño de la imagen
                var tbl = new PdfPTable(new float[] { 60f, 90f }) { WidthPercentage = 100 };
                var c1 = new PdfPCell(logo) { Border = 0 };
                var c2 = new PdfPCell(new Phrase("CERTIFICADO INCAPACIDAD", Titulo)) { Border = 0 };

                c2.VerticalAlignment = Element.ALIGN_CENTER;

                tbl.AddCell(c1);
                tbl.AddCell(c2);
                documento.Add(tbl);


                //var tabla1 = new PdfPTable(new float[] { 30f, 50f}) { WidthPercentage = 100 };
                ////Agregar imagenes
                //iTextSharp.text.Image logo3 = iTextSharp.text.Image.GetInstance(Path.Combine(@"C:\ProyectoV920220328\WebApiIncapacidades20220328\WebApiIncapacidades", "img", "logo.png"));
                //logo3.ScalePercent(10);

                //tabla1.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 2 });
                //    tabla1.AddCell(new PdfPCell(new Phrase("FORMATO INCAPACIDAD", Titulo)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });                     
                //    documento.Add(tabla1);
                //    documento.Add(new Phrase(""));
                //Celda vacia
                var tablavacia = new PdfPTable(new float[] { 30f }) { WidthPercentage = 100 };
                tablavacia.AddCell(new PdfPCell(new Phrase("       ", Titulo)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                documento.Add(tablavacia);

                #endregion

                //************************Información paciente******************************+
                #region
                var tablaincapacidad = new PdfPTable(new float[] { 30f, 30f }) { WidthPercentage = 100 };
                tablaincapacidad.AddCell(new PdfPCell(new Phrase("Número de Incapacidad: " + incapacidad.id_incapacidad, parrafo1)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tablaincapacidad.AddCell(new PdfPCell(new Phrase("Fecha Expedición: " + incapacidad.fecha_expedicion, parrafo1)) { Border = 0, VerticalAlignment = Element.ALIGN_RIGHT, HorizontalAlignment = Element.ALIGN_RIGHT });
                documento.Add(tablaincapacidad);

                //Celda vacia
                var tablavacia1 = new PdfPTable(new float[] { 30f }) { WidthPercentage = 100 };
                tablavacia1.AddCell(new PdfPCell(new Phrase("      ", Titulo)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                documento.Add(tablavacia1);
                documento.Add(new Phrase(""));


                var tablainfopaciente = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100 };
                    tablainfopaciente.AddCell(new PdfPCell(new Phrase("INFORMACIÓN DEL PACIENTE", titulofranja)) { Border = 0, BorderColor= new BaseColor(0, 72, 132), Padding=10f, BorderWidthBottom=2f ,VerticalAlignment = Element.ALIGN_TOP,  HorizontalAlignment = Element.ALIGN_TOP });//BackgroundColor = new BaseColor(0, 72, 132),modificado el día 2022/05/04
                
                    tablainfopaciente.AddCell(new PdfPCell(new Phrase("DATOS DE LA INCAPACIDAD", titulofranja)) { Border=0, Padding = 10f, BorderColor = new BaseColor(0, 72, 132), BorderWidthBottom=2f, VerticalAlignment = Element.ALIGN_TOP,  HorizontalAlignment = Element.ALIGN_TOP });//BackgroundColor = new BaseColor(0, 72, 132),
                                   
                    documento.Add(tablainfopaciente);

                //Celda info paciente
                var tabla2 = new PdfPTable(new float[] { 60f, 45f }) { WidthPercentage = 100 };
                tabla2.AddCell(new PdfPCell(new Phrase("Nombre ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                tabla2.AddCell(new PdfPCell(new Phrase("Fecha inicio ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                tabla2.AddCell(new PdfPCell(new Phrase(incapacidad.primer_nombre_pac + " " + incapacidad.segundo_nombre_pac + " " + incapacidad.primer_apellido_pac + " " + incapacidad.segundo_apellido_pac, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                tabla2.AddCell(new PdfPCell(new Phrase(incapacidad.fecha_inicio.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                tabla2.AddCell(new PdfPCell(new Phrase("Identificación ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                tabla2.AddCell(new PdfPCell(new Phrase("Fecha fin ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                tabla2.AddCell(new PdfPCell(new Paragraph(incapacidad.TipoDocumento.cod_tipo_documento + " " + incapacidad.numero_documento_pac, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla2.AddCell(new PdfPCell(new Paragraph(incapacidad.fecha_fin.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla2.AddCell(new PdfPCell(new Paragraph("Ciudad de expedición", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla2.AddCell(new PdfPCell(new Paragraph("Días de incapacidad", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla2.AddCell(new PdfPCell(new Paragraph(incapacidad.lugar_expedicion_descripcion, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla2.AddCell(new PdfPCell(new Paragraph(incapacidad.dias_incapacidad.ToString(), parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                documento.Add(tabla2);


                ////Formato anterior
                //var tabladatospaciente = new PdfPTable(new float[] { 30f, 30f, 30f }) { WidthPercentage = 100 };
                //    tabladatospaciente.AddCell(new PdfPCell(new Phrase("Nombre", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tabladatospaciente.AddCell(new PdfPCell(new Phrase("Prueba", parrafo3)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tabladatospaciente.AddCell(new PdfPCell(new Paragraph("Identificación", parrafo2)) {Rowspan=3, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                //    tabladatospaciente.AddCell(new PdfPCell(new Paragraph("Ciudad de expedición", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //    tabladatospaciente.AddCell(new PdfPCell(new Paragraph(incapacidad.primer_nombre_pac + " " + incapacidad.segundo_nombre_pac + " " + incapacidad.primer_apellido_pac + " " + incapacidad.segundo_apellido_pac, parrafo3)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                //    tabladatospaciente.AddCell(new PdfPCell(new Paragraph(incapacidad.TipoDocumento.cod_tipo_documento + " " + incapacidad.numero_documento_pac, parrafo3)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //    tabladatospaciente.AddCell(new PdfPCell(new Paragraph(incapacidad.lugar_expedicion, parrafo3)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                //    //documento.Add(Chunk.Newline);
                //    documento.Add(tabladatospaciente);


                #endregion



                //Celda vacia
                var tablavacia2 = new PdfPTable(new float[] { 30f }) { WidthPercentage = 100 };
                tablavacia2.AddCell(new PdfPCell(new Phrase("      ", Titulo)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                documento.Add(tablavacia2);

                //**************Datos Incapacidad*******************++
                #region

                //var tabladatosincapacidad = new PdfPTable(new float[] { 50f }) { WidthPercentage = 100 };
                //    tabladatosincapacidad.AddCell(new PdfPCell(new Phrase("DATOS INCAPACIDAD", titulofranja)) { VerticalAlignment = Element.ALIGN_LEFT, BackgroundColor = new BaseColor(229, 238, 251) });

                //    //documento.Add(Chunk.Newline);
                //    documento.Add(tabladatosincapacidad);

                //var tablafechas = new PdfPTable(new float[] { 30f, 30f, 30f }) { WidthPercentage = 100 };
                //tablafechas.AddCell(new PdfPCell(new Phrase("Fecha inicio", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tablafechas.AddCell(new PdfPCell(new Paragraph("Fecha fin ", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                //tablafechas.AddCell(new PdfPCell(new Paragraph("Días de incapacidad", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tablafechas.AddCell(new PdfPCell(new Paragraph(incapacidad.fecha_inicio.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), parrafo3)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                //tablafechas.AddCell(new PdfPCell(new Paragraph(incapacidad.fecha_fin.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), parrafo3)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tablafechas.AddCell(new PdfPCell(new Paragraph(incapacidad.dias_incapacidad.ToString(), parrafo3)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                ////documento.Add(Chunk.Newline);
                //documento.Add(tablafechas);


                //Diagnostico Incapacidad**********************************************************
                #region
               var tabladiagnostico = new PdfPTable(new float[] { 50f }) { WidthPercentage = 100 };
                    tabladiagnostico.AddCell(new PdfPCell(new Phrase("DIAGNÓSTICO INCAPACIDAD", titulofranja)) { Border = 0, Padding = 10f, BorderColor = new BaseColor(0, 72, 132), BorderWidthBottom = 2f, VerticalAlignment = Element.ALIGN_TOP,  HorizontalAlignment =Element.ALIGN_CENTER });//BackgroundColor = new BaseColor(0, 72, 132),

                //documento.Add(Chunk.Newline);
                documento.Add(tabladiagnostico);

                var tabladiagnosticos = new PdfPTable(new float[] { 25f, 25f, 30f }) { WidthPercentage = 100 };
                tabladiagnosticos.AddCell(new PdfPCell(new Phrase("Diagnóstico Principal", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladiagnosticos.AddCell(new PdfPCell(new Paragraph("Diagnóstico relacionado 1", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                tabladiagnosticos.AddCell(new PdfPCell(new Paragraph("Diagnóstico relacionado 2", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladiagnosticos.AddCell(new PdfPCell(new Paragraph(incapacidad.Diagnostico.cod_diagnostico, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                
                if (incapacidad.DiagnosticoRelacionUno == null)
                {
                    tabladiagnosticos.AddCell(new PdfPCell(new Paragraph("", parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                }
                else
                {
                    tabladiagnosticos.AddCell(new PdfPCell(new Paragraph(incapacidad.DiagnosticoRelacionUno.cod_diag_relacion_uno, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                }

                if (incapacidad.DiagnosticoRelacionDos == null)
                {
                    tabladiagnosticos.AddCell(new PdfPCell(new Paragraph("", parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                }
                else
                {
                    tabladiagnosticos.AddCell(new PdfPCell(new Paragraph(incapacidad.DiagnosticoRelacionDos.cod_diag_relacion_dos, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                }

                documento.Add(tabladiagnosticos);


                #endregion

                //Descripción Incapacidad*********************************************************************++++
                #region


                var tabladescripcionincapacidad = new PdfPTable(new float[] { 25f, 25f, 30f }) { WidthPercentage = 100 };
                tabladescripcionincapacidad.AddCell(new PdfPCell(new Phrase("Origen", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                tabladescripcionincapacidad.AddCell(new PdfPCell(new Paragraph("Prórroga", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                tabladescripcionincapacidad.AddCell(new PdfPCell(new Phrase("Causa motivo atención", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladescripcionincapacidad.AddCell(new PdfPCell(new Paragraph(incapacidad.Origen.descripcion, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                if (incapacidad.prorroga == false)
                {
                    tabladescripcionincapacidad.AddCell(new PdfPCell(new Paragraph("No", parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                }
                else
                {
                    
                    //tabladescripcionincapacidad.AddCell(new PdfPCell(new Paragraph("Si", parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                    tabladescripcionincapacidad.AddCell(new PdfPCell(new Paragraph(incapacidad.dias_acumulados_prorroga + " días", parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                }

                tabladescripcionincapacidad.AddCell(new PdfPCell(new Phrase(incapacidad.CausaAtencion.descripcion, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                documento.Add(tabladescripcionincapacidad);



                var tabladmotivos = new PdfPTable(new float[] { 25f, 25f, 30f }) { WidthPercentage = 100 };
                tabladmotivos.AddCell(new PdfPCell(new Paragraph("Retroactiva", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladmotivos.AddCell(new PdfPCell(new Paragraph(" ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladmotivos.AddCell(new PdfPCell(new Paragraph(" ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                
                var tabladmotivos2 = new PdfPTable(new float[] { 25f, 25f, 30f }) { WidthPercentage = 100 };
                tabladmotivos2.AddCell(new PdfPCell(new Paragraph(incapacidad.retroactiva == true ? "Si" : "No", parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladmotivos2.AddCell(new PdfPCell(new Paragraph(" ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladmotivos2.AddCell(new PdfPCell(new Paragraph(" ", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                //documento.Add(Chunk.Newline);
                documento.Add(tabladmotivos);
                documento.Add(tabladmotivos2);


                #endregion




                //Tabla de 3 columnas ejemplo*************************************************************



                //var tablaprueba = new PdfPTable(new float[] { 30f, 30f, 30f }) { WidthPercentage = 100 };
                //tablaprueba.AddCell(new PdfPCell(new Phrase("Texto1", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tablaprueba.AddCell(new PdfPCell(new Paragraph("Texto2", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                //tablaprueba.AddCell(new PdfPCell(new Paragraph("Texto3", parrafo2)) { VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tablaprueba.AddCell(new PdfPCell(new Paragraph("Texto4", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });

                //tablaprueba.AddCell(new PdfPCell(new Paragraph("Texto5", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                //tablaprueba.AddCell(new PdfPCell(new Paragraph("Texto6", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                ////documento.Add(Chunk.Newline);
                //documento.Add(tablaprueba);

                #endregion



                //Celda vacia
                var tablavacia3 = new PdfPTable(new float[] { 30f }) { WidthPercentage = 100 };
                tablavacia3.AddCell(new PdfPCell(new Phrase("      ", Titulo)) { Border = 0, VerticalAlignment = Element.ALIGN_CENTER });
                documento.Add(tablavacia3);


                //Información del profesional
                #region
                var tablaprofesional = new PdfPTable(new float[] { 50f }) { WidthPercentage = 100 };
                    tablaprofesional.AddCell(new PdfPCell(new Phrase("DATOS DEL PROFESIONAL", titulofranja)) { Border = 0, Padding = 10f, BorderColor = new BaseColor(0, 72, 132), BorderWidthBottom = 2f, VerticalAlignment = Element.ALIGN_TOP,  HorizontalAlignment = Element.ALIGN_CENTER });//BackgroundColor = new BaseColor(0, 72, 132),

                //documento.Add(Chunk.Newline);
                documento.Add(tablaprofesional);


                var tabladatosprofesionalnombres = new PdfPTable(new float[] { 30f, 30f }) { WidthPercentage = 100 };
                tabladatosprofesionalnombres.AddCell(new PdfPCell(new Phrase("Nombre entidad", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladatosprofesionalnombres.AddCell(new PdfPCell(new Paragraph("Nombre médico", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                tabladatosprofesionalnombres.AddCell(new PdfPCell(new Paragraph(incapacidad.medico_entidad, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladatosprofesionalnombres.AddCell(new PdfPCell(new Paragraph(incapacidad.medico_nombre, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                //documento.Add(Chunk.Newline);
                documento.Add(tabladatosprofesionalnombres);


                var tabladatosprofesionaldatos = new PdfPTable(new float[] { 30f, 30f }) { WidthPercentage = 100 };
                tabladatosprofesionaldatos.AddCell(new PdfPCell(new Phrase("Registro médico", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladatosprofesionaldatos.AddCell(new PdfPCell(new Paragraph("Especialidad", parrafo2)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                tabladatosprofesionaldatos.AddCell(new PdfPCell(new Paragraph(incapacidad.medico_identificacion, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });
                tabladatosprofesionaldatos.AddCell(new PdfPCell(new Paragraph(incapacidad.medico_profesion, parrafo3)) { Border = 0, VerticalAlignment = Element.ALIGN_LEFT, HorizontalAlignment = Element.ALIGN_LEFT });


                //documento.Add(Chunk.Newline);
                documento.Add(tabladatosprofesionaldatos);


                #endregion




                //para agregar texto plano
                ////documento.Add(new Phrase("PDF Incapacidad", titulo));


                //Para agregar otro parrafo para obtener un salto de línea
                ////documento.Add(new Paragraph("Hola mundo", parrafo1) {Alignment = Element.ALIGN_CENTER });



                ////var parrafo = new Paragraph("Prueba");
                //////documento.Add(new Chunk(""));
                ////parrafo.Alignment = Element.ALIGN_CENTER;
                ////documento.Add(parrafo);
                //////salto de línea por la clase Chunk es una representación mínima de texto        






            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            finally
            {
                //Dejar de escribir en el documento y cerrarlo
                documento.Close();
                escritura.Close();

            }
            //archivo.Dispose();
            //var pdf = new FileStream("Ejemplo.pdf", FileMode.Open, FileAccess.Read);
            archivo.Seek(0, SeekOrigin.Begin);
            //archivo.Dispose();
            return archivo;




            //return new MemoryStream();
        }

        public void OnEndPage(PdfWriter writer, Document document)
        {
            throw new NotImplementedException();
        }
    }
}
