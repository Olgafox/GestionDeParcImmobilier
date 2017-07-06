using GalaSoft.MvvmLight.CommandWpf;
using GPI.Persistence.EntityRepositories;
using GPI.Presentation.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GPI.Presentation.ViewModel
{
	class NewOffreViewModel //: OffreViewModel
	{
		/*private ObservableCollection<Client> _listeVendeur;
		private Client _selectedVendeur;
		private Offre _newOffre;
		private Region _selectedRegion;
		private TypeImmobilier _selectedType;

		#region Propriétés
		public ObservableCollection<Client> ListeVendeur
		{
			get { return _listeVendeur; }
			set { _listeVendeur = value; base.FirePropertyChanged(); }
		}
		public Offre NewOffre
		{
			get { return _newOffre; }
			set { _newOffre = value; base.FirePropertyChanged(); }
		}
		public Client SelectedVendeur
		{
			get { return _selectedVendeur; }
			set {
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
				CurrentOffre.TypeId = SelectedType.Id;
				FirePropertyChanged("CurrentOffre.TypeImmobilier");
				FirePropertyChanged();
			}
		}
		public RelayCommand<bool> CheckBoxIsChecked
		{
			get; set;
		}
		
		public RelayCommand NewOffreSaveCommand
		{
			get; set;
		}
		#endregion
		public NewOffreViewModel()
		{
			ListeVendeur = new ObservableCollection<Client>(_ctx.Clients.OrderBy(c =>c.Nom));
			CurrentOffre = new Offre();
			NewOffreSaveCommand = new RelayCommand(OnSave);
			CheckBoxIsChecked = new RelayCommand<bool>(GetActuel);
		}
		#region Méthodes

		// LA Methode pour le CheckBox, definit si l'offre est actuel
		private void GetActuel(bool p)
		{
			if (p)
			{
				CurrentOffre.Actuel = 1;
			}
			else
				CurrentOffre.Actuel = 0;

		}
		protected void NewOnSave()
		{
			if (CurrentOffre.Id == 0)
			{

				_ctx.Offres.Add(CurrentOffre);
			}
			try
			{
				_ctx.SaveChanges();

				foreach (Offre o in _ctx.Offres)
				{
					Console.WriteLine("C'est les Offres {0}", o.Id);
				}


				MessageBox.Show("L'offre a été enregistrée");

			}
			catch (Exception)
			{
				MessageBox.Show("Erreur lors de l'enregistrement de l'offre ");
			}

			
			FirePropertyChanged("ListeOffres");
			Load();
		}
		#endregion*/
	}
}
