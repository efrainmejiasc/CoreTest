using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTestLogical
{
    public interface IEngineLogical
    { 
        string TypeCompany(float value);
        bool EmailEsValido(string email);
        string TypeSubsidiary(float value);
        string ConvertirBase64(string cadena);
        bool CompareString(string a, string b);
        string DecodeBase64(string base64EncodedData);
    }
}
