using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using System.Windows;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.Navigation
{
   public class ChangeTabCommand:CommandBase
    {
        private readonly MainViewModel _mainviewmodel;

        public ChangeTabCommand(MainViewModel mainViewModel)
        {
            _mainviewmodel = mainViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            if (_mainviewmodel.SelectedPage==2)
            {
                if (!CheckAdmin())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("nie posiadasz funkcji admina");
                    _mainviewmodel.SelectedPage=1;
                }
                
            }
            else
            {
                return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            _mainviewmodel.SelectedPage = int.Parse(parameter as string);
        }

        private bool CheckAdmin()
        {
            using (var context = new Data.ZarzadzanieFirmaDBEntities())
            {
                var employee = context.Employees.FirstOrDefault(e => e.Mail == _mainviewmodel.ModelEmployee.Mail && e.Password ==_mainviewmodel.ModelEmployee.Password && e.IsAdmin == _mainviewmodel.ISAdmin);
                return employee != null;
            }
        }

    }
}
