using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;

namespace ADOCRUD1.Models
{
    public class EmployeedataAccess
    {
        DBconnection Dbconnection;
        public EmployeedataAccess()
        {
            Dbconnection  = new DBconnection();

        }
        public List<Emplyoees> GetEmployees()
        {

            string sp = "sp_Employee";
            SqlCommand sql = new SqlCommand(sp, Dbconnection.Connection);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@action", "SELECT_JOIN");
            if (Dbconnection.Connection.State == ConnectionState.Closed)
            {
                Dbconnection.Connection.Open();
            }
            
            SqlDataReader dr = sql.ExecuteReader();
            List<Emplyoees> emplyoees = new List<Emplyoees>();
            while (dr.Read())
            {
                Emplyoees Emp = new Emplyoees();
                Emp.ID = (int)dr["ID"];
                Emp.name = dr["name"].ToString();
                Emp.email = dr["email"].ToString();
                Emp.mobile = dr["mobile"].ToString();
                Emp.gender = dr["Gender"].ToString();
                Emp.Dept_name = dr["Name"].ToString();
                emplyoees.Add(Emp);                
            }
            Dbconnection.Connection.Close();
            return emplyoees;
        }
    }
}


           


    

