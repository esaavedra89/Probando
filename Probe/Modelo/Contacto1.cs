using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Probe.Modelo
{
    public class Contacto1
    {
        public int IdContacto1Local { get; set; }

        [JsonProperty(PropertyName = "IdContacto1")]
        public int IdContacto1 { get; set; }

        [JsonProperty(PropertyName = "NombreContacto1")]
        public string NombreContacto1 { get; set; }

        [JsonProperty(PropertyName = "ApellidoContacto1")]
        public string ApellidoContacto1 { get; set; }

        [JsonProperty(PropertyName = "Email11")]
        public string Email11 { get; set; }

        [JsonProperty(PropertyName = "Email12")]
        public string Email12 { get; set; }

        [JsonProperty(PropertyName = "Telefono11")]
        public string Telefono11 { get; set; }

        [JsonProperty(PropertyName = "Telefono12")]
        public string Telefono12 { get; set; }

        [JsonProperty(PropertyName = "Instagram1")]
        public string Instagram1 { get; set; }

        [JsonProperty(PropertyName = "Facebook1")]
        public string Facebook1 { get; set; }

        [JsonProperty(PropertyName = "Hobbies1")]
        public string Hobbies1 { get; set; }

        [JsonProperty(PropertyName = "PersonaRelacionada1")]
        public string PersonaRelacionada1 { get; set; }
    }
}
