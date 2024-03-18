using VoiceOperator.Services;
using GalaSoft.MvvmLight.Command;
using Models.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Xps.Serialization;

namespace VoiceOperator.ViewModel
{
    public class StartViewModel : BaseViewModel
    {
        private bool isTesting = false;
        public bool IsTesting
        {
            get => isTesting;
            set
            {
                if (!value && !IsTraining)
                    return;

                isTesting = value;

                if (IsTraining && value)
                    IsTraining = false;

                IsCanStart = true;
                DataStore.currentMode = Mode.Test;

                OnPropertyChanged(nameof(IsTesting));
            }
        }

        private bool isTraining = false;
        public bool IsTraining
        {
            get => isTraining;
            set
            {
                if (!value && !IsTesting)
                    return;

                isTraining = value;

                if (IsTesting && value)
                    IsTesting = false;

                IsCanStart = true;
                DataStore.currentMode = Mode.Train;

                OnPropertyChanged(nameof(IsTraining));
            }
        }

        private bool isCanStart = false;
        public bool IsCanStart
        {
            get => isCanStart;
            set
            {
                isCanStart = value;
                OnPropertyChanged(nameof(IsCanStart));
            }
        }

        public ICommand StartCommand => new RelayCommand(() => NavigateToTestingPage(new TestViewModel()));

        private void NavigateToTestingPage(object nextPage)
        {
            Mediator.ChangePage(this, new PageChangedEventArgs { NewPage = nextPage });
        }

    }
}
