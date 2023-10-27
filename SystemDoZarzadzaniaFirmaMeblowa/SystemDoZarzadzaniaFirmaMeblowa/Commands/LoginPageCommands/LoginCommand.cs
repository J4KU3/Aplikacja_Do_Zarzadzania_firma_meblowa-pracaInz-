using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using System.Windows;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.LoginPageCommands
{
   public class LoginCommand:CommandBase
    {
        private readonly MainViewModel _mainviewmodel;

        public LoginCommand(MainViewModel mainViewModel)
        {
            _mainviewmodel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            if (_mainviewmodel.ModelEmployee.Mail != null && _mainviewmodel.ModelEmployee.Password !=null)
            {

                using (var Employees = new ZarzadzanieFirmaDBEntities())
                {
                    var employeMail = _mainviewmodel.ModelEmployee.Mail;
                    var employePass = _mainviewmodel.ModelEmployee.Password;
                    var found =  _mainviewmodel.ListOfEmployee.FirstOrDefault(x=>x.Mail == employeMail && x.Password== employePass );
                    if (found!=null)
                    {
                        _mainviewmodel.SelectedPage = 1;
                    }
                    else
                    {
                        MessageBox.Show("zostały podane błędne dane");
                    }

                }
            }
        }

        

    }
}
