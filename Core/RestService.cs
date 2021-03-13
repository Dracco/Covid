using System;
using System.IO;
using System.Net;

namespace Core
{
    public class RestService
    {
        //implementar chamada (GET) para url. 
        //public T Get<T>(string url)

        public T Get<T>(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    return (T)Convert.ChangeType(streamReader.ReadToEnd(), typeof(T));
                }
            }

            catch (Exception e)
            {
                throw e;
            }
        }
        public String Get(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                string text = string.Empty;
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        text = reader.ReadToEnd();
                    }
                }
                return text;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
