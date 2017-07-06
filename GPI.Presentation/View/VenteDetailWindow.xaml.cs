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
	/// Logique d'interaction pour VenteDetailWindow.xaml
	/// </summary>
	public partial class VenteDetailWindow : Window
	{
		public VenteDetailWindow()
		{
			InitializeComponent();
			
		}
		public VenteDetailWindow(Vente v)
		{
			InitializeComponent();
			DataContext = new VenteViewModel(v);
		}
		public VenteDetailWindow(Offre o)
		{
			InitializeComponent();
			DataContext = new VenteViewModel(o);
		}
		private void Annuler_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
