using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo.AddEmployeeViewCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Views;

namespace SystemDoZarzadzaniaFirmaMeblowa.ViewModels
{
    public class AddEmployeeWindowViewModel : BaseViewModel
    {
        //Komendy
        public AddEmployeeCommand addEmployeeCommand { get; }
        public LoadEmployeesCommand loadEmployeeCommand {get;}
        public CloseWindowCommand closeWindowCommand { get; }
        //Zmienne 
        private readonly MainViewModel _mainViewModel;

        private EmployeeModel _employeeModel;

        public EmployeeModel ModelEmplo
        {
            get
            {
                return _employeeModel;
            }
            set
            {
                _employeeModel = value;
                addEmployeeCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; OnPropertyChanged(); }
        }

        //konstruktor
        public AddEmployeeWindowViewModel()
        {
            _employeeModel = new EmployeeModel(new Data.Employees());
            addEmployeeCommand = new AddEmployeeCommand(this);
            _mainViewModel = new MainViewModel();
            loadEmployeeCommand = new LoadEmployeesCommand(_mainViewModel);
            loadEmployeeCommand.Execute(0);
            closeWindowCommand = new CloseWindowCommand(Application.Current.Windows.OfType<AddEmployeeWindow>().FirstOrDefault());
            
        }
    }
}
