using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class AgentReporting
	{
		ReportedAgent ra;
		public AgentReporting()
		{ }
		public AgentReporting(ReportedAgent a)
		{
			ra = a;
		}
		public string PrenomNom { get { return ra.PrenomNom; } }
		public string Addresse { get { return ra.Addresse; } }
		public string Telephone { get { return ra.Telephone; } }
		public decimal CommissionTotale { get { return ra.CommissionTotale; } }
		
		public List<VenteReport> ReportedVentes { get { return ra.ReportedVentes; } }
	}
}
