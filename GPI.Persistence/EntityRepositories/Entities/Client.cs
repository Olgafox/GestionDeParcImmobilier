using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Persistence.EntityRepositories
{
	public partial class Client
	{
		private ICollection<Offre> _listeVentes;
		public override string ToString()
		{
			return string.Format("{0} {1}", Prenom, Nom);
		}
		public Client(int id)
		{
			Id = id;

		}
		public ICollection<Offre> ListeVentes
		{
			get{
				
				_listeVentes = new HashSet<Offre>();
				foreach (Offre o in Offres)
				{
					foreach (Vente v in o.Ventes)
					{
						if (v.Offre.VendeurId == Id)
							_listeVentes.Add(o);
					}
				}
				return _listeVentes;
			}
			set { } 
		}

		public string PrenomNom
		{
			get
			{
				return string.Format("{0} {1}", Prenom, Nom);
			}
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
	}
}

