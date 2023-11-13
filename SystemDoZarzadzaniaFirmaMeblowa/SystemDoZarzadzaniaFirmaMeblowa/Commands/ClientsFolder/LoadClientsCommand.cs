using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using System.Collections.ObjectModel;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder
{
   public class LoadClientsCommand:CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public LoadClientsCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            using (var resource = new ZarzadzanieFirmaDBEntities())
            {
                List<Clients> employeesList = resource.Clients.ToList();
                List<ClientsModel> convertedList = employeesList.Select(c => new ClientsModel(c)).ToList();
                _mainViewModel.ListOfClients = new ObservableCollection<ClientsModel>(convertedList);

            }
        }
    }
}
