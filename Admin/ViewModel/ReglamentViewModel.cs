using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.ViewModel
{
    public class ReglamentViewModel : BaseViewModel
    {
        public Reglament commands;

        #region Commands Properties

        public string FirstCommand
        {
            get => commands.FirstCommand;
            set
            {
                commands.FirstCommand = value;
                OnPropertyChanged(nameof(FirstCommand));
            }
        }

        public string SecondCommand
        {
            get => commands.SecondCommand;
            set
            {
                commands.SecondCommand = value;
                OnPropertyChanged(nameof(SecondCommand));
            }
        }

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public ReglamentViewModel(Reglament commands)
        {
            this.commands = commands;
        }

        #endregion
    }
}
