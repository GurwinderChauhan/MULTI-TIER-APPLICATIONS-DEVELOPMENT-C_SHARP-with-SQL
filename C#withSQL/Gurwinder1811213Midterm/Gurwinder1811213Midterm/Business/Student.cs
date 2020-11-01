using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gurwinder1811213Midterm.DataAccess;
using System.Data;

namespace Gurwinder1811213Midterm.Business
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string FirstName {get; set;}
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public DataTable DisplayStudents()
        {
            return StudentDB.DisplayStudents();

        }

        public bool AddStudents(Student student)
        {
            return StudentDB.AddStudents(student);
        }

        public bool UpdateStudents(Student student)
        {
            return StudentDB.UpdateStudents(student);
        }

        public DataTable SearchStudent(Student student)
        {
            return StudentDB.SearchStudents(student);

        }

    }
}
