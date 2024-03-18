using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Message
    {
        #region EntityFramework

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TestDialogId { get; set; }
        public TestDialog TestDialog { get; set; }

        #endregion

        public string From { get; set; } = "";

        public string Content { get; set; } = "";

        public string? Result { get; set; }

    }
}
