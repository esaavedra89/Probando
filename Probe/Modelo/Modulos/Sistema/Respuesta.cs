using System;
using System.Collections.Generic;
using System.Text;

namespace Probe.Modelo.Modulos.Sistema
{
    public class Respuesta
    {
        /// <summary>
        /// Indica si fue exitosa o no la petición.
        /// </summary>
        public bool Valido
        {
            get;
            set;
        }

        /// <summary>
        /// Código obtenido de la respuesta.
        /// </summary>
        public int Codigo
        {
            get;
            set;
        }

        /// <summary>
        /// Mensaje a mostrar.
        /// </summary>
        public string Mensaje
        {
            get;
            set;
        }

        /// <summary>
        /// Resultado de la respuesa en un string.
        /// </summary>
        public object Resultado
        {
            get;
            set;
        }

        /// <summary>
        /// ResultadoDos de la respuesa en un objeto.
        /// </summary>
        public object ResultadoDos
        {
            get;
            set;
        }

        /// <summary>
        /// Método que establece la conexión como existosa y estable el mensaje respectivo.
        /// </summary>
        /// <param name="codigo">Código de la respuesta.</param>
        /// <param name="mensaje">Mensaje de la respuesta.</param>
        public void RespuestaExitosa(int codigo, string mensaje)
        {
            this.Valido = true;
            this.Codigo = codigo;
            this.Mensaje = mensaje;
        }

        /// <summary>
        /// Método que establece la conexión como existosa, establece el mensaje respectivo y el objeto obtenido.
        /// </summary>
        /// <param name="codigo">Código de la respuesta.</param>
        /// <param name="mensaje">Mensaje de la respuesta.</param>
        /// <param name="resultado">Objeto obtenido de la respuesta.</param>
        public void RespuestaExitosa(int codigo, string mensaje, object resultado)
        {
            this.Valido = true;
            this.Codigo = codigo;
            this.Mensaje = mensaje;
            this.Resultado = resultado;
        }

        /// <summary>
        /// Método que establece la conexión como existosa, establece el mensaje respectivo y el objeto obtenido.
        /// </summary>
        /// <param name="codigo">Código de la respuesta.</param>
        /// <param name="mensaje">Mensaje de la respuesta.</param>
        /// <param name="resultado">Objeto obtenido de la respuesta.</param>
        /// <param name="resultadoDos">Segundo objeto obtenido de la respuesta.</param>
        public void RespuestaExitosa(int codigo, string mensaje, object resultado, object resultadoDos)
        {
            this.Valido = true;
            this.Codigo = codigo;
            this.Mensaje = mensaje;
            this.Resultado = resultado;
            this.ResultadoDos = resultadoDos;
        }

        /// <summary>
        /// Método que establece la conexión como no existosa y estable el mensaje respectivo.
        /// </summary>
        /// <param name="codigo">Código de la respuesta.</param>
        /// <param name="mensaje">Mensaje de la respuesta.</param>
        public void RespuestaNoExitosa(int codigo, string mensaje)
        {
            this.Valido = false;
            this.Codigo = codigo;
            this.Mensaje = mensaje;
        }
    }
}
