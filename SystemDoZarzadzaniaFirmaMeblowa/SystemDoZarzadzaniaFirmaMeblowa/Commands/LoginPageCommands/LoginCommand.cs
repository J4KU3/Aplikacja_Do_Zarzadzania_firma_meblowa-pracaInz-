using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;

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
            
        }

    }
}
