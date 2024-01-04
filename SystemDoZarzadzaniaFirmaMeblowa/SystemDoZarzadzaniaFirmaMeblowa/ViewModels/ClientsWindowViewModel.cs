using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder.ClientsWindowCommands;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.Views;

namespace SystemDoZarzadzaniaFirmaMeblowa.ViewModels
{
    public class ClientsWindowViewModel:BaseViewModel
    {
        //Komendy
        public LoadClientsFromData loadClientsFromData { get; }
        public SearchClientsCommand searchClientsCommand { get; }
        public ExitClientsWindowCommand exitClientsWindowCommand { get; }

        //listy
        private ObservableCollection<ClientsModel> _listOfClients = new ObservableCollection<ClientsModel>();

        public ObservableCollection<ClientsModel> ListOfClients
        {
            get
            {
                return _listOfClients;
            }
            set
            {
                _listOfClients = value;
                loadClientsFromData.OnCanExecuteChanged();
                
                OnPropertyChanged();
            }
        }

        //zmienne 
        private ClientsModel _clientsmodel;
        public ClientsModel ModelClients
        {
            get
            {
                return _clientsmodel;
            }
            set
            {
                _clientsmodel = value;
                OnPropertyChanged();
            }
        }

        public ClientsWindowViewModel()
        {
            _clientsmodel = new ClientsModel(new Data.Clients());
            loadClientsFromData = new LoadClientsFromData(this);
            loadClientsFromData.Execute(0);
            searchClientsCommand=new SearchClientsCommand(this);
            exitClientsWindowCommand = new ExitClientsWindowCommand(Application.Current.Windows.OfType<ClientsView>().FirstOrDefault());
        }
    }
}
