using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eManager.ConsoleWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));

            var result = client.GetAsync(new Uri("http://localhost:28971/api/videos")).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var doc = XDocument.Load(result.Content.ReadAsStreamAsync().Result);
                var ns = (XNamespace)"http://schemas.datacontract.org/2004/07/Videos.Models";

                foreach (var title in doc.Descendants(ns + "Title"))
                {
                    Console.WriteLine(title.Value);
                }
            }
            Console.ReadLine();
        }
    }
}
