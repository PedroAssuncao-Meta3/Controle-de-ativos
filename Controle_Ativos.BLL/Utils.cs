using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL
{
    public static class Utils
    {
        private readonly static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
        {
            DateFormatString = "dd-MM-yyyy HH:mm:ss",
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static string JSonIndentar(string json)
        {
            return JsonConvert.SerializeObject(json, Formatting.Indented);
        }

        public static string ObjToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, jsonSerializerSettings);
        }

        public static object JSonToObj<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
        }

    }
}
