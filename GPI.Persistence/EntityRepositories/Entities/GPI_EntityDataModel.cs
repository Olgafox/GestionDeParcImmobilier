using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Persistence.EntityRepositories
{
	public partial class GPI_EntityDataModel
	{
		private static GPI_EntityDataModel _ctx;
		public static GPI_EntityDataModel GetEntityContext()
		{
			if (_ctx == null)
				_ctx = new GPI_EntityDataModel();

			return _ctx;
		}
	}
}
