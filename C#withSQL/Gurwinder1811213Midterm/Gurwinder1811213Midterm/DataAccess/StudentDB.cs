using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Gurwinder1811213Midterm.Business;
using System.Data;

namespace Gurwinder1811213Midterm.DataAccess
{
    public static class StudentDB
    {
        public static SqlConnection conndb = UtilityDB.connectDB();
        public static SqlCommand cmd = new SqlCommand();

        public static bool AddStudents(Student student)
        {
            try
            {
                if (conndb.State == ConnectionState.Closed)
                {
                    conndb = UtilityDB.connectDB();
                    cmd = new SqlCommand();

                }
                cmd.Connection = conndb;
                cmd.CommandText = string.Format("insert into Students (FirstName,LastName,PhoneNumber) values('{0}','{1}','{2}')", student.FirstName, student.LastName, student.PhoneNumber);
                cmd.ExecuteNonQuery();
                conndb.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static DataTable DisplayStudents()
        {
            DataTable datatable = new DataTable();
            try
            {
                if (conndb.State == ConnectionState.Closed)
                {
                    conndb = UtilityDB.connectDB();
                    cmd = new SqlCommand();

                }
                cmd.Connection = conndb;
                cmd.CommandText = "select * from Students";
                SqlDataReader reader = cmd.ExecuteReader();
                datatable.Load(reader);
                reader.Close();
                cmd.Dispose();
                conndb.Close();
                 }
            catch (Exception)
            {

            }
            return datatable;
        }

        public static bool UpdateStudents(Student student)
        {
            try
            {
                if (conndb.State == ConnectionState.Closed)
                {
                    conndb = UtilityDB.connectDB();
                    cmd = new SqlCommand();
                }
                cmd.Connection = conndb;
                cmd.CommandText = string.Format("update Students set FirstName='{0}' , LastName ='{1}', PhoneNumber = '{2}' where StudentNumber ={3}", student.FirstName, student.LastName, student.PhoneNumber, student.StudentNumber);
                cmd.ExecuteNonQuery();
                conndb.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static DataTable SearchStudents(Student student)
        {
            if (conndb.State == ConnectionState.Closed)
            {
                conndb = UtilityDB.connectDB();
                cmd = new SqlCommand();
            }
            cmd.Connection = conndb;
            cmd.CommandText = string.Format("Select * from Students where FirstName='{0}' or PhoneNumber='{1}'", student.FirstName, student.PhoneNumber);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            cmd.Dispose();
            conndb.Close();
            return dt;

        }
    }
}
