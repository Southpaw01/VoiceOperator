using Models;
using VoiceOperator.Speech;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Threading;
using System.Security.Cryptography;
using VoiceOperator.Services;
using Models.Services;

namespace VoiceOperator.ViewModel
{
    public class DialogViewModel : BaseViewModel
    {
        protected Dialog dialog;

        #region Commands

        private SpeechToText SpeechToText = new SpeechToText();
        public ICommand StartCommand => new RelayCommand(
            () =>
            {
                StartRecordEnabled = false;
                StopRecordEnabled = true;
                SendAnswerEnabled = false;

                 SpeechToText.StartRecord();
            });

        public ICommand StopCommand => new RelayCommand(
            () =>
            {
                StartRecordEnabled = true;
                StopRecordEnabled = false;
                SendAnswerEnabled = true;

               ActualUserAnswer = SpeechToText.GetAnswer();

            });

        public ICommand CheckAnswerCommand => new RelayCommand(
            () =>
            {
                StartRecordEnabled = true;
                StopRecordEnabled = false;
                SendAnswerEnabled = true;

                if (!dialog.DialogParticipant.CheckUserAnswer(ActualUserAnswer))
                {
                    IsEnabledAnswer = false;
                }

                try
                {
                    Help = dialog.DialogParticipant.ExpectedCommand;
                    HelpVisibility = "Collapsed";
                }
                catch
                {

                }


                OnPropertyChanged(nameof(Messages));

                ActualUserAnswer = "";
            });

        #endregion

        #region Dialog Properties

        public string Num
        {
            get => dialog.Name;
            set
            {
                dialog.Name = value;
                OnPropertyChanged(nameof(Num));
            }
        }

        public string Description
        {
            get => dialog.Description;
            set
            {
                dialog.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ObservableCollection<Models.Message> Messages => new ObservableCollection<Models.Message>(dialog.Messages);

        public string ActualScores => dialog.ActualScores.ToString();
        

        public string ExpectedScores => dialog.ExpectedScores.ToString();

        public string UserRole
        {
            get => dialog.UserRole;
            set
            {
                dialog.UserRole = value;
                OnPropertyChanged(nameof(UserRole));
            }
        }

        private string actualUserAnswer = "";
        public string ActualUserAnswer
        {
            get => actualUserAnswer;
            set
            {
                actualUserAnswer = value;
                OnPropertyChanged(nameof(ActualUserAnswer));
            }
        }

        #endregion

        #region Train Mode

        public ICommand HelpCommand => new RelayCommand(() => HelpVisibility = "Visible");

        private string help = "";
        public string Help
        {
            get => help;
            set
            {
                help = value;
                OnPropertyChanged(nameof(Help));
            }
        }

        private string helpVisibility = "Collapsed";
        public string HelpVisibility
        {
            get => helpVisibility;
            set
            {
                helpVisibility = value;
                OnPropertyChanged(nameof(HelpVisibility));
            }
        }

        private string helpStackVisibility = "Collapsed";
        public string HelpStackVisibility
        {
            get => helpStackVisibility;
            set
            {
                helpStackVisibility = value;
                OnPropertyChanged(nameof(HelpStackVisibility));
            }
        }

        #endregion

        #region Visibility And Enabled Properties

        private bool isEnabledAnswer = true;
        public bool IsEnabledAnswer
        {
            get => isEnabledAnswer;
            set
            {
                isEnabledAnswer = value;
                OnPropertyChanged(nameof(IsEnabledAnswer));
            }
        }

        private string detailQuestionVisibility = "Collapsed";
        public string DetailQuestionVisibility
        {
            get => detailQuestionVisibility;
            set
            {
                detailQuestionVisibility = value;
                OnPropertyChanged(nameof(DetailQuestionVisibility));
            }
        }

        private bool startRecordEnabled = true;
        public bool StartRecordEnabled
        {
            get => startRecordEnabled;
            set
            {
                startRecordEnabled = value;
                OnPropertyChanged(nameof(StartRecordEnabled));
            }
        }

        private bool stopRecordEnabled = false;
        public bool StopRecordEnabled
        {
            get => stopRecordEnabled;
            set
            {
                stopRecordEnabled = value;
                OnPropertyChanged(nameof(StopRecordEnabled));
            }
        }

        private bool sendAnswerEnabled = true;
        public bool SendAnswerEnabled
        {
            get => sendAnswerEnabled;
            set
            {
                sendAnswerEnabled = value;
                OnPropertyChanged(nameof(SendAnswerEnabled));
            }
        }

        #endregion

        #region Constructor

        public DialogViewModel(Dialog question)
        {
            switch(DataStore.currentMode)
            {
                case Mode.Train: HelpStackVisibility = "Visible";
                    Help = question.DialogParticipant.ExpectedCommand;
                    break;
            }

            this.dialog = question;
        }

        #endregion
    }
}
