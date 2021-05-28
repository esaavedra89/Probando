using Newtonsoft.Json;
using Probe.Modelo;
using Probe.Modelo.Modulos;
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
                    List<Empresa> objEmpresa = new List<Empresa>();
                    Stream resStream = null;
                    resStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                    // Leemos la respuesta stream.
                    using (StreamReader sr1 = new StreamReader(resStream))
                    using (JsonReader reader1 = new JsonTextReader(sr1))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var generalRutas = serializer.Deserialize<RespuestaAPI>(reader1);
                        if (generalRutas != null)
                        {
                            if (generalRutas.data.surveys != null)
                            {
                                objEmpresa = await EmparejarObjetoSurvey(generalRutas.data.surveys);
                            }
                        }
                    }

                    objRespuesta.RespuestaExitosa(0, "OK", objEmpresa);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

            // retornamos la respuesta.
            return objRespuesta;
        }

        async Task<List<Empresa>> EmparejarObjetoSurvey(List<Survey> objRecSurvey) 
        {
            List<Empresa> objSurvey = new List<Empresa>();

            try
            {
                for (int i = 0; i < objRecSurvey.Count; i++)
                {
                    Survey item = objRecSurvey[i];

                    Empresa objEmpresa = new Empresa();

                    objEmpresa.IdEmpresa = item.IdEmpresa;
                    objEmpresa.IdVendedor = item.IdVendedor;
                    objEmpresa.RIF = item.RIF;
                    objEmpresa.RazonSocial = item.RazonSocial;
                    objEmpresa.NombreComercial = item.NombreComercial;
                    objEmpresa.Email1 = item.Email1;
                    objEmpresa.Email2 = item.Email2;
                    objEmpresa.Telefono1 = item.Telefono1;
                    objEmpresa.Telefono2 = item.Telefono2;
                    objEmpresa.SitioWeb = item.SitioWeb;
                    objEmpresa.Instagram = item.Instagram;
                    objEmpresa.Facebook = item.Facebook;
                    objEmpresa.WhatsappBusiness = item.WhatsappBusiness;
                    objEmpresa.Direccion = item.Direccion;
                    objEmpresa.Parroquia = item.Parroquia;
                    objEmpresa.Municipio = item.Municipio;
                    objEmpresa.Ciudad = item.Ciudad;
                    objEmpresa.CodigoPostal = item.CodigoPostal;
                    objEmpresa.Estado = item.Estado;
                    objEmpresa.Latitud = item.position.lat;
                    objEmpresa.Longitud = item.position.lng;

                    objEmpresa.IdEstadoCliente = (string.IsNullOrEmpty(item.IdEstadoCliente) ? 0 : Convert.ToInt32(item.IdEstadoCliente));
                    objEmpresa.NombreEstadoCliente = item.NombreEstadoCliente;

                    // Contacto #1.
                    objEmpresa.Contacto1 = new Contacto1();
                    objEmpresa.Contacto1.NombreContacto1 = item.contacts.contact_1.NombreContacto1;
                    objEmpresa.Contacto1.ApellidoContacto1 = item.contacts.contact_1.ApellidoContacto1;
                    objEmpresa.Contacto1.Email11 = item.contacts.contact_1.Email11;
                    objEmpresa.Contacto1.Email12 = item.contacts.contact_1.Email12;
                    objEmpresa.Contacto1.Telefono11 = item.contacts.contact_1.Telefono11;
                    objEmpresa.Contacto1.Telefono12 = item.contacts.contact_1.Telefono12;
                    objEmpresa.Contacto1.Instagram1 = item.contacts.contact_1.Instagram1;
                    objEmpresa.Contacto1.Facebook1 = item.contacts.contact_1.Facebook1;
                    objEmpresa.Contacto1.Hobbies1 = item.contacts.contact_1.Hobbies1;
                    objEmpresa.Contacto1.PersonaRelacionada1 = item.contacts.contact_1.PersonaRelacionada1;

                    // Contacto #2.
                    objEmpresa.Contacto2 = new Contacto2();
                    objEmpresa.Contacto2.NombreContacto2 = item.contacts.contact_2.NombreContacto2;
                    objEmpresa.Contacto2.ApellidoContacto2 = item.contacts.contact_2.ApellidoContacto2;
                    objEmpresa.Contacto2.Email21 = item.contacts.contact_2.Email21;
                    objEmpresa.Contacto2.Email22 = item.contacts.contact_2.Email22;
                    objEmpresa.Contacto2.Telefono21 = item.contacts.contact_2.Telefono21;
                    objEmpresa.Contacto2.Telefono22 = item.contacts.contact_2.Telefono22;
                    objEmpresa.Contacto2.Instagram2 = item.contacts.contact_2.Instagram2;
                    objEmpresa.Contacto2.Facebook12 = item.contacts.contact_2.Facebook12;
                    objEmpresa.Contacto2.Hobbies2 = item.contacts.contact_2.Hobbies2;
                    objEmpresa.Contacto2.PersonaRelacionada2 = item.contacts.contact_2.PersonaRelacionada2;

                    objEmpresa.IdSectorComercial = item.IdSectorComercial;
                    objEmpresa.SectorComercial = item.SectorComercial;

                    // Consumo mensual aproximado en litros.
                    objEmpresa.Consumo = new Consumo();
                    objEmpresa.Consumo.Mineral15w40 = item.Consumo.Mineral15w40;
                    objEmpresa.Consumo.Mineral20w50 = item.Consumo.Mineral20w50;
                    objEmpresa.Consumo.SemiSintetico15w40 = item.Consumo.SemiSintetico15w40;
                    objEmpresa.Consumo.SemiSintetico20w50 = item.Consumo.SemiSintetico20w50;
                    objEmpresa.Consumo.DexronIII = item.Consumo.DexronIII;
                    objEmpresa.Consumo.Motos4t = item.Consumo.Motos4t;
                    objEmpresa.Consumo.ISO80w90 = item.Consumo.ISO80w90;
                    objEmpresa.Consumo.Diesel50 = item.Consumo.Diesel50;
                    objEmpresa.Consumo.Diesel15w40 = item.Consumo.Diesel15w40;
                    objEmpresa.Consumo.Hidraulico68 = item.Consumo.Hidraulico68;
                    objEmpresa.Consumo.LigaFrenoDot3 = item.Consumo.LigaFrenoDot3;
                    objEmpresa.Consumo.Flushing = item.Consumo.Flushing;

                    objEmpresa.Observaciones = item.Observaciones;
                    objEmpresa.FechaPrimeraVisita = item.FechaPrimeraVisita;
                    objEmpresa.FechaPrimeraCompra = item.FechaPrimeraCompra;
                    objEmpresa.SiguienteAccion = item.SiguienteAccion;
                    objEmpresa.FechaSiguienteAccion = item.FechaSiguienteAccion;
                    objEmpresa.VendedorEncargado = item.VendedorEncargado;

                    objSurvey.Add(objEmpresa);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return objSurvey;
        }
    }
}
