using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDoZarzadzaniaFirmaMeblowa.Data;
using SystemDoZarzadzaniaFirmaMeblowa.Commands.BaseCommand;
using SystemDoZarzadzaniaFirmaMeblowa.ViewModels;
using System.Collections.ObjectModel;
using SystemDoZarzadzaniaFirmaMeblowa.Models;

namespace SystemDoZarzadzaniaFirmaMeblowa.Commands.ComplaintsFolder
{
   public class LoadComplaintsFromDataCommand:CommandBase
    {
        private readonly MainViewModel _mainViewModel;

        public LoadComplaintsFromDataCommand(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            using (var resource = new ZarzadzanieFirmaDBEntities())
            {
                List<Complaints> ComplaintsList = resource.Complaints.ToList();
                List<ComplaintsModel> convertedList = ComplaintsList.Select(c => new ComplaintsModel(c)).ToList();
                _mainViewModel.ListOfComplaints = new ObservableCollection<ComplaintsModel>(convertedList);
            }
        }
    }
}
