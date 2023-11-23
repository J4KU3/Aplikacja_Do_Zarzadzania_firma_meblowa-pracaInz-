using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Views;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ClientsFolder.AddClientsViewCommands
{
    public class CloseAddClientsWindow:CommandBase
    {
        private readonly AddClientView _viewModel;

        public CloseAddClientsWindow(AddClientView addClientsViewModel)
        {
            _viewModel = addClientsViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            _viewModel.Close();
        }
    }
}
