using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace inBloom_2.inBloomApiHelper
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public JArray ResponseObject { get; set; }
        public string ResponseString { get; set; }
    }
}