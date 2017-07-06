
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class VenteAcheteurReport
	{
		VenteClient _va;
		public VenteAcheteurReport()
		{ }
		public VenteAcheteurReport(VenteClient va)
		{
			_va = va;
		}
		public string DateVente { get { return _va.DateVente; } }
		public string NomOffre { get { return _va.NomOffre; } }
		public string Region { get { return _va.Region; } }
		public decimal Surface { get { return _va.Surface; } }
		public decimal Prix { get { return _va.Prix; } }
		public string Adresse { get { return _va.Adresse; } }
	}
}
