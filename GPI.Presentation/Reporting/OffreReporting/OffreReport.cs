using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class OffreReport
	{
		private ReportingOffre _reportingOffre;

		public OffreReport(ReportingOffre o)
		{
			_reportingOffre = o;
		}
		public string NomOffre { get { return _reportingOffre.NomOffre; } }
		public string Region { get { return _reportingOffre.Region; } }
		public string Adresse { get { return _reportingOffre.Adresse; } }
		public int Nombre_Etages { get { return _reportingOffre.Nombre_Etages; } }
		public int Etage { get { return _reportingOffre.Etage; } }
		public decimal Pieces { get { return _reportingOffre.Pieces; } }
		public decimal Surface { get { return _reportingOffre.Surface; } }
		public decimal Prix { get { return _reportingOffre.Prix; } }
		public string VendeurPrenomNom { get { return _reportingOffre.VendeurPrenomNom; } }
		public string Actuel { get { return _reportingOffre.Actuel; } }
	}
}

