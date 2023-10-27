using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Data;

namespace SystemDoZarzadzaniaFirmaMeblowa.Models
{
    public class EmployeeModel:Employees
    {
        public EmployeeModel(Employees employeesToCopy)
        {
            employeeID = employeesToCopy.employeeID;
            EFirstName = employeesToCopy.EFirstName;
            ELastName = employeesToCopy.ELastName;
            Phone = employeesToCopy.Phone;
            Mail = employeesToCopy.Mail;
            Password = employeesToCopy.Password;
            IsAdmin = employeesToCopy.IsAdmin;
        }
    }
}
