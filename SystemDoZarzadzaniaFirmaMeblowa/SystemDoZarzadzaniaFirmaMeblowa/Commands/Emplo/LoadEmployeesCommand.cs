using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using System.Collections.ObjectModel;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo
{
   public class LoadEmployeesCommand:CommandBase
    {
        private readonly MainViewModel _mainviewModel;

        public LoadEmployeesCommand(MainViewModel mainViewModel)
        {
            _mainviewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            using (var resource = new ZarzadzanieFirmaDBEntities())
            {
                List<Employees> employeesList = resource.Employees.ToList();
                List<EmployeeModel> convertedList = employeesList.Select(x=> new EmployeeModel(x)).ToList();
                _mainviewModel.ListOfEmployee = new ObservableCollection<EmployeeModel>(convertedList);

            }



        }


    }
}
