using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace UsersUniversidad
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetNombre(tUsuario.Text);
            ClsUsuarios.SetClave(tClave.Text);
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("select Nombre, Clave from Usuario " +
                    "where Nombre = '" + ClsUsuarios.GetNombre() + "' and Clave ='" + ClsUsuarios.GetClave() + "'", conexion);
                SqlDataReader registro = comando.ExecuteReader();
                if (registro.Read())
                {
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no existe');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Revisar la conexión');", true);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}