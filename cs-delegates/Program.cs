using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cs_delegates
{
    class Program
    {
        delegate void EventHandler(HttpPretendMessageRequest httpPretendMessageRequest);

        static void Main(string[] args)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                FakeClientSend(new HttpPretendMessageRequest( ) );
                FakeServerListen();
            }
        }

        private static void FakeClientSend(HttpPretendMessageRequest httpPretendMessageRequest)
        {
            
        }

        private static void FakeServerListen()
        {
            //
        }

        //private static void FakeServerRespond() { }


        class HttpPretendMessageRequest
        {
            public string Uri { get; set; }
            public string HttpMethod { get; set; }
            public string Content { get; set; }
        }

        class HttpPretendMessageResponse
        {
            public string StatusCode { get; set; }
            public string Content { get; set; }
        }
    }
}
