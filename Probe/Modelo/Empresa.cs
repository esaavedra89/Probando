using Newtonsoft.Json;
using Probe.Negocio.Modulos;
using Probe.Recursos.Custom;
using System;

namespace Probe.Modelo
{
    public class Empresa
    {
        public int IdEmpresaLocal { get; set; }

        public int IdEmpresa { get; set; }

        public int IdVendedor { get; set; }

        public string RIF { get; set; }

        public string RazonSocial { get; set; }

        public string NombreComercial { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Telefono1 { get; set; }

        public string Telefono2 { get; set; }

        public string SitioWeb { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }

        public string WhatsappBusiness { get; set; }

        public string Direccion { get; set; }

        public string Parroquia { get; set; }

        public string Municipio { get; set; }

        public string Ciudad { get; set; }

        public string CodigoPostal { get; set; }

        public string Estado { get; set; }

        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public int IdEstadoCliente { get; set; }
        public string NombreEstadoCliente { get; set; }
        public Contacto1 Contacto1 { get; set; }
        public Contacto2 Contacto2 { get; set; }
        public string SectorComercial { get; set; }
        public int IdSectorComercial { get; set; }
        public Consumo Consumo { get; set; }
        public string Observaciones { get; set; }
        
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        public DateTime FechaPrimeraVisita { get; set; }
        
        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        public DateTime FechaPrimeraCompra { get; set; }

        public string SiguienteAccion { get; set; }

        [JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        public DateTime FechaSiguienteAccion { get; set; }

        public string VendedorEncargado { get; set; }

        //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        //public DateTime created_at { get; set; }

        //[JsonConverter(typeof(DateFormatConverter), "yyyy-MM-dd hh:mm:ss")]
        //public DateTime updated_at { get; set; }
    }
}
