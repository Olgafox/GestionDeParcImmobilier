
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class ClientReport
	{
		ReportedClient _rc;
		public ClientReport()
		{ }
		public ClientReport(ReportedClient rc)
		{
			_rc = rc;
		}
		public string PrenomNom { get { return _rc.PrenomNom; } }
		public string Adresse { get { return _rc.Adresse; } }
		public string Telephone { get { return _rc.Telephone; } }
		public List<OffreReport> ReportedOffresListe { get { return _rc.ReportedOffres; } }
		public List<VenteAcheteurReport> ReportedVentesListe { get { return _rc.ReportedVentesListe; } }
		public List<VenteVendeurReport> ReportedVentesVendeurListe { get { return _rc.ReportedVentesVendeurListe; } }


	}

}
