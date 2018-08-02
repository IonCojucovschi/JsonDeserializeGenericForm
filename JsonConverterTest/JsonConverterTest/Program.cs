using JsonConverterTest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverterTest
{
    public class DataLoader
    {
        public List<SomeObjectTHatUwant> Response = new List<SomeObjectTHatUwant>();///the data you want

        public DataLoader(string uri)
        {
            LoadDataAsync(uri);
        }


        async Task LoadDataAsync(string uri)
        {

            string responseJsonString = null;
            using (var httpClient = new WebClient())
            {
                try
                {
                    //Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                    // HttpResponseMessage response = await getResponse;
                    responseJsonString = httpClient.DownloadString(uri);
                     //responseJsonString = await response.Content.ReadAsStringAsync();
                    Response = JsonBase<SomeObjectTHatUwant>.ReturnResultsList(responseJsonString);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    }




    class Program
    {
        static string url = "http://readabook.16mb.com/api/allcategory";///this link return an json
        static List<SomeObjectTHatUwant> Response = new List<SomeObjectTHatUwant>();///the data you want
        static void Main(string[] args)
        {
            DataLoader dt = new DataLoader(url);
            Response = dt.Response;
        }


         

    }
}
