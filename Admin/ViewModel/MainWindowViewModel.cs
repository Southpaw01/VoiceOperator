using Admin.Services;
using GalaSoft.MvvmLight.Command;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Admin.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Navigation

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get => selectedViewModel;
            set 
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        private void NavigateToAnotherPage(object nextPage)
        {
            Mediator.ChangePage(this, new PageChangedEventArgs { NewPage = nextPage });
        }

        private void OnPageChanged(object sender, PageChangedEventArgs e)
        {
            SelectedViewModel = e.NewPage;
        }

        #endregion

        #region Commands

        public ICommand AddSituationCommand => new RelayCommand(
            () => NavigateToAnotherPage(new AddDialogViewModel()));

        public ICommand AddUserCommand => new RelayCommand(
            () => NavigateToAnotherPage(new AddUserViewModel()));

        public ICommand StatsCommand => new RelayCommand(
            () => NavigateToAnotherPage(new StatsViewModel()));

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            Mediator.PageChanged += OnPageChanged;

            //using (Context db = new Context())
            //{
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();
            //}
        }

        #endregion
    }
}
