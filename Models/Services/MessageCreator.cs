using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public static class MessageCreator
    {
        public static Message GetProgMessage(string content)
        {
            return new Message()
            {
                From = DataStore.Prog,
                Content = content
            };
        }

        public static Message GetUserMessage(string content, string result)
        {
            return new Message()
            {
                From = DataStore.User,
                Content = content,
                Result = result
            };
        }
    }
}
