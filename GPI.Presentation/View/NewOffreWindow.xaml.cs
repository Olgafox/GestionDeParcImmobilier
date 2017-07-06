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
	/// Logique d'interaction pour Window1.xaml
	/// </summary>
	public partial class NewOffreWindow : Window
	{
		public NewOffreWindow()
		{
			InitializeComponent();
		}

		private void Annuler_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
