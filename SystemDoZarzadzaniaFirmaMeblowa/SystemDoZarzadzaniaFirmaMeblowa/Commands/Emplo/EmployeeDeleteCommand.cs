using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo
{
   public class EmployeeDeleteCommand :CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public EmployeeDeleteCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            if (_mainViewModel.SelectedEmployee != null)
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
                using (var UserToDelete = new ZarzadzanieFirmaDBEntities())
                {
                    var Employee = UserToDelete.Employees.FirstOrDefault(x=>x.employeeID == _mainViewModel.SelectedEmployee.employeeID);
                    if (Employee != null)
                    {
                        UserToDelete.Employees.Remove(Employee);
                        UserToDelete.SaveChanges();
                        _mainViewModel.loadEmployeesCommand.Execute(0);



                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Wybierz pracownika z listy do usunięcia");
            }
        }

    }
}
