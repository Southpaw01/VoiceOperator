using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Services
{
    public static class Mediator
    {
        public static event EventHandler<PageChangedEventArgs> PageChanged;

        public static void ChangePage(object sender, PageChangedEventArgs e)
        {
            PageChanged?.Invoke(sender, e);
        }
    }

    public class PageChangedEventArgs : EventArgs
    {
        public object NewPage { get; set; }
    }
}
