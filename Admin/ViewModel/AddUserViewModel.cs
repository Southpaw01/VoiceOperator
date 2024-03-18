using GalaSoft.MvvmLight.Command;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Admin.ViewModel
{
    public class AddUserViewModel : BaseViewModel
    {
        private User user = new User();

        #region User Properties

        public string FIO
        {
            get => user.FIO;
            set
            {
                user.FIO = value;
                OnPropertyChanged(nameof(FIO));
            }
        }

        public string Login
        {
            get => user.Login;
            set
            {
                user.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Pass
        {
            get => user.Pass;
            set
            {
                user.Pass = value;
                OnPropertyChanged(nameof(Pass));
            }
        }

        #endregion

        #region Commands

        public ICommand AddUserCommand => new RelayCommand(() =>
        {
            user.AddNewUserToDB();
            MessageBox.Show("Добавлено");
            user = new User();
        });

        #endregion
    }
}
