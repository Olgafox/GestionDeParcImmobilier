using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class ReportedAgent
	{
		public ReportedAgent()
		{ }

		public ReportedAgent(string prenomNom, string addresse, string telephone, decimal commissionTotale)
		{
			PrenomNom = prenomNom;
			Addresse = addresse;
			Telephone = telephone;
			CommissionTotale = commissionTotale;
		}
		public string PrenomNom { get; set; }
		public string Addresse { get; set; }
		public string Telephone { get; set; }
		public decimal CommissionTotale { get; set; }
		public List<VenteReport> ReportedVentes { get; set; }
	}
}
