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
   public class DeleteComplaintsCommand:CommandBase
   {
        private readonly MainViewModel _mainViewModel;

        public DeleteComplaintsCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return _mainViewModel.SelectedComplaints != null;
        }
        public override void Execute(object parameter)
        {
            try
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                    var ComplaintToDelete = resource.Complaints.FirstOrDefault(c=>c.IdComplaint == _mainViewModel.SelectedComplaints.IdComplaint);
                    if (ComplaintToDelete != null)
                    {
                        resource.Complaints.Remove(ComplaintToDelete);
                        resource.SaveChanges();
                    }



                }

            }
            catch (Exception)
            {

                MessageBox.Show("Nie wybrano żadnej reklamacji");
            }
        }
    }
}
