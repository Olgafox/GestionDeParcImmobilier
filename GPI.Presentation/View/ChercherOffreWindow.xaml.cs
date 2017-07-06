using GPI.Persistence.EntityRepositories;
using GPI.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
	/// Logique d'interaction pour ChercherOffreWindow.xaml
	/// </summary>
	public partial class ChercherOffreWindow : Window
	{
		public ChercherOffreWindow(ObservableCollection<Offre> list)
		{
			InitializeComponent();
			DataContext = new ChercherOffreViewModel(list);
		}

		private void Annuler_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
