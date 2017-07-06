using GalaSoft.MvvmLight.CommandWpf;
using GPI.Persistence.EntityRepositories;
using GPI.Presentation.Mvvm;
using GPI.Presentation.Reporting;
using GPI.Presentation.Reporting.OffreReporting;
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
	public class OffreViewModel : ViewModelBase, ICrud
	{
		private ObservableCollection<Region> _listeRegions;
		private ObservableCollection<Offre> _listeOffres;
		private ObservableCollection<TypeImmobilier> _typesImmobilier;
		private ObservableCollection<Client> _listeVendeur;
		private ObservableCollection<Demande> _listeDemandes;

		private Client _selectedVendeur;
		private TypeImmobilier _selectedType;
		private Region _selectedRegion;
		private Region _currentRegion;
		private TypeImmobilier _currentType;
		private Offre _currentOffre;

		#region Propriétés
		public Offre CurrentOffre {
			get { return _currentOffre; }
			set { _currentOffre = value; FirePropertyChanged();
				
			}
		}
		public ObservableCollection<Region> ListeRegions
		{
			get { return _listeRegions; }
			set {
				_listeRegions = value;  base.FirePropertyChanged();
			}
		}
		public ObservableCollection<Offre> ListeOffres
		{
			get { return _listeOffres; }
			set { _listeOffres = value; base.FirePropertyChanged(); }
		}
		public ObservableCollection<TypeImmobilier> TypesImmobilier
		{
			get { return _typesImmobilier; }
			set { _typesImmobilier = value; base.FirePropertyChanged(); }
		}
		public ObservableCollection<Demande> ListeDemandes
		{
			get { return _listeDemandes; }
			set { _listeDemandes = value; base.FirePropertyChanged(); }
		}
		/// <summary>
		/// Initialize la collection Offres par rapport au choix de la région
		/// </summary>
		public Region CurrentRegion
		{
			get { return _currentRegion; }
			set {
				_currentRegion = value; 
				if (CurrentType == null)
				{
					ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.Where(o => o.Region.Id == CurrentRegion.Id));
				}
				else
				{
					ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.Where(o => o.Region.Id == CurrentRegion.Id && o.TypeImmobilier.Id == CurrentType.Id));
				}

				FirePropertyChanged("Offres");
				FirePropertyChanged();
			}
		}
		public ObservableCollection<Client> ListeVendeur
		{
			get { return _listeVendeur; }
			set { _listeVendeur = value; base.FirePropertyChanged(); }
		}
		public Client SelectedVendeur
		{
			get { return _selectedVendeur; }
			set
			{
				_selectedVendeur = value;
				CurrentOffre.Client = SelectedVendeur;
				FirePropertyChanged("CurrentOffre.Client");
				FirePropertyChanged();

			}
		}
		public Region SelectedRegion
		{
			get { return _selectedRegion; }
			set
			{
				_selectedRegion = value;
				CurrentOffre.Region = SelectedRegion;
				FirePropertyChanged("CurrentOffre.Region");
				FirePropertyChanged();
			}
		}
		public TypeImmobilier SelectedType
		{
			get { return _selectedType; }
			set
			{
				_selectedType = value;
				CurrentOffre.TypeImmobilier = SelectedType;
				FirePropertyChanged("CurrentOffre.TypeImmobilier");
				FirePropertyChanged();
			}
		}
		
		/// <summary>
		/// Initialize la collection Offres par rapport au choix du Type de bien
		/// </summary>
		public TypeImmobilier CurrentType
		{
			get { return _currentType; }
			set
			{
				_currentType = value; 
				if (CurrentRegion == null)
				{
					ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.Where(o => o.TypeImmobilier.Id == CurrentType.Id));
				}
				else
				{
					ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.Where(o => o.Region.Id == CurrentRegion.Id && o.TypeImmobilier.Id == CurrentType.Id));
				}
				
				FirePropertyChanged("Offres");
				FirePropertyChanged();
			}
		}
		#endregion

		#region Commands
		public RelayCommand<bool> CheckBoxIsChecked
		{
			get; set;
		}
		public RelayCommand<bool> CheckBoxPasActuelIsChecked
		{
			get; set;
		}
		public RelayCommand<bool> CheckBoxActuelIsChecked
		{
			get; set;
		}
		public RelayCommand ChercherCommand
		{
			get; set;
		}
		public RelayCommand NewOffreSaveCommand
		{
			get; set;
		}
		public RelayCommand NewOffreCommand
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
		public RelayCommand InfoCommand
		{
			get; set;
		}
		#endregion

		public OffreViewModel()
		{
			this.Load();
			SauverCommand = new RelayCommand(OnSave);
			SupprimerCommand = new RelayCommand(OnDelete);
			ListeVendeur = new ObservableCollection<Client>(_ctx.Clients.OrderBy(c => c.Nom).Where(c=>c.Actif==1));
			NewOffreSaveCommand = new RelayCommand(OnSave);
			ImprimerCommand = new RelayCommand(Print);
			NewOffreCommand = new RelayCommand(GetNew);
			ChercherCommand = new RelayCommand(GetListeDemandesWindow);
			CheckBoxIsChecked = new RelayCommand<bool>(GetActuel);
			CheckBoxPasActuelIsChecked = new RelayCommand<bool>(GetPasActuelListe);
			CheckBoxActuelIsChecked = new RelayCommand<bool>(GetActuelListe);
			InfoCommand = new RelayCommand(GetClientInfoWindow);

		}
		public OffreViewModel(Client c)
		{
			ListeOffres = new ObservableCollection<Offre>(c.Offres);
			SupprimerCommand = new RelayCommand(OnDelete);
			ImprimerCommand = new RelayCommand(Print);
		}
		public OffreViewModel(Region r)
		{
			ListeOffres = new ObservableCollection<Offre>(r.Offres);
			SupprimerCommand = new RelayCommand(OnDelete);
			ImprimerCommand = new RelayCommand(Print);
		}
		public OffreViewModel(TypeImmobilier t)
		{
			ListeOffres = new ObservableCollection<Offre>(t.Offres);
			SupprimerCommand = new RelayCommand(OnDelete);
			ImprimerCommand = new RelayCommand(Print);
		}

		#region Methodes
		protected void Load()
		{
			ListeRegions = new ObservableCollection<Region>(_ctx.Regions.OrderBy(r => r.NomRegion));
			TypesImmobilier = new ObservableCollection<TypeImmobilier>(_ctx.TypeImmobiliers);
			ListeOffres = new ObservableCollection<Offre>(_ctx.Offres);
			if (CurrentOffre == null)
				CurrentOffre = new Offre();

		}
		public void OnDelete()
		{
			MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette offre?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					if (CurrentOffre.Ventes.Count == 0)
					{
						_ctx.Offres.Remove(CurrentOffre);
						_ctx.SaveChanges();
					}
					else
						MessageBox.Show("Impossible de supprimer! Cette offre fait partie d'une vente", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);

				}
				catch (Exception)
				{
					MessageBox.Show("Impossible de supprimer!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			FirePropertyChanged("ListeOffres");
			Load();
		}
		public void OnSave()
		{
				if (CurrentOffre.Id == 0)
				{

					_ctx.Offres.Add(CurrentOffre);
				}
				try
				{
					_ctx.SaveChanges();
					MessageBox.Show("L'offre a été enregistrée");

				}
				catch (Exception)
				{
					MessageBox.Show("Erreur lors de l'enregistrement de l'offre" , "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}

				FirePropertyChanged("CurrentOffre");
				FirePropertyChanged("ListeOffres");
				Load();
		}
		// LA Methode pour le CheckBox, definit si l'offre est actuel
		public void Print()
		{
			try
			{
				ReportingOffre reportingOffre = new ReportingOffre(CurrentOffre.TypeImmobilier.TypeNom, CurrentOffre.Region.NomRegion,
					CurrentOffre.Adresse, 
					CurrentOffre.Nombre_Etages, CurrentOffre.Etage, CurrentOffre.Pieces,
					CurrentOffre.Surface, CurrentOffre.Prix,
					CurrentOffre.Client.PrenomNom, CurrentOffre.IsActuel, CurrentOffre.NomOffre);

				OffreForm report = new OffreForm(new OffreReport(reportingOffre));

				report.ShowDialog();
			}
			catch (Exception)
			{

				MessageBox.Show("D'abord choisissez une Offre", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void GetActuel(bool p)
		{
			if (p)
			{
				CurrentOffre.Actuel = 1;
			}
			else
				CurrentOffre.Actuel = 0;

		}
		private void GetPasActuelListe(bool p)
		{
			if (p)
			{
				ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.Where(o => o.Actuel == 0));
			}
			else
				ListeOffres = new ObservableCollection<Offre>(_ctx.Offres);
		}
		private void GetActuelListe(bool p)
		{
			if (p)
			{
				ListeOffres = new ObservableCollection<Offre>(_ctx.Offres.Where(o => o.Actuel == 1));
			}
			else
				ListeOffres = new ObservableCollection<Offre>(_ctx.Offres);

		}

		public void GetListeDemandesWindow()
		{
			try
			{
				if (CurrentOffre.Id != 0)
				{
					ListeDemandes = new ObservableCollection<Demande>(_ctx.Demandes.Where
						(d => ((d.Prix_de == null ? CurrentOffre.Prix >= 0 : d.Prix_de >= CurrentOffre.Prix) && (d.Prix_a == null ? CurrentOffre.Prix >= 0 : CurrentOffre.Prix <= d.Prix_a)) &&
						 (d.RegionId == null ? CurrentOffre.RegionId > 0 : CurrentOffre.RegionId == d.RegionId) &&
						 (d.TypeId == null ? CurrentOffre.TypeId > 0 : d.TypeId == CurrentOffre.TypeId) &&
						((d.Etage_de == null ? CurrentOffre.Etage >= 0 : CurrentOffre.Etage >= d.Etage_de) && (d.Etage_a == null ? CurrentOffre.Etage >= 0 : CurrentOffre.Etage <= d.Etage_a)) &&
						((d.NombreEtages_de == null ? CurrentOffre.Nombre_Etages >= 0 : CurrentOffre.Nombre_Etages >= d.NombreEtages_de) && d.NombreEtages_a == null ? CurrentOffre.Nombre_Etages >= 0 : CurrentOffre.Nombre_Etages <= d.NombreEtages_a) &&
						((d.Surface_de == null ? CurrentOffre.Surface > 0 : CurrentOffre.Surface >= d.Surface_de) && d.Surface_a == null ? CurrentOffre.Surface > 0 : CurrentOffre.Surface <= d.Surface_a) &&
						((d.Pieces_de == null ? CurrentOffre.Pieces > 0 : CurrentOffre.Pieces >= d.Pieces_de) && (d.Pieces_a == null ? CurrentOffre.Pieces > 0 : CurrentOffre.Pieces <= d.Pieces_a))));
					ListeDemandesWindow win = new ListeDemandesWindow(ListeDemandes);
					win.Owner = Application.Current.MainWindow;
					win.ShowDialog();
				}
				else
				{
					MessageBox.Show("D'abord choisissez une offre", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			catch (Exception)
			{

				MessageBox.Show("D'abord choisissez une offre", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}
		public void GetClientInfoWindow()
		{
			try
			{
				if (CurrentOffre.Client != null)
				{
					ClientInfoWindow win = new ClientInfoWindow(CurrentOffre.Client);
					win.Owner = Application.Current.MainWindow;
					win.ShowDialog();
				}
				else
				{
					MessageBox.Show("D'abord choisissez une offre", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("D'abord choisissez une offre", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			
		}
		public void GetNew()
		{
			CurrentOffre = new Offre();
			ListeVendeur = new ObservableCollection<Client>(_ctx.Clients.OrderBy(c => c.Nom).Where(c => c.Actif == 1));
			ListeRegions = new ObservableCollection<Region>(_ctx.Regions.OrderBy(r => r.NomRegion));
			TypesImmobilier = new ObservableCollection<TypeImmobilier>(_ctx.TypeImmobiliers);
			NewOffreWindow win = new NewOffreWindow();
			win.DataContext = this;
			win.Owner = Application.Current.MainWindow;
			win.ShowDialog();
		}
		#endregion
	}
}
