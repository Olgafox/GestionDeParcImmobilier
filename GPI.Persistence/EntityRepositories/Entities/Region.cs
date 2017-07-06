using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Persistence.EntityRepositories
{
	public partial class Region
	{
		public override string ToString()
		{
			return string.Format("{0}", NomRegion);
		}

		/*public string RegionDisplayNom
		{
			get
			{
				return NomRegion;
			}
			set
			{

			}
		}*/
	}
}
