using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo
{
  public class EditEmployeeCommand:CommandBase
  {
        private readonly MainViewModel _mainViewModel;

        public EditEmployeeCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            using (var resource = new ZarzadzanieFirmaDBEntities())
            {
                var EmployeeToEdit = resource.Employees.FirstOrDefault(x=>x.employeeID == _mainViewModel.SelectedEmployee.employeeID);

                if (EmployeeToEdit != null)
                {
                    EmployeeToEdit.EFirstName = _mainViewModel.SelectedEmployee.EFirstName;
                    EmployeeToEdit.ELastName = _mainViewModel.SelectedEmployee.ELastName;
                    EmployeeToEdit.Phone = _mainViewModel.SelectedEmployee.Phone;
                    EmployeeToEdit.Mail = _mainViewModel.SelectedEmployee.Mail;
                    EmployeeToEdit.Passsword = _mainViewModel.SelectedEmployee.Passsword;
                    EmployeeToEdit.IsAdmin = _mainViewModel.SelectedEmployee.IsAdmin;
                }

            }
        }

    }
}
