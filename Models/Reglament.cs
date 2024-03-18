using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Reglament
    {
        #region EntityFramework

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DialogId { get; set; }
        public Dialog Dialog { get; set; }

        #endregion

        public string FirstCommand { get; set; } = "";

        public string SecondCommand { get; set; } = "";
    }
}
