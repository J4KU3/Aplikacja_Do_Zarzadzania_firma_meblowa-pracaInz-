using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using System.Windows;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Orders
{
   public class EditOrderCommand:CommandBase
    {
        private readonly MainViewModel _mainviewModel;
        public EditOrderCommand(MainViewModel mainViewModel)
        {
            _mainviewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _mainviewModel.SelectedOrder != null;
        }
        public override void Execute(object parameter)
        {
            try
            {
                using (var OrderToEdit = new ZarzadzanieFirmaDBEntities())
                {
                    var order = OrderToEdit.Orders.FirstOrDefault(o => o.OrderID == _mainviewModel.SelectedOrder.OrderID);
                    var selectedOrder = _mainviewModel.SelectedOrder;
                    if (order != null)
                    {
                        order.ClientID =selectedOrder.ClientID;
                        order.employeeID = selectedOrder.employeeID;
                        order.ItemColor = selectedOrder.ItemColor;
                        order.ItemName = selectedOrder.ItemName;
                        order.OrderDate = selectedOrder.OrderDate;
                        order.Price = selectedOrder.Price;
                        order.Project = selectedOrder.Project;
                        OrderToEdit.SaveChanges();
                        MessageBox.Show($"Zamówienie o id:{order.OrderID} zostało edytowane ");
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
