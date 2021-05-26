using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Probe.Modelo.Modulos.Sistema
{
    public class Flash
    {
        public string title { get; set; }
        public List<string> message { get; set; }
    }

    public class RespuestaAPI
    {
        public string msg { get; set; }
        public Flash flash { get; set; }
        public string token { get; set; }
        public string username { get; set; }
        public int id { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public List<Empresa> surveys { get; set; }
    }
}
