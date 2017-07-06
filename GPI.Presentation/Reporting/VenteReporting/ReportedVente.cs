using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class ReportedVente
	{
		public ReportedVente(string dateVente, string agentNom, string clientNom, 
			string clientVendeurNom, decimal commissionAgence, decimal commissionAgent)
		{
			DateVente = dateVente;
			AgentNom = agentNom;
			ClientNom = clientNom;
			ClientVendeurNom = clientVendeurNom;
			CommissionAgence = commissionAgence;
			CommissionAgent = commissionAgent;
		}
		public ReportedVente(string dateVente,
					string nomVente,
					decimal commissionAgent)
		{
			DateVente = dateVente;
			NomVente = nomVente;
			CommissionAgent = commissionAgent;
		}
		
		public string AgentNom { get; set; }
		public string ClientNom { get; set; }
		public string NomVente { get; set; }
		public string ClientVendeurNom { get; set; }
		public string DateVente { get; set; }
		public decimal CommissionAgence { get; set; }
		public decimal CommissionAgent { get; set; }
		public ReportingOffre reportingOffre { get; set; }
	}
}
