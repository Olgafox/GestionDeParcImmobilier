using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Persistence.EntityRepositories
{
	public partial class Offre
	{
		private string _dateVenteFormated;
		public override string ToString()
		{
		 return string.Format("{0} {1} pcs", TypeImmobilier, Pieces);
		}

		private bool _isnew = false;

		public bool IsNew
		{
			get { return _isnew; }
			set { _isnew = value; }
		}
		public string NomOffre
		{
			get { return string.Format("{0} {1} pcs", TypeImmobilier, Pieces); }
			set { }
		}
		public string Adresse
		{
			get
			{
				return string.Format("{0}, \n{1} {2}", Rue, Npa, Localite);
			}
			set { }
			
		}
		public string AdresseSansEspace
		{
			get
			{
				return string.Format("{0}, {1} {2}", Rue, Npa, Localite);
			}
			set { }

		}
		public string DateVenteFormated
		{
			get
			{
				foreach (Vente v in Ventes)
				{
					_dateVenteFormated = v.DateVente.ToString("dd.MM.yyyy");
				}
				return _dateVenteFormated;
			}
			set { _dateVenteFormated = value; }
		}
		public string IsActuel
		{
			get
			{
				if (Actuel == 1)
					return "oui";
				else
					return "non";
			}
			set { }
		}

		public string ResumeOffre
		{
			get
			{
				return string.Format("Surface : \t {0} \n Pieces : \t {1} \n Nombre d'étages : \t{2} Etage : \t{3}\n Prix : \t{4} \n Vendeur: {5}",
					Surface, Pieces, Nombre_Etages, Etage, Prix, Client.PrenomNom);
			}
			set { }

		}
	}
}
