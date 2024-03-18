using Models.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;

namespace Admin.ViewModel
{
    public class StatsViewModel : BaseViewModel
    {

        private List<Test> testings;
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

        private string userLogin = "";
        public string UserLogin
        {
            get => userLogin;
            set
            {
                userLogin = value;
                OnPropertyChanged(nameof(UserLogin));
            }
        }

        public ICommand FindUserCommand => new RelayCommand(
            () =>
            {
                using (Context db = new Context())
                {
                    User user = db.Users.Where(u => u.Login == userLogin).ToList().FirstOrDefault();

                    if (user != null)
                    {
                        testings = db.Tests.Where(t => t.UserId == user.Id).ToList();

                        if (testings == null)
                        {
                            testings = new List<Test>();
                        }
                    }
                    else testings = new List<Test>();

                }

                OnPropertyChanged(nameof(DetailStatsViewModels));
            });

        public StatsViewModel()
        {
            testings = new List<Test>();
        }
    }
}
