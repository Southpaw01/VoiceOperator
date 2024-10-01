using VoiceOperator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VoiceOperator.Services
{
    internal class DetailStatsSelector : DataTemplateSelector
    {
        public DataTemplate EmptyDataTemplate { get; set; }
        public DataTemplate DetailStatsDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //  DetailStatsViewModel stats = (DetailStatsViewModel)item;
            //if (stats != null)
            //    return DetailStatsDataTemplate;
            //else
            //    return EmptyDataTemplate;
            return null;
        }
    }
}
