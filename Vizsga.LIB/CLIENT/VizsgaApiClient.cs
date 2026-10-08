using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsga.LIB.CLIENT
{
    public class VizsgaApiClient
    {
        public HttpClient Client { get;}

        public VizsgaApiClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:7229/");
        }
    }
}
