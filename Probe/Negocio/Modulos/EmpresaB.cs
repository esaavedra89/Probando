using Newtonsoft.Json;
using Probe.Modelo;
using Probe.Modelo.Modulos.Sistema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Probe.Negocio.Modulos
{
    public class EmpresaB : EntidadB
    {
        public async Task<Respuesta> GuardarAPI(Empresa objEmpresa)
        {
            Respuesta objRespuesta = new Respuesta();

            try
            {
                // Creamos el JSON.
                var json = JsonConvert.SerializeObject(objEmpresa);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();

                //client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.PostAsync(UrlBase + "/api/survey/data", new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    var jsonObtenido = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    RespuestaAPI objRespuestaApi = JsonConvert.DeserializeObject<RespuestaAPI>(jsonObtenido);
                    if (!string.IsNullOrEmpty(objRespuestaApi.msg))
                    {
                        if (objRespuestaApi.msg == "¡Wrong data!")
                        {
                            string str = objRespuestaApi.flash.title;
                            if (objRespuestaApi.flash.message != null && objRespuestaApi.flash.message.Count > 0)
                            {
                                for (int i = 0; i < objRespuestaApi.flash.message.Count; i++)
                                {
                                    if (i > 0 && i != objRespuestaApi.flash.message.Count - 1)
                                    {
                                        str += ", ";
                                    }

                                    str += objRespuestaApi.flash.message[i];
                                }
                            }

                            objRespuesta.RespuestaNoExitosa(1, str);
                        }
                    }
                    else
                    {
                        // Error.
                        objRespuesta.RespuestaNoExitosa(0, "Ha ocurrido un error de red: Error " +
                                Convert.ToInt32(response.StatusCode) + " " + response.ReasonPhrase.ToString());
                    }
                }
                else
                {
                    string jsonObtenido = string.Empty;
                    if (!string.IsNullOrEmpty(await response.Content.ReadAsStringAsync().ConfigureAwait(false)))
                    {
                        jsonObtenido = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    }

                    if (!string.IsNullOrEmpty(jsonObtenido))
                    {
                        RespuestaAPI objRespuestaApi = JsonConvert.DeserializeObject<RespuestaAPI>(jsonObtenido);
                        if (!string.IsNullOrEmpty(objRespuestaApi.msg))
                        {
                            if (objRespuestaApi.msg == "¡Saved!")
                            {
                                objRespuesta.RespuestaExitosa(0, "OK");
                            }
                        }
                        else
                        {
                            objRespuesta.RespuestaNoExitosa(1, "Ha ocurrido un error en la petición.");
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return objRespuesta;
        }

        public async Task<Respuesta> GET_API_Cliente(string direccion)
        {
            string resultado = string.Empty;
            // instancias.
            var httpClient = new HttpClient();
            Respuesta objRespuesta = new Respuesta();

            try
            {
                // Headers.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
                // petición.
                //HttpResponseMessage response = await httpClient.GetAsync(NEOBUSINESS_API_URL + direccion);
                HttpResponseMessage response = await httpClient.GetAsync(direccion).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    objRespuesta.RespuestaNoExitosa(0, "Ha ocurrido un error de red: Error " +
                            Convert.ToInt32(response.StatusCode) + " " + response.ReasonPhrase.ToString());
                }
                else
                {
                    //string result = string.Empty;
                    Stream resStream = null;

                    //result = response.Content.ReadAsStringAsync().Result;
                    //result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    //string resStreams = response.Content.ReadAsStringAsync().Result;
                    resStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                    //RespuestaAPI objRespuestaApi = JsonConvert.DeserializeObject<RespuestaAPI>(resStreams);

                    objRespuesta.RespuestaExitosa(0, "OK", resStream);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

            // retornamos la respuesta.
            return objRespuesta;
        }

    }
}
