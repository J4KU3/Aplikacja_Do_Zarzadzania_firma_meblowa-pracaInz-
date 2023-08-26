using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Navigation;

namespace SystemDoZarzadzaniaFirmaMeblowa.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        #region Komendy
       public LoadEmployeesCommand loadEmployeesCommand { get; }
        public ChangeTabCommand changeTabCommand { get; }
        #endregion

        #region Listy
        private ObservableCollection<EmployeeModel> _listOfEmployee = new ObservableCollection<EmployeeModel>();

        public ObservableCollection<EmployeeModel> ListOfEmployee
        {
            get
            {
                return _listOfEmployee;
            }
            set
            {
                _listOfEmployee = value;
                loadEmployeesCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ClientsModel> _listOfClients = new ObservableCollection<ClientsModel>();

        public ObservableCollection<ClientsModel> ListOfClients
        {
            get
            {
                return _listOfClients;
            }
            set
            {
                _listOfClients = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<OrdersModel> _listOfOrders = new ObservableCollection<OrdersModel>();

        public ObservableCollection<OrdersModel> ListOfOrders
        {
            get
            {
                return _listOfOrders;
            }
            set
            {
                _listOfOrders = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ComplaintsModel> _listOfComplaints = new ObservableCollection<ComplaintsModel>();

        public ObservableCollection<ComplaintsModel> ListOfComplaints
        {
            get
            {
                return _listOfComplaints;
            }
            set
            {
                _listOfComplaints = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Zmienne

        private EmployeeModel _employee;

        public EmployeeModel ModelEmployee
        {
            get
            {
                return _employee;
            }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }


        private int _selectedPage;

        public int SelectedPage
        {
            get
            {
                return _selectedPage;
            }
            set
            {
                _selectedPage = value;
                changeTabCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }

        #endregion

        public MainViewModel()
        {
            _employee = new EmployeeModel(new Data.Employees());
            loadEmployeesCommand = new LoadEmployeesCommand(this);
            loadEmployeesCommand.Execute(0);
            changeTabCommand = new ChangeTabCommand(this);
        }
    }
}
