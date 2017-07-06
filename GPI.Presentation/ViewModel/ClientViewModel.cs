using GalaSoft.MvvmLight.CommandWpf;
using GPI.Persistence.EntityRepositories;
using GPI.Presentation.Mvvm;
using GPI.Presentation.Reporting;
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
	public class ClientViewModel : ViewModelBase, ICrud
	{
		private ObservableCollection<Client> _listeClients;

		private RelayCommand<String> _search;
		private Client _currentClient;
		private Vente _selectedVente;
		private Offre _selectedOffre;
		public ObservableCollection<Client> ListeClients
		{
			get { return _listeClients; }
			set { _listeClients = value; base.FirePropertyChanged(); }
		}
		public Client CurrentClient
		{
			get { return _currentClient; }
			set
			{
				_currentClient = value;
					FirePropertyChanged();
			}
		}
		public Offre SelectedOffre
		{
			get { return _selectedOffre; }
			set { _selectedOffre = value; FirePropertyChanged(); }
		}
		public Vente SelectedVente
		{
			get { return _selectedVente; }
			set { _selectedVente = value; FirePropertyChanged(); }
		}
		#region Commands
		public RelayCommand NewClientCommand
		{
			get; set;
		}
		public RelayCommand VoirListeOffres
		{
			get; set;
		}
		public RelayCommand VoirListeDemandes
		{
			get; set;
		}

		public RelayCommand SauverCommand
		{
			get; set;
		}
		public RelayCommand SupprimerCommand
		{
			get; set;
		}
		public RelayCommand ImprimerCommand
		{
			get; set;
		}
		public RelayCommand<string> ChercherClientCommand
		{
			get { return _search; }
			set { _search = value; }
		}
		public RelayCommand MouseDoubleClickCommand
		{
			get { return new RelayCommand(GetVenteDetailWindow); }
		}
		public RelayCommand VentesMouseDoubleClickCommand
		{
			get { return new RelayCommand(GetListeVentesDetailWindow); }
		}
		#endregion
		public ClientViewModel()
		{
			Load();
			ChercherClientCommand = new RelayCommand<string>(GetClientList);
			SauverCommand = new RelayCommand(OnSave);
			SupprimerCommand = new RelayCommand(OnDelete);
			NewClientCommand = new RelayCommand(GetNew);
			ImprimerCommand = new RelayCommand(Print);
			VoirListeOffres = new RelayCommand(GetListeOffresWindow);
			VoirListeDemandes = new RelayCommand(GetListeDemandesWindow);
		}
		public ClientViewModel(Client c)
		{
			CurrentClient = c;
			SauverCommand = new RelayCommand(OnSave);
			ImprimerCommand = new RelayCommand(Print);
			VoirListeOffres = new RelayCommand(GetListeOffresWindow);
			VoirListeDemandes = new RelayCommand(GetListeDemandesWindow);
		}

		#region Méthodes
		private void Load()
		{
			ListeClients = new ObservableCollection<Client>(_ctx.Clients.Where(c => c.Actif ==1));
			if (CurrentClient == null)
				CurrentClient = new Client();
		}
		private void GetClientList(string str)
		{
			if (str != "")
				ListeClients = new ObservableCollection<Client>(_ctx.Clients.Where(v => (v.Nom.Contains(str.ToLower()) || v.Prenom.Contains(str.ToLower()) && v.Actif == 1)));
			else
				Load();
		}
		public void OnDelete()
		{
			System.Windows.MessageBoxResult result = MessageBox.Show("Le demandes du Client seront supprimées. \n Voulez-vous supprimer ce Client?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					CurrentClient.Actif = 0;
					foreach (Demande d in _ctx.Demandes)
					{
						if (d.ClientId == CurrentClient.Id)
						{ _ctx.Demandes.Remove(d); } 
					}
					_ctx.SaveChanges();
				}
				catch (Exception)
				{
					MessageBox.Show("Impossible de supprimer!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			FirePropertyChanged("ListeClients");
			FirePropertyChanged("ListeDemandes");
			Load();
		}

		public void OnSave()
		{
			if (CurrentClient.Id == 0)
			{
				CurrentClient.Actif = 1;
				_ctx.Clients.Add(CurrentClient);
			}
				
			try
			{
				_ctx.SaveChanges();

				MessageBox.Show("Les changements ont été enregistrés");

			}
			catch (Exception)
			{
				MessageBox.Show("Erreur lors de l'enregistrement", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			FirePropertyChanged("CurrentClient");
			FirePropertyChanged("ListeClients");
			Load();
		}
		public void Print()
		{
			if(CurrentClient.Id != 0 && CurrentClient != null)
			{
				ReportedClient reportedClient = new ReportedClient(CurrentClient.PrenomNom, CurrentClient.Adresse, CurrentClient.Telephone);
				
				reportedClient.ReportedVentesListe = new List<VenteAcheteurReport>();
				reportedClient.ReportedVentesVendeurListe = new List<VenteVendeurReport>();
				reportedClient.ReportedOffres = new List<OffreReport>();

				foreach (Offre v in CurrentClient.ListeVentes)
				{
					VenteClient va = new VenteClient(v.DateVenteFormated, v.NomOffre, v.Surface, v.Prix, v.Adresse, v.Region.NomRegion);
					VenteVendeurReport vr = new VenteVendeurReport(va);
					reportedClient.ReportedVentesVendeurListe.Add(vr);
				}
				foreach (Vente v in CurrentClient.Ventes)
				{
					VenteClient va = new VenteClient(v.DateVenteFormated, v.Offre.NomOffre, v.Offre.Surface, v.Offre.Prix, v.Offre.Adresse, v.Offre.Region.NomRegion);
					VenteAcheteurReport vr = new VenteAcheteurReport(va);
					reportedClient.ReportedVentesListe.Add(vr);
				}
				foreach (Offre o in CurrentClient.Offres)
				{
					ReportingOffre reportedOffre = new ReportingOffre(o.NomOffre, o.Adresse, o.Prix, o.Surface, o.IsActuel, o.Etage, o.Nombre_Etages);
					OffreReport or = new OffreReport(reportedOffre);
					reportedClient.ReportedOffres.Add(or);
				}
				ClientForm report = new ClientForm(new ClientReport(reportedClient));
				report.ShowDialog();
			}
			else
			{
				MessageBox.Show("D'abord choisissez un Client", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		public void GetListeOffresWindow()
		{
			if (CurrentClient.Id != 0 && CurrentClient != null)
			{
				ListeOffresWindow win = new ListeOffresWindow(CurrentClient);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez un Client", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		public void GetListeDemandesWindow()
		{
			if (CurrentClient.Id != 0 && CurrentClient != null)
			{
				ListeDemandesWindow win = new ListeDemandesWindow(CurrentClient);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez un Client", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void GetVenteDetailWindow()
		{
			if (CurrentClient.Id != 0 && CurrentClient != null)
			{
				VenteDetailWindow win = new VenteDetailWindow(SelectedVente);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez un Client", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void GetListeVentesDetailWindow()
		{
			if (CurrentClient.Id != 0 && CurrentClient != null)
			{
				Offre o = SelectedOffre;
				VenteDetailWindow win = new VenteDetailWindow(o);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez un Client", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		
		public void GetNew()
		{
			CurrentClient = new Client();
		}
		#endregion
	}
}
