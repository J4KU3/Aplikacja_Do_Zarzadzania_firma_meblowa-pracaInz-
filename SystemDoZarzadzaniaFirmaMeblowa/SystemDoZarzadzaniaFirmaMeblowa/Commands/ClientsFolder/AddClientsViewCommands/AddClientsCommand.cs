using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.Commands;
using System.Windows;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder.AddClientsViewCommands
{
   public class AddClientsCommand:CommandBase
    {
        private readonly AddClientsViewModel _addClientsViewModel;

        public AddClientsCommand(AddClientsViewModel addClientsViewModel)
        {
            _addClientsViewModel = addClientsViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            using (var client = new ZarzadzanieFirmaDBEntities())
            {
                if (_addClientsViewModel.ModelClients.CFName != null && _addClientsViewModel.ModelClients.CLName != null && _addClientsViewModel.ModelClients.Zipcode != null
                   && _addClientsViewModel.ModelClients.Phone != null && _addClientsViewModel.ModelClients.Street != null && _addClientsViewModel.ModelClients.City != null && _addClientsViewModel.ModelClients.ApartmentNumber !=null )
                {
                    var newClient = new Clients
                    {
                        CFName = _addClientsViewModel.ModelClients.CFName,
                        CLName = _addClientsViewModel.ModelClients.CLName,
                        Zipcode = _addClientsViewModel.ModelClients.Zipcode,
                        Phone = _addClientsViewModel.ModelClients.Phone,
                        Street = _addClientsViewModel.ModelClients.Street,
                        City = _addClientsViewModel.ModelClients.City,
                        ApartmentNumber = _addClientsViewModel.ModelClients.ApartmentNumber
                    };
                    client.Clients.Add(newClient);
                    client.SaveChanges();


                }
                else
                {
                    MessageBox.Show("jakas dana nie zostala wpisana ");
                }

            }
            _addClientsViewModel.loadClientsCommand.Execute(0);
            _addClientsViewModel.closeAddClientsWindow.Execute(0);
        }
    }
}
