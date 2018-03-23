using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace test5
{
    //Only using "GET" but would have all 4 actions if building out an API
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {
        //Going to hold the URI
        public string EndPoint { get; set; }
        //HttpVerb Enum property
        public HttpVerb HttpMethod { get; set; }

        //Constructor to initiate and instantiate properties
        public RestClient()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpVerb.GET;
        }

        public string MakeRequest()
        {
            string strResponseValue = string.Empty;

            //Making request to the endpoint via a request object
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);

            //Setting request Method to get
            request.Method = HttpMethod.ToString();

            //GetResponse method to handle the response
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

                //Error handling
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error code: " + response.StatusCode.ToString());
                }

                //Process the response stream (the JSON, XML, HTML, etc.,)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        //Streamreader reads the response
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }//End of using StreamReader

                    }//End of responseStream != null if statement

                }//End of using ResponseStream

            }//End of using WebResponse

            return strResponseValue;
        }
    }
}
