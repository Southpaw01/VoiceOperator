using System.Windows.Controls;
using System.Windows;
using VoiceOperator.ViewModel;
using System.Linq;
using Models;
using Models.Services;

namespace VoiceOperator.Services
{
    internal class MessageSelector : DataTemplateSelector
    {
        public DataTemplate UserMessageTemplate { get; set; }
        public DataTemplate ProgMessageTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Message message = (Message)item;
            if (message.From == DataStore.Prog)
                return ProgMessageTemplate;
            else
                return UserMessageTemplate;
        }
    }
}
