using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SoFtAgroExportVillacuri
{
    public class clsRecepcionEsparragoConexion
    {
        //<!------- CADENA DE CONEXION PARA REALIZAR LAS CONSULTAS ------>
        private String CadenaConexion = @"Data Source=SISGALENPLUSHRI;Initial Catalog=dbAgroVillacuri;User ID=Sisgalenplus02;Password=Vannia1419;Connect Timeout=50;";
        //<!----------- -------- ------FIN -- ----- -- ------ ----------->

        //<!-- REALIZA LA CONSULTA PARA LLENAR UN COMBOBOX DE CHOFERES -->
        public DataTable LlenarComboBoxChoferes()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            DataTable dt = new DataTable();            
            SqlCommand cmd = new SqlCommand("select idChofer, NomChofer from Choferes order by NomChofer", conexion); 
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            conexion.Open();
            adaptador.Fill(dt);           
            return dt;
        }
        //<!----------- -------- ------FIN -- ----- -- ------ ----------->

        public DataTable LlenarComboBoxNSemanas()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select SemanaAnio from RecepcionPlantaCamion where SemanaAnio <> 'NULL' group by FECHA, SemanaAnio ORDER BY SUBSTRING(CONVERT(VARCHAR, Fecha, 105), 1, 2), SUBSTRING(CONVERT(VARCHAR, Fecha, 105), 4, 2), SUBSTRING(CONVERT(VARCHAR, Fecha, 105), 7, 4)", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            conexion.Open();
            adaptador.Fill(dt);
            return dt;
        }
        public DataTable LlenarComboBoxTipoJaba()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            DataTable dt = new DataTable();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select idTipoJaba,NomTipoJaba,PesoJaba from TipoJaba", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            conexion.Open();
            adaptador.Fill(dt);
            dr = cmd.ExecuteReader();
            return dt;
        }
        public DataTable LlenarComboBoxTipoJParihuela()
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            DataTable dt = new DataTable();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select idTipoParihuela,NomTipoParihuela,PesoParihuela from TipoParihuela", conexion);
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            conexion.Open();
            adaptador.Fill(dt);
            dr = cmd.ExecuteReader();
            return dt;
        }
        public void autocompletar(TextBox txtPlaca)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("Select * From VehiculosEmpresa", conexion);
            conexion.Open();
            dr = cmd.ExecuteReader();            
            while (dr.Read())
            {
                txtPlaca.AutoCompleteCustomSource.Add(dr["Placa"].ToString());
            }
            dr.Close();
            conexion.Close();
        }
        public int RecepcionEsparragoInsertBystoredProcedure(clsRecepcionEsparrago objRecepcionEsparrago)
        {
            int cantFilas = 0;
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = clsConexionBd.CadenaConexion;
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("dbo.uspRecepcionInsert", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Fecha", objRecepcionEsparrago.Fecha);
                cmd.Parameters.AddWithValue("@IdChofer", objRecepcionEsparrago.IdChofer);
                cmd.Parameters.AddWithValue("@PlacaVehiculo", objRecepcionEsparrago.PlacaVehiculo);
                cmd.Parameters.AddWithValue("@IdTipoJaba", objRecepcionEsparrago.IdTipoJaba);
                cmd.Parameters.AddWithValue("@IdtipoParihuela", objRecepcionEsparrago.IdTipoParihuela);
                cmd.Parameters.AddWithValue("@TotalDestare", objRecepcionEsparrago.TotalPesoCampo);
                cmd.Parameters.AddWithValue("@TotalJabas", objRecepcionEsparrago.TotalJabas);
                cmd.Parameters.AddWithValue("@TotalTara", objRecepcionEsparrago.TotalTara);
                cmd.Parameters.AddWithValue("@TotalPesoBruto", objRecepcionEsparrago.TotalPesoBruto);
                cmd.Parameters.AddWithValue("@TotalNeto", objRecepcionEsparrago.TotalNeto);
                cmd.Parameters.AddWithValue("@Diferencia", objRecepcionEsparrago.PesoPromedio);
                cmd.Parameters.AddWithValue("@Maquina", objRecepcionEsparrago.Maquina);
                cmd.Parameters.AddWithValue("@Usuario", objRecepcionEsparrago.Usuario);

                cantFilas = cmd.ExecuteNonQuery();
            Conexion.Close();
            }
            catch (Exception ex)
            {
                    return 0;
            }
               return cantFilas;
        }
        public int RecepcionEsparragoUpdateBystoredProcedure(clsRecepcionEsparrago objRecepcionEsparrago)
        {
            int cantFilas = 0;
            try
            {
                SqlConnection Conexion = new SqlConnection();
                Conexion.ConnectionString = clsConexionBd.CadenaConexion;
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("dbo.uspRecepcionUpdate", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdRecepcionPlanta", objRecepcionEsparrago.IdRecepcionPLanta);
                cmd.Parameters.AddWithValue("@Fecha", objRecepcionEsparrago.Fecha);
                cmd.Parameters.AddWithValue("@IdChofer", objRecepcionEsparrago.IdChofer);
                cmd.Parameters.AddWithValue("@PlacaVehiculo", objRecepcionEsparrago.PlacaVehiculo);
                cmd.Parameters.AddWithValue("@IdTipoJaba", objRecepcionEsparrago.IdTipoJaba);
                cmd.Parameters.AddWithValue("@IdtipoParihuela", objRecepcionEsparrago.IdTipoParihuela);
                cmd.Parameters.AddWithValue("@TotalDestare", objRecepcionEsparrago.TotalPesoCampo);
                cmd.Parameters.AddWithValue("@TotalJabas", objRecepcionEsparrago.TotalJabas);
                cmd.Parameters.AddWithValue("@TotalTara", objRecepcionEsparrago.TotalTara);
                cmd.Parameters.AddWithValue("@TotalPesoBruto", objRecepcionEsparrago.TotalPesoBruto);
                cmd.Parameters.AddWithValue("@TotalNeto", objRecepcionEsparrago.TotalNeto);
                cmd.Parameters.AddWithValue("@Diferencia", objRecepcionEsparrago.PesoPromedio);
                cmd.Parameters.AddWithValue("@Maquina", objRecepcionEsparrago.Maquina);
                cmd.Parameters.AddWithValue("@Usuario", objRecepcionEsparrago.Usuario);

                cantFilas = cmd.ExecuteNonQuery();
                Conexion.Close();
            }
            catch(Exception ex)
            {
                return 0;
            }
            return cantFilas;
        }
        public DataTable Mostrar()
        {
            //TRANSACT SQL
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlConnection Conexion = new SqlConnection(CadenaConexion);
            Conexion.Open();
            SqlCommand cmd = new SqlCommand("dbo.uspRecepcionPlantaCamionVista", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            Conexion.Close();
            return tabla;
        }

        public DataTable MostrarConfigSemana()
        {
            //TRANSACT SQL
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            SqlConnection Conexion = new SqlConnection(CadenaConexion);
            Conexion.Open();
            SqlCommand cmd = new SqlCommand("dbo.uspRecepcionConfigSemana", Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            Conexion.Close();
            return tabla;
        }

        internal int RecepcionEsparragoEliminar(int id)
        {
            int cantFilas;
            try
            {
                SqlConnection Conexion = new SqlConnection(CadenaConexion);
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("update RecepcionPlantaCamion  set Estado = '0' where IdRecepcionPLanta = @ID", Conexion);
                //SqlCommand cmd = new SqlCommand("delete from RecepcionPlantaCamion where IdRecepcionPLanta = @ID", Conexion);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", id);

                cantFilas = cmd.ExecuteNonQuery();
                Conexion.Close();
            }
            catch
            {
                return 0;
            }
            return cantFilas;
        }
    }
}
