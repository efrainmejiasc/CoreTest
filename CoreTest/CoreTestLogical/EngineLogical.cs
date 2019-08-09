using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CoreTestLogical
{
    public class EngineLogical: IEngineLogical
    {
        public string ConvertirBase64(string cadena)
        {
            var comprobanteXmlPlainTextBytes = Encoding.UTF8.GetBytes(cadena);
            var cadenaBase64 = Convert.ToBase64String(comprobanteXmlPlainTextBytes);
            return cadenaBase64;
        }

        public string DecodeBase64(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public bool EmailEsValido(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            bool resultado = false;
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        public bool CompareString(string a, string b)
        {
            bool resultado = false;
            if (a == b)
            {
                resultado = true;
            }
            return resultado;
        }

        public string TypeCompany (float value)
        {
            string [] tipo = { "BIG", "MEDIUM", "SMALL" , "LOST"};
            if (value >= 0 && value <= 10000)
                return tipo[2];
            if (value > 10000 && value <= 900000)
                return tipo[1];
            else if (value > 900000)
                return tipo[0];
            else
                return tipo[3];
        }

        public string TypeSubsidiary(float value)
        {
            string[] tipo = { "MAIN", "AUXILIARY",  "LOST" };
            if (value >= 0 && value <= 15000)
                return tipo[1];
            if (value > 15000)
                return tipo[0];
            else
                return tipo[2];
        }


    }
}
