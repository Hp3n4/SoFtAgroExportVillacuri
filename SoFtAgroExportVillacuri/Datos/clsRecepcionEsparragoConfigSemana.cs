using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoFtAgroExportVillacuri
{
    class clsRecepcionEsparragoConfigSemana
    {
        public int mvarIdSemana;
        private int mvarAnio;
        private int mvarMes;
        private int mvarDia;
        private DateTime mvarDesde;
        private DateTime mvarHasta;
        private int mvarSemana;
        private char mvarEstado;
        private string mvarPC;


        public int IdSemana
        {
            get { return mvarIdSemana; }
            set { mvarIdSemana = value; }
        }
        public int Anio
        {
            get { return mvarAnio; }
            set { mvarAnio = value; }
        }
        public int Mes
        {
            get { return mvarMes; }
            set { mvarMes = value; }
        }
        public int Dia
        {
            get { return mvarDia; }
            set { mvarDia = value; }
        }
        public DateTime Desde
        {
            get { return mvarDesde; }
            set { mvarDesde = value; }
        }
        public DateTime Hasta
        {
            get { return mvarHasta; }
            set { mvarHasta = value; }
        }     
        public int Semana
        {
            get { return mvarSemana; }
            set { mvarSemana = value; }
        }
        public char Estado
        {
            get { return mvarEstado; }
            set { mvarEstado = value; }
        }
        public string PC
        {
            get { return mvarPC; }
            set { mvarPC = value; }
        }
    }
}
