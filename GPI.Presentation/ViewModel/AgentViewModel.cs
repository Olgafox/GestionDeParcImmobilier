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
	public class AgentViewModel : ViewModelBase, ICrud
	{
		private RelayCommand<String> _search;
		private ObservableCollection<Agent> _listeAgents;
		private Agent _currentAgent;
		private Vente _selectedVente;
		public ObservableCollection<Agent> ListeAgents
		{
			get { return _listeAgents; }
			set { _listeAgents = value; base.FirePropertyChanged(); }
		}
		public Agent CurrentAgent
		{
			get { return _currentAgent; }
			set { _currentAgent = value; FirePropertyChanged(); }
		}
		public Vente SelectedVente
		{
			get { return _selectedVente; }
			set { _selectedVente = value; FirePropertyChanged(); }
		}
		#region Commands
		public RelayCommand NewAgentCommand
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
		public RelayCommand<string> ChercherAgentCommand
		{
			get { return _search; }
			set { _search = value; }
		}
		public RelayCommand MouseDoubleClickCommand
		{
			get { return new RelayCommand(GetVenteDetailWindow); }
		}
		
		#endregion

		public AgentViewModel()
		{
			Load();
			ChercherAgentCommand = new RelayCommand<string>(GetAgentList);
			SauverCommand = new RelayCommand(OnSave);
			SupprimerCommand = new RelayCommand(OnDelete);
			NewAgentCommand = new RelayCommand(GetNew);
			ImprimerCommand = new RelayCommand(Print);

		}
		public AgentViewModel(Agent a)
		{
			CurrentAgent = a;
			SauverCommand = new RelayCommand(OnSave);
			ImprimerCommand = new RelayCommand(Print);
		}
		#region Méthodes
		private void Load()
		{
			ListeAgents = new ObservableCollection<Agent>(_ctx.Agents.OrderBy(a => a.Nom).Where(a =>a.Actif == 1));
			if (CurrentAgent == null)
				CurrentAgent = new Agent();

		}
		private void GetAgentList(string str)
		{
			if (str != "")
				ListeAgents = new ObservableCollection<Agent>(_ctx.Agents.Where(v => (v.Nom.Contains(str.ToLower()) || v.Prenom.Contains(str.ToLower())) && v.Actif == 1));
			else
				Load();
		}
		public void OnDelete()
		{
			MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cet Agent?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning);

			if (result == MessageBoxResult.Yes)
			{
				try
				{
					CurrentAgent.Actif = 0;
					_ctx.SaveChanges();
				}
				catch (Exception)
				{
					MessageBox.Show("Impossible de supprimer!", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			FirePropertyChanged("ListeAgents");
			Load();
		}

		public void OnSave()
		{
			if (CurrentAgent.Id == 0)
			{
					CurrentAgent.Actif = 1;
				_ctx.Agents.Add(CurrentAgent);
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

			FirePropertyChanged("CurrentAgent");
			FirePropertyChanged("ListeAgents");
			Load();
		}
		public void Print()
		{
			if(CurrentAgent.Id !=0 && CurrentAgent != null)
			{
				ReportedAgent reportedAgent = new ReportedAgent(CurrentAgent.PrenomNom, CurrentAgent.Adresse, CurrentAgent.Telephone, CurrentAgent.ComissionTotale);
				reportedAgent.ReportedVentes = new List<VenteReport>();
				//ListeVentes lv;
				List<VenteReport> liste = new List<VenteReport>();
				foreach (Vente v in CurrentAgent.Ventes)
				{
					ReportedVente reportedVente = new ReportedVente(v.DateVenteFormated, v.NomVente, v.ComissionAgent);
					reportedVente.reportingOffre = new ReportingOffre(v.Offre.NomOffre, v.Offre.Adresse, v.Offre.Prix, v.Offre.Surface);
					VenteReport vr = new VenteReport(reportedVente);
					liste.Add(vr);
					reportedAgent.ReportedVentes.Add(vr);
				}
				//lv = new ListeVentes(liste);
				AgentForm report = new AgentForm(new AgentReporting(reportedAgent));
				report.ShowDialog();
			}
			else
			{
				MessageBox.Show("D'abord choisissez un Agent", "Avertissement", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void GetVenteDetailWindow()
		{
			Vente v = SelectedVente;
			VenteDetailWindow win = new VenteDetailWindow(SelectedVente);
			win.Owner = Application.Current.MainWindow;
			win.ShowDialog();
		}
		public void GetNew()
		{
			CurrentAgent = new Agent();
		}
		#endregion


	}
}
