using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo.AddEmployeeViewCommand
{
   public class AddEmployeeCommand:CommandBase
    {
        private readonly AddEmployeeWindowViewModel _addEmployeeWindowViewModel;

        public AddEmployeeCommand(AddEmployeeWindowViewModel addEmployeeWindowViewModel)
        {
            _addEmployeeWindowViewModel = addEmployeeWindowViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
         
           
            using (var Employee = new ZarzadzanieFirmaDBEntities())
            {
                if (_addEmployeeWindowViewModel.ModelEmplo.EFirstName !=null && _addEmployeeWindowViewModel.ModelEmplo.ELastName != null && _addEmployeeWindowViewModel.ModelEmplo.Mail != null
                   && _addEmployeeWindowViewModel.ModelEmplo.Phone !=null && _addEmployeeWindowViewModel.ModelEmplo.Password !=null )
                {
                    var newEmployee = new Employees
                    {
                        EFirstName = _addEmployeeWindowViewModel.ModelEmplo.EFirstName,
                        ELastName = _addEmployeeWindowViewModel.ModelEmplo.ELastName,
                        Mail = _addEmployeeWindowViewModel.ModelEmplo.Mail,
                        Phone = _addEmployeeWindowViewModel.ModelEmplo.Phone,
                        Password = _addEmployeeWindowViewModel.ModelEmplo.Password,
                        IsAdmin = _addEmployeeWindowViewModel.IsAdmin
                    };
                    Employee.Employees.Add(newEmployee);
                    Employee.SaveChanges();
                    

                }
                else
                {
                    MessageBox.Show("jakas dana nie zostala wpisana ");
                }

            }
            _addEmployeeWindowViewModel.loadEmployeeCommand.Execute(0);
            _addEmployeeWindowViewModel.closeWindowCommand.Execute(0);
        }
    }
}
