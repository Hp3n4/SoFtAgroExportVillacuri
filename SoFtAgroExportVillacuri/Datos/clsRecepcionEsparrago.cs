using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoFtAgroExportVillacuri
{
    public class clsRecepcionEsparrago
    {
        private int mvarIdRecepcionPLanta;
        private DateTime mvarFecha;
        private char mvarHora;
        private int mvarIdChofer;
        private string mvarChofer;
        private string mvarPlacaVehiculo;
        private int mvarIdTipoJaba;
        private string mvarDescripcionJaba;
        private float mvarPesoJaba;
        private int mvarIdTipoParihuela;
        private string mvarDescripcionParihuela;
        private float mvarPesoParihuela;
        private float mvarTotalDestare;
        private float mvarPesoCampo;
        private float mvarTotalJabas;
        private float mvarTotalTara;
        private float mvarTotalPesoBruto;
        private float mvarTotalNeto;
        private float mvarPesoPromedio;
        private DateTime mvarRegistro;
        private string mvarMaquina;
        private string mvarUsuario;
        

        public int IdRecepcionPLanta
        {
            get { return mvarIdRecepcionPLanta; }
            set { mvarIdRecepcionPLanta = value; }
        }
        public DateTime Fecha
        {
            get { return mvarFecha; }
            set { mvarFecha = value; }
        }
        public char Hora
        {
            get { return mvarHora; }
            set { mvarHora = value; }
        }
        public int IdChofer
        {
            get { return mvarIdChofer; }
            set { mvarIdChofer = value; }
        }
        public string Chofer
        {
            get { return mvarChofer; }
            set { mvarChofer = value; }
        }

        public string PlacaVehiculo
        {
            get { return mvarPlacaVehiculo; }
            set { mvarPlacaVehiculo = value; }
        }
        public int IdTipoJaba
        {
            get { return mvarIdTipoJaba; }
            set { mvarIdTipoJaba = value; }
        }
        public string DescripcionJaba
        {
            get { return mvarDescripcionJaba; }
            set { mvarDescripcionJaba = value; }
        }
        public float PesoJaba
        {
            get { return mvarPesoJaba; }
            set { mvarPesoJaba = value; }
        }

        public int IdTipoParihuela
        {
            get { return mvarIdTipoParihuela; }
            set { mvarIdTipoParihuela = value; }
        }
        public string DescripcionParihuela
        {
            get { return mvarDescripcionParihuela; }
            set { mvarDescripcionParihuela = value; }
        }
        public float PesoParihuela
        {
            get { return mvarPesoParihuela; }
            set { mvarPesoParihuela = value; }
        }
        public float TotalDestare
        {
            get { return mvarTotalDestare; }
            set { mvarTotalDestare = value; }
        }
        public float TotalPesoCampo
        {
            get { return mvarPesoCampo; }
            set { mvarPesoCampo = value; }
        }
        public float TotalJabas
        {
            get { return mvarTotalJabas; }
            set { mvarTotalJabas = value; }
        }
        public float TotalTara
        {
            get { return mvarTotalTara; }
            set { mvarTotalTara = value; }
        }
        public float TotalPesoBruto 
        {
            get { return mvarTotalPesoBruto; }
            set { mvarTotalPesoBruto = value; }
        }
        public float TotalNeto 
        { 
            get { return mvarTotalNeto; }
            set { mvarTotalNeto = value; }
        }
        public float PesoPromedio
        {
            get { return mvarPesoPromedio; }
            set { mvarPesoPromedio = value; }
        }
        public DateTime Registro 
        { 
            get { return mvarRegistro; }
            set { mvarRegistro = value; }
        }
        public string Maquina
        {
            get { return mvarMaquina; }
            set { mvarMaquina = value; }
        }
        public string Usuario 
        { 
            get { return mvarUsuario; }
            set { mvarUsuario = value; }
        } 
    }
}
