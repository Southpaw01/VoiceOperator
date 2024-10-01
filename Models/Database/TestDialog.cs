using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestDialog
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public int DialogId { get; set; }

        public bool IsProgFirst { get; set; }

        public string Name { get; set; }

        public List<Message> Messages { get; set; }
    }
}
