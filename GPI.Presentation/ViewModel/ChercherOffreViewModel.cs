using GalaSoft.MvvmLight.CommandWpf;
using GPI.Persistence.EntityRepositories;
using GPI.Presentation.Mvvm;
using GPI.Presentation.Reporting;
using GPI.Presentation.Reporting.RechercheReporting;
using GPI.Presentation.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GPI.Presentation.ViewModel
{
	public class ChercherOffreViewModel : ViewModelBase
	{
		private ObservableCollection<Offre> _rechercheListe;
		private Demande _currentDemande;
		private Offre _currentOffre;
		public Offre CurrentOffre
		{
			get { return _currentOffre; }
			set
			{
				_currentOffre = value; FirePropertyChanged();

			}
		}
		public Demande CurrentDemande
		{
			get { return _currentDemande; }
			set
			{
				_currentDemande = value; FirePropertyChanged();

			}
		}
		public RelayCommand ImprimerCommand
		{
			get; set;
		}
		public RelayCommand InfoCommand
		{
			get; set;
		}
		public ObservableCollection<Offre> RechercheListe
		{
			get { return _rechercheListe; }
			set { _rechercheListe = value; base.FirePropertyChanged(); }
		}
		public ChercherOffreViewModel(ObservableCollection<Offre> list)
		{
			ImprimerCommand = new RelayCommand(Print);
			InfoCommand = new RelayCommand(GetClientInfoWindow);
			RechercheListe = list;
		}

		public void Print()
		{
			if(RechercheListe.Count > 0)
			{
				List<ReportingOffre> list = new List<ReportingOffre>();
				foreach (Offre o in RechercheListe)
				{
					list.Add(new ReportingOffre(o.TypeImmobilier.TypeNom, o.Region.NomRegion,
						o.Adresse,
						o.Nombre_Etages, o.Etage, o.Pieces,
						o.Surface, o.Prix,
						o.Client.PrenomNom, o.IsActuel, o.NomOffre));
				}
				RechercheForm report = new RechercheForm(new RechercheResult(list));
				report.ShowDialog();
			}
			else
			{
				MessageBox.Show("Il n'y a rien à afficher", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}
		public void GetClientInfoWindow()
		{
			try
			{
				ClientInfoWindow win = new ClientInfoWindow(CurrentOffre.Client);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			catch
			{
				MessageBox.Show("D'abord choisissez une offre", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

	}
}
