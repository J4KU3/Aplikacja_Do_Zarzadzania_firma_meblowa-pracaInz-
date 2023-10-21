using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Models;

namespace SystemDoZarzadzaniaFirmaMeblowa.ViewModels
{
   public class AddEmployeeWindowViewModel:BaseViewModel
    {
        //Komendy

        //Zmienne 
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
                OnPropertyChanged();
            }
        }

        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; OnPropertyChanged() }
        }

        public AddEmployeeWindowViewModel()
        {

        }
    }
}
