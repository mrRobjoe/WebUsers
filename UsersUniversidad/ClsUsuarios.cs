using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsersUniversidad
{
    /*Esta clase es una copia de lo que tenemos en la base de datos.*/
    public class ClsUsuarios
    {
        private static string nombre { get; set; }
        private static string clave { get; set; }
        private static int edad { get; set; }

        private static int codigo { get; set; }

        /*constructor de clase*/
        public ClsUsuarios(string nom, string contraseña, int edadd)
        {
            nombre = nom;
            clave = contraseña;
            edad = edadd;
        }
        /*métodos de la clase get=devoler valor set=asignar valor*/
        public static string GetNombre() { return nombre; }
        public static string GetClave() { return clave; }
        public static int GetEdad() { return edad; }
        public static int GetCodigo() { return codigo; }

        public static void SetCodigo(int cod)
        {
            codigo = cod;
        }
        public static void SetNombre(string nom)
        {
            nombre = nom;
        }
        public static void SetClave(string contraseña)
        {
            clave = contraseña;
        }
        public static void SetEdad(int edadd)
        {
            edad = edadd;
        }

        public static Boolean ConsultarUsuario()
        {
            return true;
        }
        public static Boolean AgregarUsuario()
        {
            Boolean existe = false;
            /*string s = System.Configuration.ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);*/
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                /*conexion.Open();
                SqlCommand comando = new SqlCommand("insert into usuario (Nombre, Clave, Edad) " + "values ('" + nombre + "','" + clave + "','"+edad+"')", conexion);//completar
                comando.ExecuteNonQuery();*/
                con.Open();
                SqlCommand command = new SqlCommand("Sp_Agregar", con);
                //command.Parameters.Add(new SqlParameter("@codigo", "tCodigo.Text"));
                command.Parameters.Add(new SqlParameter("@nombre", nombre));
                command.Parameters.Add(new SqlParameter("@clave", clave));
                command.Parameters.Add(new SqlParameter("@edad", edad));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public static Boolean BorrarUsuario()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_BorrarUsuario", con);
                command.Parameters.Add(new SqlParameter("@codigo", codigo));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public static Boolean ModificarUsuario()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHUNIVERSIDADConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_ActualizarUsuario", con);
                command.Parameters.Add(new SqlParameter("@codigo", codigo));
                command.Parameters.Add(new SqlParameter("@nombre", nombre));
                command.Parameters.Add(new SqlParameter("@clave", clave));
                command.Parameters.Add(new SqlParameter("@edad", edad));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }
    }

}