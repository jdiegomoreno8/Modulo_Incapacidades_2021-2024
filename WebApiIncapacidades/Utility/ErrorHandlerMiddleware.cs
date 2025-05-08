using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiIncapacidades.Utility;

namespace WebApiIncapacidades.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                object resultObject;

                Console.WriteLine(error.Message);
                Console.WriteLine(error.InnerException);

                switch (error)

                    
                {
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.OK; //(int)HttpStatusCode.BadRequest;
                        string dataResult = string.Empty;
                        if(e.dataLog != null)
                        {
                            foreach (string data1 in e.dataLog)
                            {
                                dataResult = dataResult + " " + data1.ToString();
                            }
                        }
                        
                        resultObject = new { codigo = "501", mensaje = e.Message, detalle = e.InnerException != null ? e.InnerException.ToString().Replace("{", "(").Replace("}", ")") : string.Empty};

                        var resultObjectLog = new { codigo = "501", mensaje = e.Message, detalle = e.InnerException != null ? e.InnerException.ToString().Replace("{", "(").Replace("}", ")") : string.Empty, data = dataResult };
                        LogFile.Write(resultObjectLog.ToString());

                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.OK;
                        resultObject = new { codigo = "404", mensaje = e.Message, detalle = e.InnerException };
                        LogFile.Write(resultObject.ToString());
                        break;
                    case Exception e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.OK;
                        resultObject = new { codigo = "505", mensaje = e.Message, detalle = e.InnerException != null ? e.InnerException.ToString().Replace("{", "(").Replace("}", ")") : string.Empty };
                        LogFile.Write(resultObject.ToString());
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.OK;
                        resultObject = new { codigo = "500", mensaje = error.Message, detalle = error.InnerException != null ? error.InnerException.ToString().Replace("{", "(").Replace("}", ")") : string.Empty };
                        LogFile.Write(resultObject.ToString());
                        break;
                }

                var result = JsonSerializer.Serialize(resultObject);
                //var result = error.Message+"-------------"+ error.InnerException;
                await response.WriteAsync(result);
            }
        }
    }
}