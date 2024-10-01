using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Admin.ViewModel
{
    public class AddDialogViewModel : BaseViewModel
    {
        private Dialog dialog = new Dialog();

        #region Dialog Properties

        public ObservableCollection<ReglamentViewModel> Reglaments => new ObservableCollection<ReglamentViewModel>(dialog.Reglaments.Select(x => new ReglamentViewModel(x)));

    

        public string Description
        {
            get => dialog.Description;
            set
            {
                dialog.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string FirstRole
        {
            get => dialog.FirstRole;
            set
            {
                dialog.FirstRole = value;
                OnPropertyChanged(nameof(FirstRole));
            }
        }

        public string SecondRole
        {
            get => dialog.SecondRole;
            set
            {
                dialog.SecondRole = value;
                OnPropertyChanged(nameof(SecondRole));
            }
        }

        #endregion

        #region Commands

        public ICommand AddReglamentCommand => new RelayCommand(
            () => 
            {
                dialog.AddCommand(new Reglament());
                OnPropertyChanged(nameof(Reglaments)); 
            });

        public ICommand RemoveCommandsCommand => new RelayCommand<ReglamentViewModel>(
            param =>
            {
                dialog.RemoveCommand(param.commands);
                OnPropertyChanged(nameof(Reglaments));
            });

        public ICommand AddNewDialogCommand => new RelayCommand(() =>
        {
            dialog.AddNewDialogToDB();
            MessageBox.Show("Добавлено");
            dialog = new Dialog();
        });

        #endregion

        #region Constructor

        public AddDialogViewModel()
        {

        }

        #endregion

    }
}
