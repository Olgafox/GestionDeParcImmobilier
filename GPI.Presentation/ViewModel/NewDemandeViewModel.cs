using GalaSoft.MvvmLight.CommandWpf;
using GPI.Persistence.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPI.Presentation.ViewModel
{
	public class NewDemandeViewModel : DemandeViewModel
	{
		/*private Region _selectedRegion;
		private TypeImmobilier _selectedType;
		private ObservableCollection<Client> _listeClients;
		private Client _selectedClient;
		private ObservableCollection<Region> _listeRegions;
		private ObservableCollection<TypeImmobilier> _typesImmobilier;
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
				CurrentDemande.Client = _selectedClient;
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
				CurrentDemande.TypeId = SelectedType.Id;
				FirePropertyChanged("CurrentDemande.TypeImmobilier");
				FirePropertyChanged();
			}
		}
		
			public RelayCommand NewDemandeSaveCommand
		{
			get; set;
		}
		public NewDemandeViewModel()
		{
			ListeClients = new ObservableCollection<Client>(_ctx.Clients);
			ListeClients = new ObservableCollection<Client>(_ctx.Clients);
			ListeRegions = new ObservableCollection<Region>(_ctx.Regions.OrderBy(r => r.NomRegion));
			TypesImmobilier = new ObservableCollection<TypeImmobilier>(_ctx.TypeImmobiliers);
			CurrentDemande = new Demande();
			NewDemandeSaveCommand = new RelayCommand(OnSave);
		}*/
	}
}
