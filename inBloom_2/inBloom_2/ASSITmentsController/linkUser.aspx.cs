using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Web.UI.WebControls;
using inBloom_2.Utilities;

namespace inBloom_2.ASSITmentsController
{
    public partial class linkUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Request.QueryString["user"].ToString();
            string access = Request.QueryString["access"].ToString();
            Session["OnBehalfOf"] = access;
            Global.OnBehalfOf = access;

            Response.Redirect("../main.aspx");
        }
    }
}