using Models.DialogParticipant;
using Models.Services;
using Models.Speech;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dialog
    {
        #region EntityFramework

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #endregion

        #region Properties

        [NotMapped]
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        [NotMapped]
        public List<Message> Messages { get; set; } = new List<Message>();

        [NotMapped]
        public string UserRole { get; set; } = "";

        public string FirstRole { get; set; } = "";

        public string SecondRole { get; set; } = "";

        private bool isProgFirst;

        [NotMapped]
        public bool IsProgFirst
        {
            get => isProgFirst;
            set
            {
                if (value)
                {
                    DialogParticipant = new ProgFirst(this);
                    UserRole = SecondRole;
                }
                else
                {
                    DialogParticipant = new UserFirst(this);
                    UserRole = FirstRole;
                }

                isProgFirst = value;
            }
        }

        [NotMapped]
        public int ExpectedScores => Reglaments.Count;

        [NotMapped]
        public int ActualScores => Messages.Where(m => m.Result == DataStore.trueAnswer).Count();

        public List<Reglament> Reglaments { get; set; } = new List<Reglament>();

        [NotMapped]
        public IDialogParticipant DialogParticipant { get; set; }

        #endregion

        public void AddNewDialogToDB()
        {
            using(Context db = new Context())
            {
                db.Dialogs.Add(this);
                db.SaveChanges();
            }
        }

        public void AddCommand(Reglament commands)
        {
            Reglaments.Add(commands);
        }

        public void RemoveCommand(Reglament commands)
        {
            Reglaments.Remove(commands);
        }
    }
}
