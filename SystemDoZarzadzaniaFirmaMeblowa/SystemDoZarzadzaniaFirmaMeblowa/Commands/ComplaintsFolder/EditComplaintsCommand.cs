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
   public class EditComplaintsCommand:CommandBase
    {
        private readonly MainViewModel _mainviewModel;

        public EditComplaintsCommand(MainViewModel mainViewModel)
        {
            _mainviewModel = mainViewModel;
        }
        public override bool CanExecute(object parameter)
        {

            if (_mainviewModel.SelectedComplaints != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void Execute(object parameter)
        {
            try
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                    var ComplaintToEdit = resource.Complaints.FirstOrDefault(x => x.IdComplaint == _mainviewModel.SelectedComplaints.IdComplaint);
                    var selectedComplaint = _mainviewModel.SelectedComplaints;
                    if (ComplaintToEdit != null)
                    {
                        
                        ComplaintToEdit.Reason = selectedComplaint.Reason;
                        ComplaintToEdit.OrderID = selectedComplaint.OrderID;
                        ComplaintToEdit.IdComplaint = selectedComplaint.IdComplaint;
  
                        resource.SaveChanges();
                        MessageBox.Show($"Reklamacja:{ComplaintToEdit.IdComplaint} został edytowana");
                        _mainviewModel.loadComplaintsFromDataCommand.Execute(0);
                    }


                }
            }
            catch (Exception)
            {

                MessageBox.Show("Żadna reklamacja nie została zaznaczona");
            }
        }
    }
}
