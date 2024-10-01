using Models;
using Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoiceOperator.ViewModel
{
    public class StatsViewModel : BaseViewModel
    {

        private ObservableCollection<Test> testings;
        public ObservableCollection<DetailStatsViewModel> DetailStatsViewModels => new ObservableCollection<DetailStatsViewModel>(testings
             .Select(testing => new DetailStatsViewModel(testing)
             ));

        private DetailStatsViewModel selectedTesting = null;
        public DetailStatsViewModel SelectedTesting
        {
            get => selectedTesting;
            set
            {
                selectedTesting = value;
                OnPropertyChanged(nameof(SelectedTesting));
            }
        }


        public StatsViewModel()
        {
            DataStore.currentUser.GetAllTests();
            testings = new ObservableCollection<Test>(DataStore.currentUser.Tests);
        }


    }
}
