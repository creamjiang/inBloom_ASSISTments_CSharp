using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.IO;
using inBloom_2.Utilities;

namespace inBloom_2.inBloomApiHelper
{
    public class ApiClient
    {
        public static ApiResponse Request(string apiEndPoint, string accessToken)
        {
            ApiResponse apiResponse = new ApiResponse();
            ExtendedWebClient restClient = new ExtendedWebClient();
            string inBloomResponse = string.Empty;
            string bearerToken = string.Format("bearer {0}", accessToken);

            restClient.Headers.Add("Content-Type: application/vnd.slc+json");
            restClient.Headers.Add("Accept: application/vnd.slc+json");

            restClient.Headers.Add("Authorization", bearerToken);
            try
            {       
                inBloomResponse = restClient.DownloadString(apiEndPoint);
                //let result to be an array JArray Json
                if (inBloomResponse.Substring(0, 1) == "{")
                {
                    inBloomResponse = String.Format("[{0}]", inBloomResponse);
                }

                if (inBloomResponse != string.Empty)
                {
                    JArray jsonResponse = JArray.Parse(inBloomResponse);
                    apiResponse.ResponseObject = jsonResponse;
                }
            }
            catch (Exception ex)
            {
                apiResponse.ErrorMessage = ex.Message;
                throw ex;
            }

            apiResponse.StatusCode = restClient.StatusCode;

            return apiResponse;
        }

        public static WebResponse doPOST(string apiEndPoint, string accessToken, string bodyJSONData)
        {
            var myRequest = (HttpWebRequest)WebRequest.Create(apiEndPoint);
            myRequest.Accept = Global.inBloomAcceptHeader;
            myRequest.ContentType = Global.inBloomContentTypeHeader;
            myRequest.Method = "POST";

            string bearerToken = string.Format("bearer {0}", accessToken);
            myRequest.Headers.Add("Authorization", bearerToken);
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] dataBytes = encoding.GetBytes(bodyJSONData);

            Stream newStream = myRequest.GetRequestStream();
            newStream.Write(dataBytes, 0, dataBytes.Length);
            newStream.Close();

            WebResponse resp;
            try
            {
                resp = myRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resp;
        }

    }
}