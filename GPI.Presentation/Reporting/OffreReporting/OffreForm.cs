using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPI.Presentation.Reporting.OffreReporting
{
	public partial class OffreForm : Form
	{
		public OffreForm()
		{
			InitializeComponent();
		}
		public OffreForm(OffreReport rapport) : this()
		{
			OffreReportBindingSource.DataSource = rapport;

		}
		private void OffreForm_Load(object sender, EventArgs e)
		{

			this.reportViewer1.RefreshReport();
		}
	}
}
