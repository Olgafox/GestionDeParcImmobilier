using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class VenteClient
	{
		public VenteClient()
		{ }
		public VenteClient(string dateVente, string nomOffre, decimal surface, decimal prix, string adresse, string region)
		{
			DateVente = dateVente;
			NomOffre = nomOffre;
			Surface = surface;
			Prix = prix;
			Adresse = adresse;
			Region = region;
		}
		public string DateVente { get; set; }
		public string NomOffre { get; set; }
		public string Region { get; set; }
		public decimal Surface { get; set; }
		public decimal Prix { get; set; }
		public string Adresse { get; set; }
	}
}
