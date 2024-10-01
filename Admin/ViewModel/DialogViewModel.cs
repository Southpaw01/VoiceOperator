using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Admin.ViewModel
{
    public class DialogViewModel : BaseViewModel
    {
        protected Dialog dialog;

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

        #endregion

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

        #region Constructor

        public DialogViewModel(Dialog question)
        {
            this.dialog = question;
        }

        #endregion
    }

}

