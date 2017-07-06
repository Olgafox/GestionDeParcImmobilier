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
	/// Logique d'interaction pour ListeDemandesWindow.xaml
	/// </summary>
	public partial class ListeDemandesWindow : Window
	{
		public ListeDemandesWindow()
		{
			InitializeComponent();
		}
		public ListeDemandesWindow(Client c) : this()
		{
			DataContext = new DemandeViewModel(c);
		}
		public ListeDemandesWindow(ObservableCollection<Demande> d) :this()
		{
			DataContext = new DemandeViewModel(d);
		}
		public ListeDemandesWindow(Region r) : this()
		{
			DataContext = new DemandeViewModel(r);
		}
		public ListeDemandesWindow(TypeImmobilier t) : this()
		{
			DataContext = new DemandeViewModel(t);
		}
	}
}
