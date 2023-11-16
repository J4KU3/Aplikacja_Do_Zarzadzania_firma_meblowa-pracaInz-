using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using System.Windows;

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
            return _mainViewModel.SelectedEmployee != null;
           
        }

        public override void Execute(object parameter)
        {
            try
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                    var EmployeeToEdit = resource.Employees.FirstOrDefault(x => x.employeeID == _mainViewModel.SelectedEmployee.employeeID);
                    var selectedEmp = _mainViewModel.SelectedEmployee;
                    if (EmployeeToEdit != null)
                    {
                        EmployeeToEdit.EFirstName = selectedEmp.EFirstName;
                        EmployeeToEdit.ELastName = selectedEmp.ELastName;
                        EmployeeToEdit.Phone = selectedEmp.Phone;
                        EmployeeToEdit.Mail = selectedEmp.Mail;
                        EmployeeToEdit.Password = selectedEmp.Password;
                        EmployeeToEdit.IsAdmin = selectedEmp.IsAdmin;
                        resource.SaveChanges();
                        MessageBox.Show($"Pracownik o id:{EmployeeToEdit.employeeID} został edytowany ");
                    }

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Żaden pracownik z listy nie został wybrany");
            }
           
        }

    }
}
