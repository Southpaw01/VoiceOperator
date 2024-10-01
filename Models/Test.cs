using Microsoft.EntityFrameworkCore;
using Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Test
    {
        #region EntityFramework

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        #endregion

        public string Name { get; set; }

        [NotMapped]
        public List<Dialog>? Dialogs { get; set; }

        [NotMapped]
        public Dialog CurrentDialog { get; set; }

        [NotMapped]
        public int ExpectedScores
        {
            get
            {
                int sum = 0;
                if (Dialogs != null)
                Dialogs.ForEach(question => sum += question.ExpectedScores);
                return sum;
            }
        }

        [NotMapped]
        public int ActualScores
        {
            get
            {
                int sum = 0;
                if (Dialogs != null)
                Dialogs.ForEach(question => sum += question.ActualScores);
                return sum;
            }
        }

        private int currentDialogNum = 0;

        public void GetStats()
        {
            using (Context db = new Context())
            {
                var testDialogs = db.TestDialog.Where(t => t.TestId == Id).ToList();

                List<Dialog> dialogs = new List<Dialog>();
                for (int i = 0; i < testDialogs.Count; i++)
                {
                    dialogs.Add(db.Dialogs.Where(d => d.Id == testDialogs[i].DialogId).Include(t => t.Reglaments).ToList().First());

                    dialogs.Last().Messages = db.Messages.Where(m => m.TestDialogId == testDialogs[i].Id).ToList();

                    dialogs.Last().Name = testDialogs[i].Name;

                    dialogs.Last().IsProgFirst = testDialogs[i].IsProgFirst;
                }

                Dialogs = dialogs;

            }
        }

        public void GetAllDialogsFromDB()
        {
            using (Context db = new Context())
            {
                Dialogs = db.Dialogs.Include(d => d.Reglaments).ToList();
            }

            bool isProgFirst = true;
            for(int i = 0; i < Dialogs.Count; i++)
            {
                Dialogs[i].IsProgFirst = isProgFirst;
                isProgFirst = !isProgFirst;

                Dialogs[i].Name = "Диалог " + (i + 1).ToString();
            }
        }

        public void SaveToDB()
        {
            using (Context db = new Context())
            {
                UserId = DataStore.currentUser.Id;

                db.Tests.Add(this);

                for (int i = 0; i < Dialogs.Count; i++)
                {
                    db.TestDialog.Add(
                        new TestDialog()
                        {
                            DialogId = Dialogs[i].Id,
                            Test = this,
                            IsProgFirst = Dialogs[i].IsProgFirst,
                            Name = Dialogs[i].Name,
                            Messages = Dialogs[i].Messages
                        });
                }

                db.SaveChanges();
            }
        }

        public void SetName()
        {
            using (Context db = new Context())
            {
                int CountUserTests = db.Tests.Where(u => u.Id == DataStore.currentUser.Id).ToList().Count;

                Name = "Тест " + (CountUserTests + 1).ToString(); 
            }
        }

        public bool NextDialog()
        {
            currentDialogNum++;

            if (currentDialogNum >= Dialogs.Count)
            {
                return false;
            }

            CurrentDialog = Dialogs[currentDialogNum];

            return true;
        }

        public void Start()
        {
            SetName();

            GetAllDialogsFromDB();

            CurrentDialog = Dialogs.First();

            CurrentDialog.DialogParticipant.StartDialog();
        }
    }
}
