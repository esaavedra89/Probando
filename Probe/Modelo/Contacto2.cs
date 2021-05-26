using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Probe.Modelo
{
    public class Contacto2
    {
        [JsonProperty(PropertyName = "IdContacto2Local")]
        public int IdContacto2Local { get; set; }

        [JsonProperty(PropertyName = "IdContacto2")]
        public int IdContacto2 { get; set; }

        [JsonProperty(PropertyName = "NombreContacto2")]
        public string NombreContacto2 { get; set; }

        [JsonProperty(PropertyName = "ApellidoContacto2")]
        public string ApellidoContacto2 { get; set; }

        [JsonProperty(PropertyName = "Email21")]
        public string Email21 { get; set; }

        [JsonProperty(PropertyName = "Email22")]
        public string Email22 { get; set; }

        [JsonProperty(PropertyName = "Telefono21")]
        public string Telefono21 { get; set; }

        [JsonProperty(PropertyName = "Telefono22")]
        public string Telefono22 { get; set; }

        [JsonProperty(PropertyName = "Instagram2")]
        public string Instagram2 { get; set; }

        [JsonProperty(PropertyName = "Facebook12")]
        public string Facebook12{ get; set; }

        [JsonProperty(PropertyName = "Hobbies2")]
        public string Hobbies2 { get; set; }

        [JsonProperty(PropertyName = "PersonaRelacionada2")]
        public string PersonaRelacionada2 { get; set; }
    }
}
