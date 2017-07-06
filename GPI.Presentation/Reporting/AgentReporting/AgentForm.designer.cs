namespace GPI.Presentation.Reporting
{
	partial class AgentForm
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
			this.AgentReportingBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.agentReportingBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.listeVentesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.agentReportingBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
			this.ClientReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.clientReportBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.AgentReportingBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.agentReportingBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.listeVentesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.agentReportingBindingSource2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ClientReportBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// AgentReportingBindingSource
			// 
			this.AgentReportingBindingSource.DataSource = typeof(GPI.Presentation.Reporting.AgentReporting);
			// 
			// agentReportingBindingSource1
			// 
			this.agentReportingBindingSource1.DataSource = typeof(GPI.Presentation.Reporting.AgentReporting);
			// 
			// reportViewer1
			// 
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.AgentReportingBindingSource;
			reportDataSource2.Name = "DataSet2";
			reportDataSource2.Value = this.agentReportingBindingSource1;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "GPI.Presentation.Reporting.AgentReporting.AgentReport.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(-4, 1);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.Size = new System.Drawing.Size(2438, 1407);
			this.reportViewer1.TabIndex = 0;
			// 
			// listeVentesBindingSource
			
			// 
			// agentReportingBindingSource2
			// 
			this.agentReportingBindingSource2.DataSource = typeof(GPI.Presentation.Reporting.AgentReporting);
			// 
			// ClientReportBindingSource
			// 
			this.ClientReportBindingSource.DataSource = typeof(GPI.Presentation.Reporting.ClientReport);
			// 
			// clientReportBindingSource1
			// 
			this.clientReportBindingSource1.DataSource = typeof(GPI.Presentation.Reporting.ClientReport);
			// 
			// AgentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(2418, 1406);
			this.Controls.Add(this.reportViewer1);
			this.Name = "AgentForm";
			this.Text = "AgentForm";
			this.Load += new System.EventHandler(this.AgentForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.AgentReportingBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.agentReportingBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.listeVentesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.agentReportingBindingSource2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ClientReportBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.clientReportBindingSource1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private System.Windows.Forms.BindingSource AgentReportingBindingSource;
		private System.Windows.Forms.BindingSource listeVentesBindingSource;
		private System.Windows.Forms.BindingSource agentReportingBindingSource1;
		private System.Windows.Forms.BindingSource agentReportingBindingSource2;
		private System.Windows.Forms.BindingSource ClientReportBindingSource;
		private System.Windows.Forms.BindingSource clientReportBindingSource1;
	}
}