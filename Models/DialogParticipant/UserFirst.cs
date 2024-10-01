using FuzzySharp;
using Models.Services;
using Models.Speech;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DialogParticipant
{
    public class UserFirst : IDialogParticipant
    {
        private TextToSpeech TextToSpeech = new();

        private Dialog question;

        private int k = 0;

        public string ExpectedCommand => question.Reglaments[k].FirstCommand;

        public async void AddProgMessage()
        {
            Message message = new Message();
            message.From = DataStore.Prog;
            message.Content = question.Reglaments[k].SecondCommand;
            question.Messages.Add(message);

            await Task.Run(() => TextToSpeech.Speak(message.Content));
        }

        public void AddProgMessage(string content)
        {
            Message message = new Message();
            message.From = DataStore.Prog;
            message.Content = content;

            question.Messages.Add(message);
        }

        private void AddUserMessage(string content, string result)
        {
            question.Messages.Add(new Message()
            {
                Content = content,
                Result = result,
                From = DataStore.User
            });
        }

        public void StartDialog()
        {

        }

        private bool NextCommand()
        {
            k++;

            if (question.Reglaments.Count == k)
                return false;

            return true;
        }

        public bool CheckUserAnswer(string content)
        {
            switch (DataStore.currentMode)
            {
                case Mode.Test:
                    return CheckInTestMode(content);
                case Mode.Train:
                    return CheckInTrainMode(content);
                default: return false;
            }
        }

        private bool CheckInTestMode(string content)
        {
            if (Fuzz.Ratio(ExpectedCommand, content) >= 90)
            {
                AddUserMessage(content, DataStore.trueAnswer);
                AddProgMessage();
            }
            else
            {
                AddUserMessage(content, DataStore.wrongAnswer);
                AddProgMessage("ожидаемый ответ: " + ExpectedCommand);
                AddProgMessage();
            }

            return NextCommand();
        }

        private bool CheckInTrainMode(string content)
        {
            if (Fuzz.Ratio(ExpectedCommand, content) >= 90)
            {
                AddUserMessage(content, DataStore.trueAnswer);
                AddProgMessage();
                return NextCommand();
            }
            else
            {
                AddUserMessage(content, DataStore.wrongAnswer);
                AddProgMessage("неправильная команда");
            }

            return true;
        }

        public UserFirst(Dialog question)
        {
            this.question = question;
        }
    }
}
