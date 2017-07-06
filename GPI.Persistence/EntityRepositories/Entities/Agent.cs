using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Persistence.EntityRepositories
{
	public partial class Agent
	{
		public override string ToString()
		{
			return string.Format("{0} {1}", Prenom, Nom);
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
		public decimal ComissionTotale
		{
			get
			{
				decimal total = 0;
				foreach (Vente v in Ventes)
				{
					total += v.ComissionAgent;
				}
				return total;
			}
			set { }
		}
	}
}
