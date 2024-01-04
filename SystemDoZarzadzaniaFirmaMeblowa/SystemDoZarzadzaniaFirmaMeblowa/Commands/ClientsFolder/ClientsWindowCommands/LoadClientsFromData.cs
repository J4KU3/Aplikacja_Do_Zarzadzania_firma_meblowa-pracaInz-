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
    public class LoadClientsFromData:CommandBase
    {
        private readonly ClientsWindowViewModel _cientsViewModel;

        public LoadClientsFromData(ClientsWindowViewModel mainViewModel)
        {
            _cientsViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            using (var resource = new ZarzadzanieFirmaDBEntities())
            {
                List<Clients> clientslist = resource.Clients.ToList();
                List<ClientsModel> convertedList = clientslist.Select(c => new ClientsModel(c)).ToList();
                _cientsViewModel.ListOfClients = new ObservableCollection<ClientsModel>(convertedList);

            }
        }
    }
}
