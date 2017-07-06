namespace GPI.Presentation.Reporting.VenteReporting
{
	partial class VenteForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.VenteReportingBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.VenteReportingBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// reportViewer1
			// 
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.VenteReportingBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "GPI.Presentation.Reporting.VenteReporting.VenteReport.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 0);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(1739, 1154);
			this.reportViewer1.TabIndex = 0;
			// 
			// VenteReportingBindingSource
			// 
			this.VenteReportingBindingSource.DataMember = "VenteReporting";
			// 
			// VenteForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1739, 1140);
			this.Controls.Add(this.reportViewer1);
			this.Name = "VenteForm";
			this.Text = "VenteForm";
			this.Load += new System.EventHandler(this.VenteForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.VenteReportingBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource VenteReportingBindingSource;
	}
}