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


namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ComplaintsFolder
{
    public class AddComplaints:CommandBase
    {
        private readonly MainViewModel _mainviewmodel;

        public AddComplaints(MainViewModel mainViewModel)
        {
            _mainviewmodel = mainViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            try
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                  
                    
                    if (_mainviewmodel.ModelComplaints !=null && _mainviewmodel.SelectedComplaintsOrder != null)
                    {
                        var newcomplaints = new Complaints
                        {
                            Reason = _mainviewmodel.ModelComplaints.Reason,
                            OrderID = _mainviewmodel.SelectedComplaintsOrder.OrderID
                        };
                        resource.Complaints.Add(newcomplaints);
                        resource.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("jakas dana nie zostala wpisana ");
                    }

                }
                _mainviewmodel.loadComplaintsFromDataCommand.Execute(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}\n{ex.StackTrace}");

            }
        }
    }
}
