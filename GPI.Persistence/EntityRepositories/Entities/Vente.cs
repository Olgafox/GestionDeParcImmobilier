using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Persistence.EntityRepositories
{
	public partial class Vente
	{
		
		private string _dateVenteFormated;
		public string NomVente
		{
			get { return string.Format("{0} / {1}", Client.Nom, Offre.Client.Nom); }
			set { }
		}


		public override string ToString()
		{
			return string.Format("{0} / {1}", Client.Nom, Offre.Client.Nom);
		}
		private decimal OffrePrix
		{
			get {
				if (Offre == null)
					return 0;
				else
					return Offre.Prix;
			}
			set { }
		}
		public decimal ComissionAgence
		{
			get
			{
				 return OffrePrix * TauxCommission / 100;
			}
			set{}
		}
		public decimal ComissionAgent
		{
			get { return ComissionAgence * TauxCommissionAgent / 100; }
			set { }
		}
		public string DateVenteFormated
		{
			get
			{
				return DateVente.ToString("dd.MM.yyyy");
			}
			set { _dateVenteFormated = value; }
		}
	}
}
