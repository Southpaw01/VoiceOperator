using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;

namespace VoiceOperator.ViewModel
{
    public class DetailStatsViewModel : BaseViewModel
    {
        private Test testing;

        public string Name => testing.Name;

        public string ExpectedScores => testing.ExpectedScores.ToString();

        public string ActualScores => testing.ActualScores.ToString();


        public ObservableCollection<DialogViewModel> DialogsViewModel => new ObservableCollection<DialogViewModel>(testing.Dialogs.Select(
            dialog => new DialogViewModel(dialog)));

        public DetailStatsViewModel(Test testing)
        {
            this.testing = testing;

            testing.GetStats();
        }
    }
}
