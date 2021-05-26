using System;
using System.Collections.Generic;
using System.Text;

namespace Probe.Modelo.Modulos.Sistema
{
    public class EngineData
    {
        private static EngineData valor;
        public static EngineData Instance()
        {
            if ((valor == null))
            {
                valor = new EngineData();
            }
            return valor;
        }

        /// <summary>
        /// Propiedad para almacenar un objeto de ContextoAPP y poder acceder desde cualqueir punto a la data almacenada ahí.
        /// </summary>
        //public ContextoAPP ObjContextoAPP { get; set; }

        /// <summary>
        /// Propiedad para crear una instancia unica y almacenar un objeto de Despacho y poder acceder desde cualqueir punto a la data almacenada ahí.
        /// </summary>
        public int IdVendedor { get; set; }
        public string Token { get; set; }
        public string User { get; set; }
        
    }
}
