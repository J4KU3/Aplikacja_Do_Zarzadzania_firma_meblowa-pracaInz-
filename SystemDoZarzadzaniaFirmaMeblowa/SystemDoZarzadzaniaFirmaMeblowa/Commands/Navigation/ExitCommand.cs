﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Navigation
{
    public class ExitCommand:CommandBase
    {
        private readonly MainViewModel _mainviewmodel;

        public ExitCommand(MainViewModel mainViewModel)
        {
            _mainviewmodel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            App.Current.Shutdown();
        }
    }
}