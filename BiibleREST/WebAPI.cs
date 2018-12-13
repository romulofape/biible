using System.IO;
using System.Net;
using System.Text;

namespace Biible.Rest
{
    public class WebAPI
    {
        public static string URI = @"http://localhost:62962/api/cliente/";
        public static string TOKEN = "AHBSHD7787AKJHS87987JHGSdsh82937";

        public static string RequestGET(string metodo, string parametro)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI + metodo + "/" + parametro);
            request.Headers.Add("Token", TOKEN);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public static string RequestDELETE(string metodo, string parametro)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI + metodo + "/" + parametro);
            request.Headers.Add("Token", TOKEN);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public static string RequestPOST(string metodo, string jsonData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            byte[] data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "POST";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        public static string RequestPUT(string metodo, string jsonData)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI + metodo);
            byte[] data = Encoding.ASCII.GetBytes(jsonData);
            request.Method = "PUT";
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
