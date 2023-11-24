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
using SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.ComplaintsFolder;

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
        public DeleteOrderCommand deleteOrderCommand { get; }
        public EditOrderCommand editOrderCommand { get; }
        public SearchOrderCommand searchOrderCommand { get; }

        //
        //klienci
        public LoadClientsCommand loadClientsCommand { get; }
        public EditClientsCommand editClientsCommand { get; }
        public DeleteClientsCommand deleteClientsCommand { get; }
        //
        //Reklamacje
        public LoadComplaintsFromDataCommand loadComplaintsFromDataCommand { get; }
        public DeleteComplaintsCommand deleteComplaintsCommand { get; }
        //
        //Główne komendy
        public ChangeTabCommand changeTabCommand { get; }
        public LoginCommand loginCommand { get; }
        public ExitCommand exitCommand { get; }
        public OpenAddEmployeeCommand openEmployeeWidnowCommand { get; }
        public OpenClientsAddWindowCommand openClientsWindow { get; }
        //
        #endregion
        //Listy
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
                loadClientsCommand.OnCanExecuteChanged();
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
                loadComplaintsFromDataCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        #endregion
        //Zmienne 
        #region Zmienne
        //Pracownicy
        #region pracownicy

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
        #endregion
        //Zamowienia
        #region Zamówienia
        private OrdersModel _order;
        public OrdersModel ModelOrder
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }
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
                deleteOrderCommand.OnCanExecuteChanged();
                editOrderCommand.OnCanExecuteChanged();
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

        #endregion
        //klienci
        #region Klienci zmienne 
        private ClientsModel _selectedClient;
        public ClientsModel SelectedClient
        {
            get
            {
                return _selectedClient;
            }
            set
            {
                _selectedClient = value;
                editClientsCommand.OnCanExecuteChanged();
                deleteClientsCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        #endregion
        //Reklamacje
        private ComplaintsModel _complaintsModel;
        public ComplaintsModel ModelComplaints
        {
            get
            {
                return _complaintsModel;
            }
            set
            {
                _complaintsModel = value;
                OnPropertyChanged();
            }
        }
        private ComplaintsModel _selectedComplaint;
        public ComplaintsModel SelectedComplaints
        {
            get
            {
                return _selectedComplaint;
            }
            set
            {
                _selectedComplaint = value;
                deleteComplaintsCommand.OnCanExecuteChanged();
                OnPropertyChanged();
            }
        }
        //głowne zmienne 
        #region główne zmeinne 

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

        #endregion

        public MainViewModel()
        {
            //pracownicy
            _employee = new EmployeeModel(new Data.Employees());
            loadEmployeesCommand = new LoadEmployeesCommand(this);
            loadEmployeesCommand.Execute(0);
            employeeDeleteCommand = new EmployeeDeleteCommand(this);
            editEmployeeCommand = new EditEmployeeCommand(this);
            //głowne komendy 
            changeTabCommand = new ChangeTabCommand(this);
            loginCommand = new LoginCommand(this);
            exitCommand = new ExitCommand(this);
            openEmployeeWidnowCommand = new OpenAddEmployeeCommand(this);
            openClientsWindow = new OpenClientsAddWindowCommand(this);
            //Zamówienia
            _order = new OrdersModel(new Data.Orders());
            loadOrdersCommand = new LoadOrdersCommand(this);
            loadOrdersCommand.Execute(0);
            deleteOrderCommand = new DeleteOrderCommand(this);
            editOrderCommand = new EditOrderCommand(this);
            searchOrderCommand = new SearchOrderCommand(this);
            //Klienci
            loadClientsCommand = new LoadClientsCommand(this);
            loadClientsCommand.Execute(0);
            editClientsCommand = new EditClientsCommand(this);
            deleteClientsCommand = new DeleteClientsCommand(this);
            //Reklamacje
            loadComplaintsFromDataCommand = new LoadComplaintsFromDataCommand(this);
            loadComplaintsFromDataCommand.Execute(0);
            deleteComplaintsCommand = new DeleteComplaintsCommand(this);
        }
    }
}
