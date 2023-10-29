using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Raports
{
    public class CreateRaportsCommand:CommandBase
    {
        private readonly MainViewModel _mainviewModel;

        public CreateRaportsCommand(MainViewModel mainViewModel)
        {
            _mainviewModel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
