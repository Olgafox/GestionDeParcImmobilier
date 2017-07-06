using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPI.Presentation.Reporting
{
	public partial class ClientForm : Form
	{
		private ClientReport clientReport;

		public ClientForm()
		{
			InitializeComponent();
		}

		public ClientForm(ClientReport report):this()
		{
			clientReportBindingSource3.DataSource = report;
			clientReportBindingSource1.DataSource = report.ReportedOffresListe;
			clientReportBindingSource2.DataSource = report.ReportedVentesListe;
			clientReportBindingSource4.DataSource = report.ReportedVentesVendeurListe;
		}

		private void ClientForm_Load(object sender, EventArgs e)
		{

			this.reportViewer1.RefreshReport();
		}
		
	}
}
