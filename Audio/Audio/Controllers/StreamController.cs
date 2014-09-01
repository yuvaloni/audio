using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
namespace Audio.Controllers
{
    public class StreamController : ApiController
    {
        public void PostStream(string name)
        {
            SqlConnection con = new SqlConnection("Data Source=83726fcf-046d-4c9e-95bc-a39900e6d74e.sqlserver.sequelizer.com;Initial Catalog=db83726fcf046d4c9e95bca39900e6d74e;Persist Security Info=True;User ID=mamskdoyvnbqsoqi;Password=Fk3pcCKcVk5DQDTaQ4v4vAB7zoex444PcNKTWufazz5nmdrtTd7VmS6eR4XWymg2");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM streams WHERE name=@n", con);
            com.Parameters.Add("@n", SqlDbType.NVarChar).Value = name;
            SqlDataReader r = com.ExecuteReader();
            if(r.Read())
            {
                r.Close();
                con.Close();
                return;
            }
            r.Close();
            SqlCommand com2 = new SqlCommand("INSERT INTO streams (name, [sample]) values (@n, ' ')",con);
            com2.Parameters.Add("@n", SqlDbType.NVarChar).Value = name;
            com2.ExecuteNonQuery();
            con.Close();
        }
        public void PutStream(string name, string sample)
        {
            SqlConnection con = new SqlConnection("Data Source=83726fcf-046d-4c9e-95bc-a39900e6d74e.sqlserver.sequelizer.com;Initial Catalog=db83726fcf046d4c9e95bca39900e6d74e;Persist Security Info=True;User ID=mamskdoyvnbqsoqi;Password=Fk3pcCKcVk5DQDTaQ4v4vAB7zoex444PcNKTWufazz5nmdrtTd7VmS6eR4XWymg2");
            con.Open();
            SqlCommand com = new SqlCommand("UPDATE streams SET [sample]=@s WHERE name=@n", con);
            com.Parameters.Add("@n", SqlDbType.NVarChar).Value = name;
            com.Parameters.Add("@s", SqlDbType.NVarChar).Value = sample;
            com.ExecuteNonQuery();
            con.Close();
        }
        public string GetStream(string name)
        {
            SqlConnection con = new SqlConnection("Data Source=83726fcf-046d-4c9e-95bc-a39900e6d74e.sqlserver.sequelizer.com;Initial Catalog=db83726fcf046d4c9e95bca39900e6d74e;Persist Security Info=True;User ID=mamskdoyvnbqsoqi;Password=Fk3pcCKcVk5DQDTaQ4v4vAB7zoex444PcNKTWufazz5nmdrtTd7VmS6eR4XWymg2");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM streams WHERE name=@n", con);
            com.Parameters.Add("@n", SqlDbType.NVarChar).Value = name;
            SqlDataReader r = com.ExecuteReader();
            string sample= null;
            if (r.Read())
                sample = r.GetString(1);
            r.Close();
            con.Close();
            return sample;
        }
    }
}
