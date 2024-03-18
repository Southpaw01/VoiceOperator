using Models.Services;
using Models.Speech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IDialogParticipant
    {
        public void StartDialog();

        public bool CheckUserAnswer(string content);

        public string ExpectedCommand { get; }
    }
}
