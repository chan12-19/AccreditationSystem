using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Accreditation.Models;
using Microsoft.Data.SqlClient;


namespace Accreditation.Models
{
    public class Data
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

        public int RegisterCheck(AccUser accUser)
        {
            SqlCommand com = new SqlCommand("CheckUserRegister", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EMAIL", accUser.Email);
            com.Parameters.AddWithValue("@USER_ID", accUser.UserId);
            SqlParameter validRegister = new SqlParameter();
            validRegister.ParameterName = @"ISVALID";
            validRegister.SqlDbType = SqlDbType.Bit;
            validRegister.Direction = ParameterDirection.Output;
            com.Parameters.Add(validRegister);
            con.Open(); 
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(validRegister.Value);
            con.Close();
            return res;
        }

        public bool isValidEmail(string email)
        {
            var trimmedEmail = email.Trim();    
            if(trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public void AddRegisterUser(AccUser accUser, Role role)
        {
            try
            {
                SqlCommand com = new SqlCommand("RegisterUser", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@EMAIL", accUser.Email);
                com.Parameters.AddWithValue("@USER_ID", accUser.UserId);
                com.Parameters.AddWithValue("@PASSWORD", accUser.Password);
                com.Parameters.AddWithValue("@ROLEID", role.RoleId);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)

            {
            }
            

        }
    }


}
