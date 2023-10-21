using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Views;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Navigation
{
    public class OpenAddEmployeeCommand:CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public OpenAddEmployeeCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            AddEmployeeWindow window = new AddEmployeeWindow();

            window.Show();
        }
    }
}
