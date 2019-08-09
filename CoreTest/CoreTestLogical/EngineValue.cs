using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTestLogical
{
    public class EngineValue
    {
        private static EngineValue valor;
        public static EngineValue Instance()
        {
            if ((valor == null))
            {
                valor = new EngineValue();
            }
            return valor;
        }

        public static string modeloImcompleto = "modelo incompleto";
        public static string emailNoValido = "email no valido";
        public static string passwordDiferente = "los passwords son diferentes";
        public static string falloCrearUsuario = "error al crear usuario";
        public static string transaccionExitosa = "transaccion exitosa";
        public static string noExisteUsuario = "no existe usuario";
        public static string Login = "User/Login";
        public static string Client = "DataCompany/GetClient?nameCompany=";
        public static string NoData = "No Existen Registros";
    }
}
