using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPI.Presentation.Reporting;

namespace GPI.Presentation.Reporting
{
	public class ReportedClient
	{
		public ReportedClient()
		{ }
		public ReportedClient(string prenomNom, string adresse, string telephone)
		{
			PrenomNom = prenomNom;
			Adresse = adresse;
			Telephone = telephone;
		}

		public string PrenomNom { get; set; }
		public string Adresse { get; set; }
		public string Telephone { get; set; }
		public List<OffreReport> ReportedOffres { get; set; }
		public List<VenteAcheteurReport> ReportedVentesListe { get; set; }
		
		public List<VenteVendeurReport> ReportedVentesVendeurListe { get; set; }
		
	}
}
