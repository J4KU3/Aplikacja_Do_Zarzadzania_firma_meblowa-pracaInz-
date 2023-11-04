using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;


namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Orders
{
    public class DeleteOrderCommand:CommandBase
    {
        private readonly MainViewModel _mainViewModel;
        public DeleteOrderCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _mainViewModel.SelectedOrder != null;
        }
        public override void Execute(object parameter)
        {
            try
            {
                using (var OrderToDelete = new  ZarzadzanieFirmaDBEntities())
                {
                    var order = OrderToDelete.Orders.FirstOrDefault(o => o.OrderID == _mainViewModel.SelectedOrder.OrderID);
                    if (order !=null)
                    {
                        OrderToDelete.Orders.Remove(order);
                        OrderToDelete.SaveChanges();
                        _mainViewModel.loadOrdersCommand.Execute(0);
                    }



                }

            }
            catch (Exception)
            {
                MessageBox.Show("Żadne zamówienie nie zostało wybrane");
            }
        }
    }
}
