using GPI.Persistence.EntityRepositories;
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
	/// Logique d'interaction pour InfoWindow.xaml
	/// </summary>
	public partial class InfoWindow : Window
	{
		ClientInfoUserControl ciuc;
		ClientInfoUserControl ciucVendeur;
		AgentInfoUserControl aiuc;
		public InfoWindow()
		{
			InitializeComponent();
		}
		public InfoWindow(Client c, Agent a, Client cVendeur):this()
		{
			ciuc = new ClientInfoUserControl(c);
			ciucVendeur = new ClientInfoUserControl(cVendeur);
			aiuc = new AgentInfoUserControl(a);
		}

		private void Client_Click(object sender, RoutedEventArgs e)
		{
			
			AchteurMenuItem.IsChecked = true;
			AgentMenuItem.IsChecked = false;
			VendeurMenuItem.IsChecked = false;
			InfoStackPanel.Children.Clear();
			InfoStackPanel.Children.Add(ciuc);
		}

		private void Vendeur_Click(object sender, RoutedEventArgs e)
		{
			AchteurMenuItem.IsChecked = false;
			AgentMenuItem.IsChecked = false;
			VendeurMenuItem.IsChecked = true;
			InfoStackPanel.Children.Clear();
			InfoStackPanel.Children.Add(ciucVendeur);
		}

		private void Agent_Click(object sender, RoutedEventArgs e)
		{

			AchteurMenuItem.IsChecked = false;
			AgentMenuItem.IsChecked = true;
			VendeurMenuItem.IsChecked = false;
			
			InfoStackPanel.Children.Clear();
			InfoStackPanel.Children.Add(aiuc);
		}
	}
}
