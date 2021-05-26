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
using Xamarin.Forms;

namespace Probe.Negocio.Modulos
{
    public class VendedorB : EntidadB
    {
        public async Task<Respuesta> GuardarAPI(Vendedor objVendedor)
        {
            Respuesta objRespuesta = new Respuesta();

            await Task.Delay(0);

            try
            {
                // Creamos el JSON.
                var json = JsonConvert.SerializeObject(objVendedor);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();

                //client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.PostAsync(UrlBase + "/api/survey/user", new StringContent(json, Encoding.UTF8, "application/json")).ConfigureAwait(false);
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
                            else if (objRespuestaApi.msg == "¡Wrong data!")
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
                            objRespuesta.RespuestaNoExitosa(1, "Ha ocurrido un error al crear usuario.");
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

        public async Task<Respuesta> AutenticarAPI(string usuario, string contrasenna)
        {
            Respuesta objRespuesta = new Respuesta();

            try
            {
                // Instancias.
                Login objLogin = new Login();
                HttpClient client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();

                // Asignamos valores.
                objLogin.Usuario = usuario;
                objLogin.Contrasenna = contrasenna;

                // Creamos el JSON.
                string json = JsonConvert.SerializeObject(objLogin);

                //client.Timeout = TimeSpan.FromSeconds(900);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.PostAsync(UrlBase + "/api/survey/login", new StringContent(json, Encoding.UTF8, "application/json"))
                    .ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    string str = string.Empty;
                    var jsonObtenido = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    RespuestaAPI objRespuestaApi = JsonConvert.DeserializeObject<RespuestaAPI>(jsonObtenido);
                    if (!string.IsNullOrEmpty(objRespuestaApi.msg))
                    {
                        if (objRespuestaApi.msg == "¡Wrong data!")
                        {
                            str = objRespuestaApi.flash.title;
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
                        else if (objRespuestaApi.msg == "¡Unauthorized!")
                        {
                            objRespuesta.RespuestaNoExitosa(1, "Usuario o clave invalido.");
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
                            if (objRespuestaApi.msg == "¡Success!")
                            {
                                objRespuesta.RespuestaExitosa(0, "OK");

                                // Instanciamos.
                                EngineData engineData = EngineData.Instance();

                                // Asignamos el objeto a la propiedad para poder acceder a ella.
                                engineData.IdVendedor = objRespuestaApi.id;
                                engineData.Token = objRespuestaApi.token;
                                engineData.User = objRespuestaApi.username;
                            }
                        }
                        else
                        {
                            objRespuesta.RespuestaNoExitosa(1, "Ha ocurrido un error en al autenticar usuario.");
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
    }
}
