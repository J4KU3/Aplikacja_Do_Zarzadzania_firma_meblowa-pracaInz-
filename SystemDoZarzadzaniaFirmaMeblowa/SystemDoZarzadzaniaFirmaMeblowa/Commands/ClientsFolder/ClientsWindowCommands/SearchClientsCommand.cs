using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder.ClientsWindowCommands
{
    public class SearchClientsCommand:CommandBase
    {
        private readonly ClientsWindowViewModel _clientsWindowViewModel;

        public SearchClientsCommand(ClientsWindowViewModel clientsWindowViewModel)
        {
            _clientsWindowViewModel = clientsWindowViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            if (_clientsWindowViewModel.ModelClients.CFName != "" && _clientsWindowViewModel.ModelClients.CFName != null)
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                    List<Data.Clients> clientsL = resource.Clients.ToList();
                   

                    var searchClients = clientsL.Where(o => o.CFName == _clientsWindowViewModel.ModelClients.CFName);

                    List<ClientsModel> convertedList = searchClients.Select(c => new ClientsModel(c)).ToList();
                    

                    _clientsWindowViewModel.ListOfClients = new ObservableCollection<ClientsModel>(convertedList);
                }
            }
            else
            {
                _clientsWindowViewModel.loadClientsFromData.Execute(0);
            }

        }
    }
}
