using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class VenteReport
	{
		ReportedVente _vente;
		public VenteReport()
		{
		}
		public VenteReport(ReportedVente rv)
		{
			_vente = rv;
		}
		public string AgentNom { get { return _vente.AgentNom; } }
		public string ClientNom { get { return _vente.ClientNom; } }
		public string ClientVendeurNom { get { return _vente.ClientVendeurNom; } }
		public string DateVente { get { return _vente.DateVente; } }
		public string NomVente { get { return _vente.NomVente; } }
		public decimal CommissionAgence { get { return _vente.CommissionAgence; } }
		public decimal CommissionAgent { get { return _vente.CommissionAgent; } }
		public string Adresse { get { return _vente.reportingOffre.Adresse; } }
		public string NomOffre { get { return _vente.reportingOffre.NomOffre; } }
		public decimal Prix { get { return _vente.reportingOffre.Prix; } }
		public decimal Surface { get { return _vente.reportingOffre.Surface; } }

	}
}
