using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPI.Presentation.Reporting.RechercheReporting
{
	public partial class RechercheForm : Form
	{
		public RechercheForm()
		{
			InitializeComponent();
		}

		private void RechercheForm_Load(object sender, EventArgs e)
		{

			this.reportViewer1.RefreshReport();
		}
		public RechercheForm(RechercheResult report) : this()
		{
			RechercheResultBindingSource.DataSource = report;
		}
	}
}
