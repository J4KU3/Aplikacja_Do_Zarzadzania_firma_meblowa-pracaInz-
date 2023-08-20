using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Data;

namespace SystemDoZarzadzaniaFirmaMeblowa.Models
{
    public class OrdersModel:Orders
    {
        public OrdersModel(Orders ordesToCopy)
        {
            OrderID = ordesToCopy.OrderID;
            ClientID = ordesToCopy.ClientID;
            employeeID = ordesToCopy.employeeID;
            OrderDate = ordesToCopy.OrderDate;
            ItemName = ordesToCopy.ItemName;
            ItemColor = ordesToCopy.ItemColor;
            Project = ordesToCopy.Project;
            Price = ordesToCopy.Price;

        }
    }
}
