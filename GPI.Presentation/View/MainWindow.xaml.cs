using GPI.Presentation.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPI.Presentation
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		OffreUserControl ouc;
		DemandeUserControl duc;
		VenteUserControl vuc;
		AgentUserControl auc;
		ClientUserControl cuc;
		RegionTypeUserControl rtc;
		public MainWindow()
		{
			InitializeComponent();
			
		}
		private void MainMenu_Click(object sender, RoutedEventArgs e)
		{
			MenuItem mi = (MenuItem)sender;
			switch (mi.Name)
			{
				case "MenuOffre":
					{
						//if (ouc == null)
							ouc = new OffreUserControl();
						MenuOffre.IsChecked = true;
						MenuDemande.IsChecked = false;
						MenuVente.IsChecked = false;
						MenuAgent.IsChecked = false;
						MenuClient.IsChecked = false;
						MenuRegionType.IsChecked = false;
						MainStackPanel.Children.Clear();
						MainStackPanel.Children.Add(ouc);
						break;
					}
				case "MenuDemande":
					{
						//if(duc == null)
							duc = new DemandeUserControl();
						MenuOffre.IsChecked = false;
						MenuDemande.IsChecked = true;
						MenuVente.IsChecked = false;
						MenuAgent.IsChecked = false;
						MenuClient.IsChecked = false;
						MenuRegionType.IsChecked = false;
						MainStackPanel.Children.Clear();
						MainStackPanel.Children.Add(duc);
						break;
					}
				case "MenuVente":
					{
						//if (vuc == null)
							vuc = new VenteUserControl();
						MenuOffre.IsChecked = false;
						MenuDemande.IsChecked = false;
						MenuVente.IsChecked = true;
						MenuAgent.IsChecked = false;
						MenuRegionType.IsChecked = false;
						MenuClient.IsChecked = false;
						MainStackPanel.Children.Clear();
						MainStackPanel.Children.Add(vuc);
						break;
					}
				case "MenuAgent":
					{
						//if(auc == null)
							auc = new AgentUserControl();
						MenuOffre.IsChecked = false;
						MenuDemande.IsChecked = false;
						MenuVente.IsChecked = false;
						MenuAgent.IsChecked = true;
						MenuClient.IsChecked = false;
						MenuRegionType.IsChecked = false;
						MainStackPanel.Children.Clear();
						MainStackPanel.Children.Add(auc);
						break;
					}
				case "MenuClient":
					{
						//if(cuc == null)
							cuc = new ClientUserControl();
						MenuOffre.IsChecked = false;
						MenuDemande.IsChecked = false;
						MenuVente.IsChecked = false;
						MenuAgent.IsChecked = false;
						MenuClient.IsChecked = true;
						MenuRegionType.IsChecked = false;
						MainStackPanel.Children.Clear();
						MainStackPanel.Children.Add(cuc);
						break;
					}
				case "MenuRegionType":
					{
						//if (rtc == null)
							rtc = new RegionTypeUserControl();
						MenuOffre.IsChecked = false;
						MenuDemande.IsChecked = false;
						MenuVente.IsChecked = false;
						MenuAgent.IsChecked = false;
						MenuClient.IsChecked = false;
						MenuRegionType.IsChecked = true;
						MainStackPanel.Children.Clear();
						MainStackPanel.Children.Add(rtc);
						break;
					}
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show(this, "Voulez vous quitter?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.No)
			{
				e.Cancel = true;
			}
		}
	}
}
