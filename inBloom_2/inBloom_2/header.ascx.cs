using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace inBloom_2
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userFullName.Text = Session["user_fullName"].ToString();
            userRole.Text = Session["user_role"].ToString();
        }
    }
}