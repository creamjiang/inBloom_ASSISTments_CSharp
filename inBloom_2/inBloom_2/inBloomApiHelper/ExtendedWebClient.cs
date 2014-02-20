using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace inBloom_2.inBloomApiHelper
{
    public class ExtendedWebClient : WebClient
    {
        private WebRequest request = null;

        public HttpStatusCode StatusCode { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            this.request = base.GetWebRequest(address);

            if (this.request is HttpWebRequest)
            {
                ((HttpWebRequest)this.request).AllowAutoRedirect = false;
            }

            try
            {
                HttpWebResponse response = base.GetWebResponse(this.request) as HttpWebResponse;
                if (response != null)
                    StatusCode = response.StatusCode;
            }
            catch (HttpCompileException msg)
            {
                throw msg;
            }

            return this.request;
        }
    }
}