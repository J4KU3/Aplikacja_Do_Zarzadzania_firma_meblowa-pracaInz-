using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.Views;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder.ClientsWindowCommands
{
    public class ExitClientsWindowCommand:CommandBase
    {
        private readonly ClientsView _viewModel;

        public ExitClientsWindowCommand(ClientsView ClientsViewModel)
        {
            _viewModel = ClientsViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            _viewModel.Close();
        }
    }
}
