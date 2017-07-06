using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.Reporting
{
	public class ReportingOffre
	{
		public ReportingOffre()
		{ }
		public ReportingOffre(string type, string region, string adresse, int nombre_etages, int etage, decimal pieces, decimal surface,
			decimal prix, string vendeurPrenomNom, string actuel, string nomOffre)
		{
			Type = type;
			Region = region;
			Adresse = adresse;
			Nombre_Etages = nombre_etages;
			Etage = etage;
			Pieces = pieces;
			Surface = surface;
			Prix = prix;
			VendeurPrenomNom = vendeurPrenomNom;
			Actuel = actuel;
			NomOffre = nomOffre;
		}
		public ReportingOffre(string nomOffre, string adresse, decimal prix, decimal surface)
		{
			Adresse = adresse;
			NomOffre = nomOffre;
			Prix = prix;
			Surface = surface;
		}
		public ReportingOffre(string nomOffre, string adresse, decimal prix, decimal surface, string actuel, int etage, int nombre_etages)
		{
			Adresse = adresse;
			NomOffre = nomOffre;
			Prix = prix;
			Surface = surface;
			Actuel = actuel;
			Etage = etage;
			Nombre_Etages = nombre_etages;
		}
		public string NomOffre { get; set; }
		public string Type { get; set; }
		public string Region { get; set; }
		public string Adresse { get; set; }
		public int Nombre_Etages { get; set; }
		public int Etage { get; set; }
		public decimal Pieces { get; set; }
		public decimal Surface { get; set; }
		public decimal Prix { get; set; }
		public string VendeurPrenomNom { get; set; }
		public string Actuel { get; set; }

		/*public virtual Client Client { get; set; }
		public virtual Region Region { get; set; }
		public virtual TypeImmobilier TypeImmobilier { get; set; }
		
		public virtual ICollection<Vente> Ventes { get; set; }*/
		
	}
}
