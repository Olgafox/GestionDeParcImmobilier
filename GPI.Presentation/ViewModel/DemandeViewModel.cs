using GalaSoft.MvvmLight.CommandWpf;
using GPI.Persistence.EntityRepositories;
using GPI.Presentation.Mvvm;
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
	public class DemandeViewModel : ViewModelBase, ICrud
	{
		private ObservableCollection<Demande> _listeDemandes;
		private ObservableCollection<Offre> _listeOffres;
		private Region _selectedRegion;
		private TypeImmobilier _selectedType;
		private ObservableCollection<Client> _listeClients;
		private Client _selectedClient;
		private ObservableCollection<Region> _listeRegions;
		private ObservableCollection<TypeImmobilier> _typesImmobilier;
		private RelayCommand<String> _search;
		private ObservableCollection<Offre> _rechercheListe;


		private Demande _currentDemande;

		#region Propriétés
		public Demande CurrentDemande
		{
			get { return _currentDemande; }
			set
			{
				_currentDemande = value; FirePropertyChanged();

			}
		}
		public ObservableCollection<Demande> ListeDemandes
		{
			get { return _listeDemandes; }
			set { _listeDemandes = value; base.FirePropertyChanged(); }

		}
		public ObservableCollection<Offre> RechercheListe
		{
			get { return _rechercheListe; }
			set { _rechercheListe = value; base.FirePropertyChanged(); }
		}
		public ObservableCollection<Offre> ListeOffres
		{
			get { return _listeOffres; }
			set { _listeOffres = value; base.FirePropertyChanged(); }
		}

		public ObservableCollection<Region> ListeRegions
		{
			get { return _listeRegions; }
			set
			{
				_listeRegions = value; base.FirePropertyChanged();
			}
		}

		public ObservableCollection<Client> ListeClients
		{
			get { return _listeClients; }
			set { _listeClients = value; base.FirePropertyChanged(); }
		}
		public Client SelectedClient
		{
			get { return _selectedClient; }
			set
			{
				_selectedClient = value;
				CurrentDemande.Client = SelectedClient;
				FirePropertyChanged("CurrentDemande.Client");
				FirePropertyChanged();
			}
		}
		public ObservableCollection<TypeImmobilier> TypesImmobilier
		{
			get { return _typesImmobilier; }
			set { _typesImmobilier = value; base.FirePropertyChanged(); }
		}
		public Region SelectedRegion
		{
			get { return _selectedRegion; }
			set
			{
				_selectedRegion = value;
				CurrentDemande.Region = SelectedRegion;
				FirePropertyChanged("CurrentDemande.Region");
				FirePropertyChanged();
			}
		}
		public TypeImmobilier SelectedType
		{
			get { return _selectedType; }
			set
			{
				_selectedType = value;
				CurrentDemande.TypeImmobilier = SelectedType;
				FirePropertyChanged("CurrentDemande.TypeImmobilier");
				FirePropertyChanged();
			}
		}
		#endregion
		#region Commandes
		public RelayCommand NewDemandeSaveCommand
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
		public RelayCommand NewDemandeCommand
		{
			get; set;
		}
		public RelayCommand ChercherCommand
		{
			get; set;
		}
		public RelayCommand<string> ChercherDemandeCommand
		{
			get { return _search; }
			set { _search = value; }
		}
		#endregion
		public DemandeViewModel()
		{
			Load();
			SupprimerCommand = new RelayCommand(OnDelete);
			ChercherDemandeCommand = new RelayCommand<string>(GetDemandeList);
			SauverCommand = new RelayCommand(OnSave);
			NewDemandeSaveCommand = new RelayCommand(OnSave);
			NewDemandeCommand = new RelayCommand(GetNew);
			ChercherCommand = new RelayCommand(GetRechercheListe);
			ListeClients = new ObservableCollection<Client>(_ctx.Clients.Where(c => c.Actif == 1));
			ListeRegions = new ObservableCollection<Region>(_ctx.Regions.OrderBy(r => r.NomRegion));
			TypesImmobilier = new ObservableCollection<TypeImmobilier>(_ctx.TypeImmobiliers);
			RechercheListe = new ObservableCollection<Offre>();
		}
		public DemandeViewModel(Client c)
		{
			ListeDemandes = new ObservableCollection<Demande>(c.Demandes);
			InitConstr();
		}
		public DemandeViewModel(ObservableCollection<Demande> d)
		{
			ListeDemandes = d;
			InitConstr();
		}
		public DemandeViewModel(Region r)
		{
			ListeDemandes = new ObservableCollection<Demande>(r.Demandes);
			InitConstr();
		}
		public DemandeViewModel(TypeImmobilier t)
		{
			ListeDemandes = new ObservableCollection<Demande>(t.Demandes);
			InitConstr();
		}
		#region Méthodes
		private void Load()
		{
			ListeDemandes = new ObservableCollection<Demande>(_ctx.Demandes.OrderBy(d => d.Client.Nom));
			ListeOffres = new ObservableCollection<Offre>(_ctx.Offres);
			if (CurrentDemande == null)
				CurrentDemande = new Demande();
		}
		private void InitConstr()
		{
			SupprimerCommand = new RelayCommand(OnDelete);
			SauverCommand = new RelayCommand(OnSave);
			ChercherCommand = new RelayCommand(GetRechercheListe);
			ListeRegions = new ObservableCollection<Region>(_ctx.Regions.OrderBy(r => r.NomRegion));
			TypesImmobilier = new ObservableCollection<TypeImmobilier>(_ctx.TypeImmobiliers);
		}
		public void GetNew()
		{
			CurrentDemande = new Demande();
		}
		public void OnDelete()
		{
			MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette démande?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					_ctx.Demandes.Remove(CurrentDemande);
					_ctx.SaveChanges();

				}
				catch (Exception)
				{
					MessageBox.Show("Impossible de supprimer!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			FirePropertyChanged("CurrentDemande");
			Load();

		}
		public void OnSave()
		{
			try
			{
				if (CurrentDemande.Id == 0)
				{
					_ctx.Demandes.Add(CurrentDemande);
				}
				try
				{
					_ctx.SaveChanges();
					MessageBox.Show("La démande a été enregistrée");

				}
				catch (Exception)
				{
					MessageBox.Show("Erreur lors de l'enregistrement de la démande ", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}

				FirePropertyChanged("CurrentDemande");
				FirePropertyChanged("ListeDemandes");
				Load();
			}
			catch (Exception)
			{

				MessageBox.Show("D'abord choisissez une demandes", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}

		public void GetRechercheListe()
		{
			try
			{
				if (CurrentDemande.Id != 0)
				{
					RechercheListe = new ObservableCollection<Offre>(_ctx.Offres.Where
						(o => ((CurrentDemande.Prix_de == null ? o.Prix > 0 : o.Prix >= CurrentDemande.Prix_de) && (CurrentDemande.Prix_a == null ? o.Prix > 0 : o.Prix <= CurrentDemande.Prix_a)) &&
						 (CurrentDemande.RegionId == null ? o.RegionId > 0 : o.RegionId == CurrentDemande.RegionId) &&
						 (CurrentDemande.TypeId == null ? o.TypeId > 0 : o.TypeId == CurrentDemande.TypeId) &&
						((CurrentDemande.Etage_de == null ? o.Etage >= 0 : o.Etage >= CurrentDemande.Etage_de) && (CurrentDemande.Etage_a == null ? o.Etage >= 0 : o.Etage <= CurrentDemande.Etage_a)) &&
						((CurrentDemande.NombreEtages_de == null ? o.Nombre_Etages >= 0 : o.Nombre_Etages >= CurrentDemande.NombreEtages_de) && CurrentDemande.NombreEtages_a == null ? o.Nombre_Etages >= 0 : o.Nombre_Etages <= CurrentDemande.NombreEtages_a) &&
						((CurrentDemande.Surface_de == null ? o.Surface > 0 : o.Surface >= CurrentDemande.Surface_de) && CurrentDemande.Surface_a == null ? o.Surface > 0 : o.Surface <= CurrentDemande.Surface_a) &&
						((CurrentDemande.Pieces_de == null ? o.Pieces > 0 : o.Pieces >= CurrentDemande.Pieces_de) && (CurrentDemande.Pieces_a == null ? o.Pieces > 0 : o.Pieces <= CurrentDemande.Pieces_a && o.Actuel == 1))));

					var vm = new ChercherOffreViewModel(RechercheListe);
					ChercherOffreWindow win = new ChercherOffreWindow(RechercheListe);
					win.DataContext = vm;
					win.Owner = Application.Current.MainWindow;
					win.ShowDialog();
				}
				else
					MessageBox.Show("D'abord choisissez une demande", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			catch
			{
				MessageBox.Show("D'abord choisissez une demande", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void GetDemandeList(string str)
		{
			if (str != "")
				ListeDemandes = new ObservableCollection<Demande>(_ctx.Demandes.Where(d => d.Client.Nom.Contains(str.ToLower())));
			else
				Load();
		}
		public void Print()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}

