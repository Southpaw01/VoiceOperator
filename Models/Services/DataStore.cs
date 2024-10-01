using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public static class DataStore
    {
        public static User currentUser = new Models.User();

        public static Mode currentMode = Mode.Test;

        public const int Ball = 1;

        public const string trueAnswer = "верно";
        public const string wrongAnswer = "не верно";

        public const string Prog = "Prog";
        public const string User = "User";


        public static Test testTesting = new Test()
        {
            Name = "Тест 1",
            Dialogs = new List<Dialog>()
            {
                new Dialog()
                {
                    Reglaments = new List<Reglament>()
                    {
                        new Reglament()
                        {
                            FirstCommand = "привет",
                            SecondCommand = "привет"
                        },
                        new Reglament()
                        {
                            FirstCommand = "как дела",
                            SecondCommand = "нормально"
                        }
                    },
                    Description = "Тест проги",
                    Name = "Ситуация 1"
                },

                new Dialog()
                {
                    Reglaments = new List<Reglament>()
                    {
                        new Reglament()
                        {
                            FirstCommand = "привет",
                            SecondCommand = "привет"
                        },
                        new Reglament()
                        {
                            FirstCommand = "как дела",
                            SecondCommand = "нормально"
                        }
                    },
                    Description = "Тест проги",
                    Name = "Ситуация 2"
                }
            },

        };

        public static ObservableCollection<Test> testings = new ObservableCollection<Test>();

    }

    public enum Mode
    {
        Train,
        Test
    }
}
