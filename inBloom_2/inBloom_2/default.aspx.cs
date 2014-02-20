using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using inBloom_2.Utilities;
using inBloom_2.inBloomApiHelper;


namespace inBloom_2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["access_token"] == null)
            {
                if (Request.QueryString["code"] == null)
                {
                    string authorizeUrl = string.Format("{0}/authorize?response_type=code&client_id={1}&redirect_uri={2}", Global.inBloomBaseOAuth,Global.clientID, Global.redirectUri);
                    Response.Redirect(authorizeUrl); //make a call then return ?code=
                }
                else
                {
                    // START AUTHORIZATION LOGIN
                    //get code
                    string code = Request.QueryString["code"];
                    string accessTokenUrl = string.Format("{0}/token?client_id={1}&client_secret={2}&grant_type=authorization_code&redirect_uri={3}&code={4}", Global.inBloomBaseOAuth, Global.clientID, Global.clientSecret, Global.redirectUri, code);

                    // Not use Api Helper because do not have authorization code
                    WebClient restClient = new WebClient();
                    restClient.Headers.Add("Accept", Global.inBloomAcceptHeader);
                    restClient.Headers.Add("Content-Type", Global.inBloomContentTypeHeader);
                    
                    // Get return string
                    string result = restClient.DownloadString(accessTokenUrl);
                    
                    // Convert to Json
                    JObject response = JObject.Parse(result);
                    string access_token = response["access_token"].ToString();
                    Session["access_token"] = access_token;

                    //GET FULL NAME and USER ROLE
                    string apiSessionCheck = string.Format("{0}/system/session/check",Global.inBloomBaseAPI);
                    ApiResponse requestSessionCheck = ApiClient.Request(apiSessionCheck,Session["access_token"].ToString());
                    if (requestSessionCheck.ResponseObject != null)
                    {
                        JArray userInfo = requestSessionCheck.ResponseObject;
                        Session["user_fullName"] = userInfo[0]["full_name"].ToString();
                        Session["user_role"] = userInfo[0]["sliRoles"].ToString();
                    }

                    // START HOME
                    string apiHATEOASHome = string.Format("{0}/home",Global.inBloomBaseAPI);
                    ApiResponse requestHome = ApiClient.Request(apiHATEOASHome, Session["access_token"].ToString());
                    if (requestHome.ResponseObject != null)
                    {
                        JArray userInfo = requestHome.ResponseObject;

                        foreach (JObject obj in (JArray)userInfo[0]["links"])
                        {
                            if ((string)obj["rel"] == "self")
                            {
                                string link = (string)obj["href"];
                                string id = link.Substring(link.Length - 43);
                                Session["user_id"] = id;
                            }
                        }
                    }

                }
            } // if session[access_token]
            Response.Redirect("main.aspx");
        }
    }
}