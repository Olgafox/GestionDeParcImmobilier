using GalaSoft.MvvmLight.CommandWpf;
using GPI.Persistence.EntityRepositories;
using GPI.Presentation.Mvvm;
using GPI.Presentation.Reporting;
using GPI.Presentation.Reporting.VenteReporting;
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
	public class VenteViewModel : ViewModelBase, ICrud
	{
		private RelayCommand<String> _search;
		private ObservableCollection<Offre> _listeOffres;
		private ObservableCollection<Vente> _listeVentes;
		private Vente _currentVente;
		private ObservableCollection<Client> _listeClients;
		private ObservableCollection<Agent> _listeAgents;
		private Offre _selectedOffre;
		private Client _selectedAcheteur;
		private Agent _selectedAgent;

		#region Propriétes
		public Vente CurrentVente
		{
			get { return _currentVente; }
			set { _currentVente = value; FirePropertyChanged("CurrentVente"); }
		}
		
		public Client SelectedAcheteur
		{
			get { return _selectedAcheteur; }
			set
			{
				_selectedAcheteur = value;
				CurrentVente.Client = SelectedAcheteur;
				FirePropertyChanged("CurrentOffre.Client");
				FirePropertyChanged();
			}
		}
		public Agent SelectedAgent
		{
			get { return _selectedAgent; }
			set
			{
				_selectedAgent = value;
				CurrentVente.Agent = SelectedAgent;
				FirePropertyChanged("CurrentOffre.Agent");
				FirePropertyChanged();
			}
		}
		public DateTime Date_de
		{
			get; set;
		}
		public DateTime Date_a
		{
			get; set;
		}
		public Offre SelectedOffre
		{
			get { return _selectedOffre; }
			set { _selectedOffre = value;
				CurrentVente.Offre = SelectedOffre;
				FirePropertyChanged("CurrentVente.Offre");
				base.FirePropertyChanged(); }
		}
		public ObservableCollection<Offre> ListeOffres
		{
			get { return _listeOffres; }
			set { _listeOffres = value; base.FirePropertyChanged(); }
		}
		public ObservableCollection<Agent> ListeAgents
		{
			get { return _listeAgents; }
			set { _listeAgents = value; base.FirePropertyChanged(); }
		}
		public ObservableCollection<Vente> ListeVentes
		{
			get { return _listeVentes; }
			set { _listeVentes = value; base.FirePropertyChanged(); }
		}
		public ObservableCollection<Client> ListeClients
		{
			get { return _listeClients; }
			set { _listeClients = value; base.FirePropertyChanged(); }
		}
		#endregion
		#region Commands
		public RelayCommand NewVenteSaveCommand
		{
			get; set;
		}
		public RelayCommand ChercherParDate
		{
			get; set;
		}
		public RelayCommand NewVenteCommand
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
		public RelayCommand InfoCommand
		{
			get; set;
		}
		public RelayCommand ImprimerCommand
		{
			get; set;
		}
		public RelayCommand<string> ChercherVenteCommand
		{
			get { return _search; }
			set { _search = value; }
		}
		#endregion
		public VenteViewModel()
		{
			Load();
			LoadCommandes();
			ListeClients = new ObservableCollection<Client>(_ctx.Clients.OrderBy(c => c.Nom).Where(c => c.Actif == 1));
			ListeAgents = new ObservableCollection<Agent>(_ctx.Agents.OrderBy(a => a.Nom).Where(a => a.Actif == 1));
			ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.OrderBy(o => o.TypeImmobilier.TypeNom).Where(o=> o.Actuel==1));
			Date_de = DateTime.Parse("1.1.2015");
			Date_a = DateTime.Parse("1.1.2016");
		}
		public VenteViewModel(Region r)
		{
			ListeVentes = new ObservableCollection<Vente>(_ctx.Ventes.Where(v => v.Offre.RegionId == r.Id));
			
			LoadCommandes();
			Date_de = DateTime.Parse("1.1.2015");
			Date_a = DateTime.Parse("1.1.2016");
		}
		public VenteViewModel(TypeImmobilier t)
		{
			ListeVentes = new ObservableCollection<Vente>();
			foreach (Vente v in _ctx.Ventes)
			{
				if (v.Offre.TypeId == t.Id)
					ListeVentes.Add(v);
			}
			LoadCommandes();
			Date_de = DateTime.Parse("1.1.2015");
			Date_a = DateTime.Parse("1.1.2016");
		}
		public VenteViewModel(Vente v)
		{
			this.CurrentVente = v;
			ImprimerCommand = new RelayCommand(Print);
		}
		public VenteViewModel(Offre o)
		{
			foreach (Vente v in o.Ventes)
			{
					CurrentVente = v;
			}
			ImprimerCommand = new RelayCommand(Print);
		}
		#region Méthodes
		private void GetVenteList(string str)
		{
			if (str != "")
				ListeVentes = new ObservableCollection<Vente>(_ctx.Ventes.Where(v => v.Agent.Nom.Contains(str.ToLower()) || v.Client.Nom.Contains(str.ToLower())));
			else
				Load();
		}
		private void GetVenteListParDate()
		{

			ListeVentes = new ObservableCollection<Vente>(_ctx.Ventes.Where(v => v.DateVente <= Date_a && v.DateVente >= Date_de));
		}

		private void LoadCommandes()
		{
			ChercherVenteCommand = new RelayCommand<string>(GetVenteList);
			SauverCommand = new RelayCommand(OnSave);
			SupprimerCommand = new RelayCommand(OnDelete);
			NewVenteSaveCommand = new RelayCommand(SaveNewVente);
			NewVenteCommand = new RelayCommand(GetNew);
			ImprimerCommand = new RelayCommand(Print);
			InfoCommand = new RelayCommand(GetInfoWindow);
			ChercherParDate = new RelayCommand(GetVenteListParDate);

		}
		private void Load()
		{
			ListeVentes = new ObservableCollection<Vente>(_ctx.Ventes);
			if (CurrentVente == null)
				CurrentVente = new Vente();
			
		}
		public void OnDelete()
		{
			MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette vente?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					CurrentVente.Offre.Actuel = 1;
					_ctx.Ventes.Remove(CurrentVente);
					_ctx.SaveChanges();

				}
				catch (Exception)
				{
					MessageBox.Show("Impossible de supprimer!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			FirePropertyChanged("ListeVentes");
			Load();
		}
		private void SaveNewVente()
		{
			try
			{
				if (CurrentVente.Id == 0)
				{

					_ctx.Ventes.Add(CurrentVente);

				}
				try
				{
					SelectedOffre.Actuel = 0;
					FirePropertyChanged("SelectedOffre");
					_ctx.SaveChanges();
					MessageBox.Show("La nouvelle vente a été enregistrée");

				}
				catch (Exception)
				{
					MessageBox.Show("Erreur lors de l'enregistrement de la vente ", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}

				FirePropertyChanged("CurrentVente");
				FirePropertyChanged("ListeVentes");
				Load();
			}
			catch (Exception)
			{
				MessageBox.Show("Erreur lors de l'enregistrement de la vente ", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}
		public void OnSave()
		{
			try
			{
	
					_ctx.SaveChanges();
					MessageBox.Show("La vente a été enregistrée");
				
			}
			catch (Exception)
			{
				MessageBox.Show("Erreur lors de l'enregistrement de la vente ", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			FirePropertyChanged("CurrentVente");
			FirePropertyChanged("ListeVentes");
			Load();
		}
		public void GetNew()
		{
			CurrentVente = new Vente();
			CurrentVente.DateVente = DateTime.Now;
			if(SelectedOffre != null)
				SelectedOffre = new Offre();
			ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.OrderBy(o => o.TypeImmobilier.TypeNom).Where(o => o.Actuel == 1));
			ListeClients = new ObservableCollection<Client>(_ctx.Clients.OrderBy(c => c.Nom).Where(c => c.Actif == 1));
			ListeAgents = new ObservableCollection<Agent>(_ctx.Agents.OrderBy(a => a.Nom).Where(a => a.Actif == 1));
			NewVenteWindow win = new NewVenteWindow();
			win.DataContext = this;
			win.Owner = Application.Current.MainWindow;
			win.ShowDialog();
		}
		public void Print()
		{
			try
			{
				ReportedVente reportedVente = new ReportedVente(CurrentVente.DateVenteFormated, 
					CurrentVente.Agent.PrenomNom, CurrentVente.Client.PrenomNom, 
					CurrentVente.Offre.Client.PrenomNom, CurrentVente.ComissionAgence,
					CurrentVente.ComissionAgent);
				ReportingOffre ro = new ReportingOffre(CurrentVente.Offre.NomOffre, CurrentVente.Offre.Adresse,
					CurrentVente.Offre.Prix, CurrentVente.Offre.Surface);
				reportedVente.reportingOffre = ro;
				VenteForm report = new VenteForm(new VenteReport(reportedVente));

				report.ShowDialog();
			}
			catch (Exception)
			{
				MessageBox.Show("D'abord choisissez une Vente", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void GetInfoWindow()
		{
			try
			{
				if (CurrentVente.Client != null && CurrentVente.Agent != null && CurrentVente.Offre.Client != null)
				{
					InfoWindow win = new InfoWindow(CurrentVente.Client, CurrentVente.Agent, CurrentVente.Offre.Client);
					win.Owner = Application.Current.MainWindow;
					win.ShowDialog();

				}
				else
					MessageBox.Show("D'abord choisissez une Vente", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch
			{
				MessageBox.Show("D'abord choisissez une Vente", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}
		#endregion
	}
}
