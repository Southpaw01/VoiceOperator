using VoiceOperator.Speech;
using VoiceOperator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VoiceOperator.View
{
    /// <summary>
    /// Логика взаимодействия для ProgFirstView.xaml
    /// </summary>
    public partial class QuestionView : UserControl
    {
        public QuestionView()
        {
            InitializeComponent();
        }

        private DialogViewModel QuestionViewModel => DataContext as DialogViewModel;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //string text = QuestionViewModel.Messages.Last().Content;

            //await Task.Run(() =>
            //{
            //    Thread.Sleep(5);
            //    new TextToSpeech().Speak(text);
            //});
        }
   
    }
}
