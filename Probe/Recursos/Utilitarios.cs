using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Probe.Recursos
{
    public class Utilitarios
    {
        /// <summary>
        /// Valida emails.
        /// </summary>
        /// <param name="email">string email.</param>
        /// <returns>Valor booleano.</returns>
        public bool IsValidEmail(string email)
        {
            try
            {
                EmailAddressAttribute foo = new EmailAddressAttribute();
                bool bar;
                bar = foo.IsValid(email);
                return bar;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
