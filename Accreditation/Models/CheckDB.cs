using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Accreditation.Models;
using Microsoft.Data.SqlClient;


namespace Accreditation.Models
{
    public class CheckDB
    {


        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Accreditation;Integrated Security=True; Encrypt= False");
        public int LoginCheck(AccUser accountuser)
        {
            SqlCommand com = new SqlCommand("CheckUserLogin", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@USER_ID", accountuser.UserId);
            com.Parameters.AddWithValue("@PASSWORD", accountuser.Password);
            SqlParameter validLogin = new SqlParameter();
            validLogin.ParameterName = "@ISVALID";
            validLogin.SqlDbType = SqlDbType.Bit;
            validLogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(validLogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(validLogin.Value);
            con.Close();
            return res;
        }
    }
}
