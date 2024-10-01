using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Models;
using VoiceOperator.Services;
using GalaSoft.MvvmLight.Command;
using Models.Services;
using System.Windows;

namespace VoiceOperator.ViewModel
{
    public class TestViewModel : BaseViewModel
    {
        private Test test;

        public object DialogViewModel => new DialogViewModel(test.CurrentDialog);

        public ICommand NextQuestionCommand => new RelayCommand(() =>
        {
            if (!test.NextDialog())
            {
                if (DataStore.currentMode == Mode.Test)
                {
                    test.SaveToDB();
                    NavigateToAnotherPage(new DetailStatsViewModel(test));
                }
                else NavigateToAnotherPage(new StartViewModel());
            }
            OnPropertyChanged(nameof(DialogViewModel));
        });

        public TestViewModel()
        {
            test = new Test();
            test.Start();
            OnPropertyChanged(nameof(DialogViewModel));
        }

        private void NavigateToAnotherPage(object nextPage)
        {
            Mediator.ChangePage(this, new PageChangedEventArgs { NewPage = nextPage });
        }
    }
}
