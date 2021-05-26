using Newtonsoft.Json;
using Probe.Negocio.Modulos;
using Probe.Recursos.Custom;
using System;

namespace Probe.Modelo
{
    public class Empresa
    {
        public int IdEmpresaLocal { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int IdEmpresa { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public int IdVendedor { get; set; }

        [JsonProperty(PropertyName = "rif")]
        public string RIF { get; set; }

        [JsonProperty(PropertyName = "social_reason")]
        public string RazonSocial { get; set; }

        [JsonProperty(PropertyName = "commercial_name")]
        public string NombreComercial { get; set; }

        [JsonProperty(PropertyName = "email_1")]
        public string Email1 { get; set; }

        [JsonProperty(PropertyName = "email_2")]
        public string Email2 { get; set; }

        [JsonProperty(PropertyName = "phone_1")]
        public string Telefono1 { get; set; }

        [JsonProperty(PropertyName = "phone_2")]
        public string Telefono2 { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string SitioWeb { get; set; }

        [JsonProperty(PropertyName = "instagram")]
        public string Instagram { get; set; }

        [JsonProperty(PropertyName = "facebook")]
        public string Facebook { get; set; }

        [JsonProperty(PropertyName = "whatsapp")]
        public string WhatsappBusiness { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Direccion { get; set; }

        [JsonProperty(PropertyName = "parish")]
        public string Parroquia { get; set; }

        [JsonProperty(PropertyName = "municipality")]
        public string Municipio { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string Ciudad { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string CodigoPostal { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string Estado { get; set; }

        //public decimal Latitud { get; set; }

        //public decimal Longitud { get; set; }

        public position position { get; set; }

        public int IdEstadoCliente { get; set; }

        public string NombreEstadoCliente { get; set; }

        //public Estado EstadoObjeto { get; set; }

        public Contacts contacts { get; set; }

        //[JsonProperty(PropertyName = "contact_1")]
        //public Contacto1 Contacto1 { get; set; }

        //[JsonProperty(PropertyName = "contact_2")]
        //public Contacto2 Contacto2 { get; set; }

        [JsonProperty(PropertyName = "commercial_sector")]
        public string SectorComercial { get; set; }

        public int IdSectorComercial { get; set; }

        [JsonProperty(PropertyName = "consumption")]
        public Consumo Consumo { get; set; }

        [JsonProperty(PropertyName = "observations")]
        public string Observaciones { get; set; }

        [JsonProperty(PropertyName = "first_visit")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        public DateTime FechaPrimeraVisita { get; set; }

        [JsonProperty(PropertyName = "first_buy")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        public DateTime FechaPrimeraCompra { get; set; }

        [JsonProperty(PropertyName = "next_action")]
        public string SiguienteAccion { get; set; }

        [JsonProperty(PropertyName = "next_action_date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        public DateTime FechaSiguienteAccion { get; set; }

        [JsonProperty(PropertyName = "salesman")]
        public string VendedorEncargado { get; set; }

        //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        //public DateTime created_at { get; set; }

        //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        //public DateTime updated_at { get; set; }
    }
}
