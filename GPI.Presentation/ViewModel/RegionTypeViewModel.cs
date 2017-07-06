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
	public class RegionTypeViewModel : ViewModelBase, ICrud
	{
		private ObservableCollection<Region> _listeRegions;
		private ObservableCollection<TypeImmobilier> _typesImmobilier;
		private TypeImmobilier _currentType;
		private Region _currentRegion;
		public TypeImmobilier CurrentType
		{
			get { return _currentType; }
			set
			{
				_currentType = value;
				FirePropertyChanged();
			}
		}
		public Region CurrentRegion
		{
			get { return _currentRegion; }
			set
			{
				_currentRegion = value;
				FirePropertyChanged();
			}
		}
		public RelayCommand SupprimerRegionCommand
		{
			get; set;
		}
		public RelayCommand SupprimerTypeCommand
		{
			get; set;
		}
		public RelayCommand NewRegionCommand
		{
			get; set;
		}
		public RelayCommand NewTypeCommand
		{
			get; set;
		}


		public RelayCommand SauverRegionCommand
		{
			get; set;
		}
		public RelayCommand SauverTypeCommand
		{
			get; set;
		}
		public RelayCommand ChercherOffresRegion
		{
			get; set;
		}
		public RelayCommand ChercherDemandesRegion
		{
			get; set;
		}
		public RelayCommand ChercherOffresType
		{
			get; set;
		}
		public RelayCommand ChercherDemandesType
		{
			get; set;
		}
		public RelayCommand ChercherVentesRegion
		{
			get; set;
		}
		public RelayCommand ChercherVentesType
		{
			get; set;
		}


		public ObservableCollection<Region> ListeRegions
		{
			get { return _listeRegions; }
			set
			{
				_listeRegions = value; base.FirePropertyChanged();
			}
		}
		public ObservableCollection<TypeImmobilier> TypesImmobilier
		{
			get { return _typesImmobilier; }
			set { _typesImmobilier = value; base.FirePropertyChanged(); }
		}

		public RegionTypeViewModel()
		{
			LoadRegion();
			LoadType();
			SupprimerRegionCommand = new RelayCommand(OnDelete);
			SauverRegionCommand = new RelayCommand(OnSave);
			NewRegionCommand = new RelayCommand(GetNew);
			SupprimerTypeCommand = new RelayCommand(OnDeleteType);
			SauverTypeCommand = new RelayCommand(OnSaveType);
			NewTypeCommand = new RelayCommand(GetNewType);
			ChercherDemandesRegion = new RelayCommand(GetDemandesRegion);
			ChercherOffresRegion = new RelayCommand(GetOffresRegion);
			ChercherDemandesType = new RelayCommand(GetDemandesType);
			ChercherOffresType = new RelayCommand(GetOffresType);
			ChercherVentesRegion = new RelayCommand(GetVentesRegion);
			ChercherVentesType = new RelayCommand(GetVentesType);
		}
		private void GetOffresRegion()
		{
			if (CurrentRegion.Id != 0 && CurrentRegion != null)
			{
				ListeOffresWindow win = new ListeOffresWindow(CurrentRegion);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez une Région", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void GetDemandesRegion()
		{
			if (CurrentRegion.Id != 0 && CurrentRegion != null)
			{
				ListeDemandesWindow win = new ListeDemandesWindow(CurrentRegion);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez une Région", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void GetDemandesType()
		{
			if (CurrentType.Id != 0 && CurrentType != null)
			{
				ListeDemandesWindow win = new ListeDemandesWindow(CurrentType);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez un Type Immobilier", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void GetOffresType()
		{
			if (CurrentType.Id != 0 && CurrentType != null)
			{
				ListeOffresWindow win = new ListeOffresWindow(CurrentType);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez un Type Immobilier", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void GetVentesRegion()
		{
			if (CurrentRegion.Id != 0 && CurrentRegion != null)
			{
				ListeVentesWindow win = new ListeVentesWindow(CurrentRegion);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez une Région", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void GetVentesType()
		{
			if (CurrentType.Id != 0 && CurrentType != null)
			{
				ListeVentesWindow win = new ListeVentesWindow(CurrentType);
				win.Owner = Application.Current.MainWindow;
				win.ShowDialog();
			}
			else
				MessageBox.Show("D'abord choisissez un Type Immobilier", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
		}
		private void LoadRegion()
		{
			ListeRegions = new ObservableCollection<Region>(_ctx.Regions.OrderBy(r => r.NomRegion));
			if (CurrentRegion == null)
				CurrentRegion = new Region();
		}
		private void LoadType()
		{
			TypesImmobilier = new ObservableCollection<TypeImmobilier>(_ctx.TypeImmobiliers);
			if (CurrentType == null)
				CurrentType = new TypeImmobilier();
		}
		public void GetNew()
		{
			CurrentRegion = new Region();
		}

		public void OnDelete()
		{
			MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer cette Région?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					if (CurrentRegion.Offres.Count == 0 && CurrentRegion.Demandes.Count == 0)
					{
						_ctx.Regions.Remove(CurrentRegion);
						_ctx.SaveChanges();
						FirePropertyChanged("ListeRegions");
						LoadRegion();
					}
					else
					{
						MessageBox.Show("D'abord supprimez les Demandes et Offres dans cette Région!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
					}

				}
				catch (Exception)
				{
					MessageBox.Show("Impossible de supprimer!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			
		}

		public void OnSave()
		{
			if (CurrentRegion.Id == 0)
			{

				_ctx.Regions.Add(CurrentRegion);
			}
			try
			{
				_ctx.SaveChanges();
				MessageBox.Show("La Région a été enregistrée");

			}
			catch (Exception)
			{
				MessageBox.Show("Erreur lors de l'enregistrement de la Région ", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			FirePropertyChanged("CurrentRegion");
			FirePropertyChanged("ListeRegions");
			LoadRegion();
		}
		public void OnDeleteType()
		{
			MessageBoxResult result = MessageBox.Show("Voulez-vous supprimer ce Type Immobilier?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					if (CurrentType.Offres.Count == 0 && CurrentType.Demandes.Count == 0)
					{
						_ctx.TypeImmobiliers.Remove(CurrentType);
						_ctx.SaveChanges();
						FirePropertyChanged("TypesImmobilier");
						LoadType();
					}
					else
					{
						MessageBox.Show("D'abord supprimez les Demandes et Offres de ce Type!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
				catch (Exception)
				{
					MessageBox.Show("Impossible de supprimer!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}	
		}
		public void OnSaveType()
		{
			if (CurrentType.Id == 0)
			{
				_ctx.TypeImmobiliers.Add(CurrentType);
			}
			try
			{
				_ctx.SaveChanges();
				MessageBox.Show("Le Type Immobilier a été enregistrée");
			}
			catch (Exception)
			{
				MessageBox.Show("Erreur lors de l'enregistrement du Type Immobilier ", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			FirePropertyChanged("CurrentType");
			FirePropertyChanged("TypesImmobilier");
			LoadType();
		}
		public void GetNewType()
		{
			CurrentType= new TypeImmobilier();
		}
		public void Print()
		{
			throw new NotImplementedException();
		}
	}
}
