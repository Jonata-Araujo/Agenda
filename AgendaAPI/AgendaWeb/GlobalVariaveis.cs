using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace AgendaWeb
{
    public class GlobalVariaveis
    {
        public static HttpClient WebAPI = new HttpClient();

        static GlobalVariaveis()
        {
            WebAPI.BaseAddress = new Uri("http://localhost:31344/api/");
            WebAPI.DefaultRequestHeaders.Clear();
            WebAPI.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static object WebApiClient { get; internal set; }
    }
}