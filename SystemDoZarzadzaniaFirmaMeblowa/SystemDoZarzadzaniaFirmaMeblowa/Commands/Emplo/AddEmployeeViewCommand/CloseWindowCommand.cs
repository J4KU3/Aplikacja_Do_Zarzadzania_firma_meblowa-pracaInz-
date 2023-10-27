using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Views;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Emplo.AddEmployeeViewCommand
{
   public class CloseWindowCommand:CommandBase
    {
        private readonly AddEmployeeWindow _window;

        public CloseWindowCommand(AddEmployeeWindow window)
        {
            _window = window;
        }
        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            _window.Close();
        }
    }
}
