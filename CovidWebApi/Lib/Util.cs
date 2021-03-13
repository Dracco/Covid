using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace CovidWebApi.Lib
{
    internal class Util
    {
        private static readonly int timeout = 10 * 1000;


        public static T GetJsonAndDeserialize<T>(string url, string contentType)
        {
            T obj = Activator.CreateInstance<T>();

            var requisicaoWeb = WebRequest.Create(url);
            requisicaoWeb.Timeout = timeout;
            requisicaoWeb.Method = "GET";
            requisicaoWeb.ContentType = contentType;

            try
            {
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<T>(objResponse.ToString());
                    streamDados.Close();
                    resposta.Close();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}