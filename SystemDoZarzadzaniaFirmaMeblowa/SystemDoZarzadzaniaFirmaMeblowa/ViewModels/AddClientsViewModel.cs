using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.Commands;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder.AddClientsViewCommands;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Views;

namespace SystemDoZarzadzaniaFirmaMeblowa.ViewModels
{
   public class AddClientsViewModel: BaseViewModel
    {
        //zmienne 
        private readonly MainViewModel _mainViewModel;

        private ClientsModel _clientsModel;
       public ClientsModel ModelClients
        {
            get
            {
                return _clientsModel;
            }
            set
            {
                _clientsModel = value;
                addClientsCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        



        //komendy
        public CloseAddClientsWindow closeAddClientsWindow { get; }
        public LoadClientsCommand loadClientsCommand { get; }
        public AddClientsCommand addClientsCommand { get; }


        public AddClientsViewModel()
        {
            _mainViewModel = new MainViewModel();
            _clientsModel = new ClientsModel(new Data.Clients());
            closeAddClientsWindow = new CloseAddClientsWindow(Application.Current.Windows.OfType<AddClientView>().FirstOrDefault());
            addClientsCommand = new AddClientsCommand(this);
            loadClientsCommand = new LoadClientsCommand(_mainViewModel);
            loadClientsCommand.Execute(0);
        }
    }
}
