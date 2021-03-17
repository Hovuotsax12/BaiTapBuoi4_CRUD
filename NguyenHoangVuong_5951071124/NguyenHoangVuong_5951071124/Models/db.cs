using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NguyenHoangVuong_5951071124.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-DQ9LSA83\SQLEXPRESS;Initial Catalog=DemoCRUD;Integrated Security=True");
        
        //select
        public DataSet Empget(Employee emp,out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("@STATE", emp.STATE);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch(Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }
        //insert và update
        public string Empdml(Employee emp, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Sp_Employee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Sr_no", emp.Sr_no);
                com.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                com.Parameters.AddWithValue("@STATE", emp.STATE);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@Country", emp.Country);
                com.Parameters.AddWithValue("@Department", emp.Department);
                com.Parameters.AddWithValue("@flag", emp.flag);
                SqlDataAdapter da = new SqlDataAdapter(com);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if(con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }
    }
}
