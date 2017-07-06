using GPI.Persistence.EntityRepositories;
using GPI.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GPI.Presentation.View
{
	/// <summary>
	/// Logique d'interaction pour ListeOffresWindow.xaml
	/// </summary>
	public partial class ListeOffresWindow : Window
	{
		public ListeOffresWindow(Client c)
		{
			InitializeComponent();
			DataContext = new OffreViewModel(c);
		}
		public ListeOffresWindow(Region r)
		{
			InitializeComponent();
			DataContext = new OffreViewModel(r);
		}
		public ListeOffresWindow(TypeImmobilier t)
		{
			InitializeComponent();
			DataContext = new OffreViewModel(t);
		}
	}
}
