using VoiceOperator.Services;
using GalaSoft.MvvmLight.Command;
using Models;
using Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace VoiceOperator.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Commands

        public ICommand StartCommand => new RelayCommand(() => NavigateToAnotherPage(new StartViewModel()));

        public ICommand StatsCommand => new RelayCommand(() => NavigateToAnotherPage(new StatsViewModel()));

        #endregion

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

        private void OnPageChanged(object sender, PageChangedEventArgs e)
        {
            SelectedViewModel = e.NewPage;
        }

        private void NavigateToAnotherPage(object nextPage)
        {
            Mediator.ChangePage(this, new PageChangedEventArgs { NewPage = nextPage });
        }

        #endregion

        #region Constructor

        public MainWindowViewModel()
        {
            Mediator.PageChanged += OnPageChanged;
            NavigateToAnotherPage(new AuthViewModel());
        }

        #endregion
    }
}
