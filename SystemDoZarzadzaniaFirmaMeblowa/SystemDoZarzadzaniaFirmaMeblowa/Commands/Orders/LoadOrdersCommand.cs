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

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Orders
{
   public class LoadOrdersCommand:CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        public LoadOrdersCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            try
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                    List<Data.Orders> ordersList = resource.Orders.ToList();
                    var employeesList = resource.Employees.ToList();
                    var ClientsList = resource.Clients.ToList();
                    //List<OrdersModel> convertedList = ordersList.Select(x => new OrdersModel(x)).ToList();

                    var convertedList = ordersList.Select(order => new OrdersModel(order)
                    {
                        ClientFName = ClientsList
                        .Where(c => c.ClientID == order.ClientID)
                        .Select(c => c.CFName)
                        .FirstOrDefault(),

                        EmployeeFName = employeesList
                         .Where(e => e.employeeID == order.employeeID)
                         .Select(e => e.EFirstName)
                         .FirstOrDefault()
                    }).ToList();

                 


                    _mainViewModel.ListOfOrders = new ObservableCollection<OrdersModel>(convertedList);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
