using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWIthDB
{
    public class GetData
    {
        public static void GetUsersByLogin(User user)
        {
            string nameProc = "GetUsersByLogin";

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
                #endregion

                command.Parameters.Add(sqlLogin);

                command.ExecuteNonQuery();
            }
        }

        public static void AuthUser()
        {

        }
    }
}
