using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsersUniversidad
{
    public partial class CatalogoUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListadoDeUsuarios();
            }
        }

        protected void ListadoDeUsuarios()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("SP_ConsultarUsuario", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            // Agregar();
            ClsUsuarios.SetNombre(tNombre.Text);
            ClsUsuarios.SetClave(tClave.Text);
            ClsUsuarios.SetEdad(int.Parse(tEdad.Text));
            if (ClsUsuarios.AgregarUsuario())
            {
                ListadoDeUsuarios();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no ha sido ingresado');", true);
            }
        }

        /*
        public void Agregar()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("Sp_Agregar", con);
            //command.Parameters.Add(new SqlParameter("@codigo", "tCodigo.Text"));
            command.Parameters.Add(new SqlParameter("@nombre", tNombre.Text));
            command.Parameters.Add(new SqlParameter("@clave", tClave.Text));
            command.Parameters.Add(new SqlParameter("@edad", tEdad.Text));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ListadoDeUsuarios();
        }*/

        protected void ConsultaFiltro()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_ConsultarUsuarioFiltro", con);
            //command.Parameters.Add(new SqlParameter("@codigo", "tCodigo.Text"));
            command.Parameters.Add(new SqlParameter("@nombre", tNombre.Text));
            command.CommandType =CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource= dt;
            GridView1.DataBind();
            
        }
        //

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetCodigo(Convert.ToInt32(tCodigo.Text));
            if (ClsUsuarios.BorrarUsuario())
            {
                ListadoDeUsuarios();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no ha sido borrado');", true);
            }
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetCodigo(Convert.ToInt32(tCodigo.Text));
            ClsUsuarios.SetNombre(tNombre.Text);
            ClsUsuarios.SetClave(tClave.Text);
            ClsUsuarios.SetEdad(int.Parse(tEdad.Text));
            if (ClsUsuarios.ModificarUsuario())
            {
                ListadoDeUsuarios();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no ha sido modificado');", true);
            }
        }

        protected void bConsultar_Click(object sender, EventArgs e)
        {
            ConsultaFiltro();
        }
    }
}