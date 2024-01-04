using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using System.Collections.ObjectModel;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Orders
{
    public class SearchOrderCommand : CommandBase
    {
        private readonly MainViewModel _mainviewmodel;

        public SearchOrderCommand(MainViewModel mainViewModel)
        {
            _mainviewmodel = mainViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            if (_mainviewmodel.ModelOrder.ItemName != "" && _mainviewmodel.ModelOrder.ItemName != null)
            {
                using (var resource = new ZarzadzanieFirmaDBEntities())
                {
                    List<Data.Orders> Orders = resource.Orders.ToList();
                    var employeesList = resource.Employees.ToList();
                    var ClientsList = resource.Clients.ToList();

                    var searchOrders = Orders.Where(o => o.ItemName == _mainviewmodel.ModelOrder.ItemName);

                    var convertedList = searchOrders.Select(order => new OrdersModel(order)
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

                    _mainviewmodel.ListOfOrders = new ObservableCollection<OrdersModel>(convertedList);
                }
            }
            else
            {
                _mainviewmodel.loadOrdersCommand.Execute(0);
            }
            
        }
    }
}
