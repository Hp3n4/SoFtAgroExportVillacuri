using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SoFtAgroExportVillacuri
{
    public class clsUsuarioConexion
    {
        private String CadenaConexion = @"Data Source=SISGALENPLUSHRI;Initial Catalog=dbAgroVillacuri;User ID=Sisgalenplus02;Password=Vannia1419;Connect Timeout=50;"; //sin usuario y contraseña
        public bool Login(clsUsuarioAcceder objUsuarioAcceder)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("dbo.upsUsuarioAcceder", conexion);
            conexion.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", objUsuarioAcceder.Nombre);
            cmd.Parameters.AddWithValue("@Clave", objUsuarioAcceder.Clave);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    objUsuarioAcceder.IdUsario = dr.GetInt32(0);
                    
                }
                return true;
            }
            else return false;
        }
    }
}
