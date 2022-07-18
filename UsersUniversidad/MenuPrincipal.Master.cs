using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsersUniversidad
{
    public partial class MenuPrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lUser.Text = ClsUsuarios.GetNombre();
        }

        protected void bLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.RedirectPermanent("home.aspx");
            //Response.Redirect("home.aspx");
        }
    }
}