using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class RechercheResult
	{
		List<ReportingOffre> _rechercheListe;
		public RechercheResult()
		{ }
		public RechercheResult(List<ReportingOffre> rechercheListe)
		{
			_rechercheListe = rechercheListe;
			
		}
		public List<ReportingOffre> RechercheListe
		{ get { return _rechercheListe; }}
	}
}
