namespace GPI.Presentation.Reporting
{
	partial class ClientForm
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.clientReportBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
			this.clientReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.clientReportBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.clientReportBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.ClientReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.agentReportingBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ClientReportBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.agentReportingBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// clientReportBindingSource3
			// 
			this.clientReportBindingSource3.DataSource = typeof(GPI.Presentation.Reporting.ClientReport);
			// 
			// clientReportBindingSource1
			// 
			this.clientReportBindingSource1.DataSource = typeof(GPI.Presentation.Reporting.ClientReport);
			// 
			// clientReportBindingSource2
			// 
			this.clientReportBindingSource2.DataSource = typeof(GPI.Presentation.Reporting.ClientReport);
			// 
			// clientReportBindingSource4
			// 
			this.clientReportBindingSource4.DataSource = typeof(GPI.Presentation.Reporting.ClientReport);
			// 
			// reportViewer1
			// 
			reportDataSource1.Name = "ClientData";
			reportDataSource1.Value = this.clientReportBindingSource3;
			reportDataSource2.Name = "Offres";
			reportDataSource2.Value = this.clientReportBindingSource1;
			reportDataSource3.Name = "VentesAcheteur";
			reportDataSource3.Value = this.clientReportBindingSource2;
			reportDataSource4.Name = "VentesVendeur";
			reportDataSource4.Value = this.clientReportBindingSource4;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "GPI.Presentation.Reporting.ClientReporting.ClientReport.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 0);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(2525, 1449);
			this.reportViewer1.TabIndex = 0;
			// 
			// ClientReportBindingSource
			// 
			this.ClientReportBindingSource.DataSource = typeof(GPI.Presentation.Reporting.ClientReport);
			// 
			// agentReportingBindingSource
			// 
			this.agentReportingBindingSource.DataSource = typeof(GPI.Presentation.Reporting.AgentReporting);
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2521, 1449);
			this.Controls.Add(this.reportViewer1);
			this.Name = "ClientForm";
			this.Text = "ClientForm";
			this.Load += new System.EventHandler(this.ClientForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ClientReportBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.agentReportingBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource ClientReportBindingSource;
		private System.Windows.Forms.BindingSource clientReportBindingSource1;
		private System.Windows.Forms.BindingSource agentReportingBindingSource;
		private System.Windows.Forms.BindingSource clientReportBindingSource2;
		private System.Windows.Forms.BindingSource clientReportBindingSource3;
		private System.Windows.Forms.BindingSource clientReportBindingSource4;
	}
}