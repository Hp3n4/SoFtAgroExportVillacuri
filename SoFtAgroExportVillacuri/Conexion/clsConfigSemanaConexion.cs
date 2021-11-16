using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SoFtAgroExportVillacuri
{
    class clsConfigSemanaConexion
    {
        public int ConfigSemanaInsertBystoredProcedure(clsRecepcionEsparragoConfigSemana objRecepcionEsparragoConfigSemana)
        {
            int cantFilas = 0;
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = clsConexionBd.CadenaConexion;
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("dbo.uspConfigSemanaInsert", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Anio", objRecepcionEsparragoConfigSemana.Anio);
                cmd.Parameters.AddWithValue("@Mes", objRecepcionEsparragoConfigSemana.Mes);
                cmd.Parameters.AddWithValue("@Dia", objRecepcionEsparragoConfigSemana.Dia);
                cmd.Parameters.AddWithValue("@Desde", objRecepcionEsparragoConfigSemana.Desde);
                cmd.Parameters.AddWithValue("@Hasta", objRecepcionEsparragoConfigSemana.Hasta);
                cmd.Parameters.AddWithValue("@Semana", objRecepcionEsparragoConfigSemana.Semana);
                cmd.Parameters.AddWithValue("@PC", objRecepcionEsparragoConfigSemana.PC);
                
                cantFilas = cmd.ExecuteNonQuery();
                Conexion.Close();
            }
            catch (Exception ex)
            {
                return 0;
            }
            return cantFilas;
        }
    }
}
