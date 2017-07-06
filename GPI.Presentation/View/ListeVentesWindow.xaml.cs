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
	/// Logique d'interaction pour ListeVentesWindow.xaml
	/// </summary>
	public partial class ListeVentesWindow : Window
	{
		public ListeVentesWindow()
		{
			InitializeComponent();
			
		}
		public ListeVentesWindow(Region r) : this()
		{
			
			DataContext = new VenteViewModel(r);
		}
		public ListeVentesWindow(TypeImmobilier t) : this()
		{
			
			DataContext = new VenteViewModel(t);
		}
	}
}
