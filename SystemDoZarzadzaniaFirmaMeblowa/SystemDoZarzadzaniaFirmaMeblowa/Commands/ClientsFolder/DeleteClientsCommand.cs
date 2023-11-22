using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using System.Windows;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder
{
    public class DeleteClientsCommand:CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public DeleteClientsCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return _mainViewModel.SelectedClient != null;  
        }
        public override void Execute(object parameter)
        {
            using (var resource = new ZarzadzanieFirmaDBEntities())
            {
                var clientToDelete = resource.Clients.FirstOrDefault(c=>c.ClientID == _mainViewModel.SelectedClient.ClientID);
                if (clientToDelete !=null)
                {
                    resource.Clients.Remove(clientToDelete);
                    resource.SaveChanges();
                    _mainViewModel.loadClientsCommand.Execute(0);
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd");
                }
                

            }
        }
    }
}
