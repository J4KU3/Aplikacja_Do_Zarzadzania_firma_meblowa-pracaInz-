using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;


namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder
{
    public class EditClientsCommand:CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public EditClientsCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _mainViewModel.SelectedClient != null;
        }
        public override void Execute(object parameter)
        {
            try
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                    var ClientToEdit = resource.Clients.FirstOrDefault(c => c.ClientID == _mainViewModel.SelectedClient.ClientID);
                    var selectedClient = _mainViewModel.SelectedClient;
                    if (ClientToEdit != null)
                    {
                        ClientToEdit.ClientID = selectedClient.ClientID;
                        ClientToEdit.CFName = selectedClient.CFName;
                        ClientToEdit.CLName = selectedClient.CLName;
                        ClientToEdit.Phone = selectedClient.Phone;
                        ClientToEdit.Zipcode = selectedClient.Zipcode;
                        ClientToEdit.City = selectedClient.City;
                        ClientToEdit.Street = selectedClient.Street;
                        ClientToEdit.ApartmentNumber = selectedClient.ApartmentNumber;
                        resource.SaveChanges();
                        MessageBox.Show($"KLient o id:{ClientToEdit.ClientID} został edytowany ");
                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Żaden klient z listy nie został wybrany");
            }
        }
    }
}
