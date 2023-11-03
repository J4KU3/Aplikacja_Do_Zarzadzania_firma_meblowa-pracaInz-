using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Navigation;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.LoginPageCommands;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Orders;

namespace SystemDoZarzadzaniaFirmaMeblowa.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Komendy
        //pracownict
        public LoadEmployeesCommand loadEmployeesCommand { get; }
        public EmployeeDeleteCommand employeeDeleteCommand { get; }
        public EditEmployeeCommand editEmployeeCommand { get; }
        //
        // Zamowienia
        public LoadOrdersCommand loadOrdersCommand { get; }
        //
        public ChangeTabCommand changeTabCommand { get; }
        public LoginCommand loginCommand { get; }
        public ExitCommand exitCommand { get; }
        public OpenAddEmployeeCommand openEmployeeWidnowCommand { get; }

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
                loadOrdersCommand.OnCanExecuteChanged();
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
        //Pracownicy
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
                loginCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        private EmployeeModel _selectedEmployee;

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; employeeDeleteCommand.OnCanExecuteChanged(); editEmployeeCommand.OnCanExecuteChanged(); OnPropertyChanged(); }
        }

        private bool _IsAdmin;
        public bool ISAdmin
        {
            get { return _IsAdmin; }
            set { _IsAdmin = value; OnPropertyChanged(); }
        }

        //Zamowienia
        private OrdersModel _selectedOrder;
        public OrdersModel SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged();
            }
        }
        private bool _isProject;
        public bool IsProjct
        {
            get
            {
                return _isProject;
            }
            set
            {
                _isProject = value;
                OnPropertyChanged();
            }
        }

        //głowne zmienne 
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
                loginCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }

       
        #endregion

        public MainViewModel()
        {
            _employee = new EmployeeModel(new Data.Employees());
            loadEmployeesCommand = new LoadEmployeesCommand(this);
            loadEmployeesCommand.Execute(0);
            employeeDeleteCommand = new EmployeeDeleteCommand(this);
            editEmployeeCommand = new EditEmployeeCommand(this);
            changeTabCommand = new ChangeTabCommand(this);
            loginCommand = new LoginCommand(this);
            exitCommand = new ExitCommand(this);
            openEmployeeWidnowCommand = new OpenAddEmployeeCommand(this);
            loadOrdersCommand = new LoadOrdersCommand(this);
            loadOrdersCommand.Execute(0);
        }
    }
}
