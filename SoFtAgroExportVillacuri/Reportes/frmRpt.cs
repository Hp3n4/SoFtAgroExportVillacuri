using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoFtAgroExportVillacuri
{
    public partial class frmRpt : Form
    {
        public frmRpt()
        {
            InitializeComponent();
        }
        public DateTime FecharptRE;
        private void frmRpt_Load(object sender, EventArgs e)
        {
            CrystalReport1 rptRE = new CrystalReport1();
            //Reportes.rptRecepcionEsparrago rptRE = new Reportes.rptRecepcionEsparrago();
            rptRE.SetParameterValue("@FechaInicio", FecharptRE);
            rptRE.SetParameterValue("@FechaFin", FecharptRE);
            crystalReportViewer1.ReportSource = rptRE;
            rptRE.SetDatabaseLogon("Sisgalenplus02", "Vannia1419");
                
                //SetDatabaseLogon();
        }
    }
}
