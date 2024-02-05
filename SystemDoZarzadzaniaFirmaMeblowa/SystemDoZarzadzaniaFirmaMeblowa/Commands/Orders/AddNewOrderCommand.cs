using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.Models;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;


namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Orders
{
    public class AddNewOrderCommand:CommandBase
    {
        private readonly MainViewModel _mainviewModel;

        public AddNewOrderCommand(MainViewModel mainViewModel)
        {
            _mainviewModel = mainViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            using (var Order = new ZarzadzanieFirmaDBEntities())
            {
                var newORder = _mainviewModel.OrderToData;
                if (newORder.ItemName != null && _mainviewModel.SelectedClientFromList != null && newORder.ItemColor != null && newORder.Price != null)
                {
                    var neworder = new Data.Orders
                    {
                        ItemName = newORder.ItemName,
                        ItemColor = newORder.ItemColor,
                        ClientID = _mainviewModel.SelectedClientFromList.ClientID,
                        Price = newORder.Price,
                        Project = newORder.Project,
                        OrderDate = _mainviewModel.ActualDate.Date,
                        employeeID = _mainviewModel.ModelEmployee.employeeID
                        
                    };
                    Order.Orders.Add(neworder);
                    Order.SaveChanges();
                    MessageBox.Show("Dodano nowe zamówienie ");
                    _mainviewModel.SelectedClientFromList = null;
                   _mainviewModel.OrderToData.ItemName = null;
                    _mainviewModel.OrderToData.ItemColor = null;
                    
                    _mainviewModel.OrderToData.Price = null;
                    _mainviewModel.OrderToData.Project = null;
                    
                    _mainviewModel.SelectedPage = 1;

                }
                else
                {
                    MessageBox.Show("jakas dana nie zostala wpisana ");
                }

            }
            _mainviewModel.loadOrdersCommand.Execute(0);
           
        }
    }
    
}
