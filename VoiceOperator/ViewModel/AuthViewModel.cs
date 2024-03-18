using VoiceOperator.Speech;
using GalaSoft.MvvmLight.Command;
using Models;
using Models.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace VoiceOperator.ViewModel
{
    public class AuthViewModel : BaseViewModel
    {
        private User user = new User();

        #region User Properties

        public string Login
        {
            get => user.Login;
            set
            {
                user.Login = value;

                WarningVisibility = Visibility.Collapsed;

                OnPropertyChanged(nameof(Login));
            }
        }

        public string Pass
        {
            get => user.Pass;
            set
            {
                user.Pass = value;

                WarningVisibility = Visibility.Collapsed;

                OnPropertyChanged(nameof(Pass));
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get => new RelayCommand(
                () =>
                {

                    if (user.CheckAuth())
                    {
                        using (Context db = new Context())
                        {
                            user = db.Users.Where(u => u.Login == Login && u.Pass == Pass).ToList().First();
                        }
                        int n = user.Id;
                        DataStore.currentUser = user;
                        NavigateToAnotherPage(new StartViewModel());
                    }
                    else
                    {
                        WarningVisibility = Visibility.Visible;
                    }
                });
        }

        #endregion

        #region Warnings Visibility

        private Visibility warningVisibility = Visibility.Collapsed;
        public Visibility WarningVisibility
        {
            get => warningVisibility;
            set
            {
                warningVisibility = value;
                OnPropertyChanged(nameof(WarningVisibility));
            }
        }

        #endregion

        #region Navigation By Mediator

        private void NavigateToAnotherPage(object nextPage)
        {
            Mediator.ChangePage(this, new PageChangedEventArgs { NewPage = nextPage });
        }

        #endregion
    }
}
