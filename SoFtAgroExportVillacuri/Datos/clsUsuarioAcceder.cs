using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoFtAgroExportVillacuri
{
    public class clsUsuarioAcceder
    {
        public int mvarIdUsuario;
        private string mvarNombre;
        private string mvarClave;

        public int IdUsario
        {
            get { return mvarIdUsuario; }
            set { mvarIdUsuario = value; }
        }

        public string Nombre
        {
            get { return mvarNombre; }
            set { mvarNombre = value; }
        }

        public string Clave
        {
            get { return mvarClave; }
            set { mvarClave = value; }
        }
    }
}
