using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWIthDB
{
    public static class InsertData
    {
        public static void AddNewUser(User user)
        {
            string nameProc = "AddFighter";

            using (SqlConnection connection = new SqlConnection(ConnectionData.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(nameProc, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                #region Parameters
                SqlParameter sqlLogin = new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = user.Login
                };

                SqlParameter sqlPass = new SqlParameter
                {
                    ParameterName = "@Pass",
                    Value = user.Pass
                };
                SqlParameter sqlFIO = new SqlParameter
                {
                    ParameterName = "@FIO",
                    Value = user.FIO
                };
                #endregion

                command.Parameters.Add(sqlLogin);
                command.Parameters.Add(sqlPass);
                command.Parameters.Add(sqlFIO);

                command.ExecuteNonQuery();
            }
        }
    }
}
