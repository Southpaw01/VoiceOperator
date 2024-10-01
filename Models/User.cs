using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        #region EntityFramework

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<Test> Tests { get; set; }

        #endregion

        #region Database Manipulations

        public void AddNewUserToDB()
        {
            using(Context db = new Context())
            {
                db.Users.Add(this);
                db.SaveChanges();
            }
        }

        public bool CheckAuth()
        {
            using(Context db = new Context())
            {
                if (db.Users.Where(u => u.Login == Login && u.Pass == Pass).ToList().FirstOrDefault() != null)
                {
                    return true;
                }
                else return false;
            }
        }

        public void GetAllTests()
        {
            using(Context db = new Context())
            {
                Tests = db.Tests.Where(t => t.UserId == Id).ToList();
            }
        }

        #endregion

        #region User Properties

        public string Login { get; set; } = "PetrovIV";

        public string Pass { get; set; } = "1";

        public string FIO { get; set; }

        #endregion
    }
}
