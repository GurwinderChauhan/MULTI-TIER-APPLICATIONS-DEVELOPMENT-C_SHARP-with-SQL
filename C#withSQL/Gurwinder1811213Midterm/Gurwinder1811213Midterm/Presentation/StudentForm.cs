using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gurwinder1811213Midterm.Business;
using Gurwinder1811213Midterm.DataAccess;

namespace Gurwinder1811213Midterm
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'demoDataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.demoDataSet.Students);
            StudentlistView.FullRowSelect = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ( txtFirstName.Text == "" || txtLastName.Text == "" ||
               txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Student cannot be empty!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Student student = new Student();
                //student.StudentNumber = Convert.ToInt32(txtStudentNumber.Text);
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.PhoneNumber = txtPhoneNumber.Text;

                if (student.AddStudents(student))
                {
                    MessageBox.Show("Record is added successfully!");

                }
                else
                {
                    MessageBox.Show("Record is not added!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnRefress_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            StudentdataGridView.DataSource = StudentDB.DisplayStudents();
            txtStudentNumber.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtStudentNumber.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" ||
                txtPhoneNumber.Text == "")
            {
                MessageBox.Show("Record is not updated!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Student emp = new Student();
                emp.StudentNumber = Convert.ToInt32(txtStudentNumber.Text);
                emp.FirstName = txtFirstName.Text;
                emp.LastName = txtLastName.Text;
                emp.PhoneNumber = txtPhoneNumber.Text;

                if (emp.UpdateStudents(emp))
                {
                    MessageBox.Show("Updated is sucessfull!");

                }
                else
                {
                    MessageBox.Show("Not Updated !", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchFirst.Text == "" && txtSearchPhone.Text == "")
            {
                MessageBox.Show("Search is cannot be empty!");
            }
            else
            {
                Student student = new Student();
                if (txtSearchPhone.Text == "")
                {
                    student.FirstName = txtSearchFirst.Text;
                }
                else
                {
                    student.PhoneNumber = txtSearchPhone.Text;

                }

                var dt = student.SearchStudent(student);


                if (dt.Rows.Count > 0)
                {
                    StudentdataGridView.DataSource = student.SearchStudent(student);
                }
                else
                {
                    MessageBox.Show("Student is not in the directory!!!!");
                }
                txtSearchFirst.Text = "";
                txtSearchPhone.Text = "";
            }
        }

        private void StudentdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.StudentdataGridView.Rows[e.RowIndex];
            txtStudentNumber.Text = row.Cells["StudentNumber"].Value.ToString();
            txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            var data = student.DisplayStudents();
            if (StudentlistView.Items.Count > 0)
            {
                StudentlistView.Items.Clear();
                populateListView(data);

            }
            else
            {
                populateListView(data);
            }
        }

        private void populateListView(DataTable data)
        {
            foreach (DataRow row in data.Rows)
            {

                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < data.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                StudentlistView.Items.Add(item);

            }
        }

        private void StudentlistView_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = StudentlistView.SelectedItems[0];
            txtStudentNumber.Text = item.SubItems[0].Text;
            txtFirstName.Text = item.SubItems[1].Text;
            txtLastName.Text = item.SubItems[2].Text;
            txtPhoneNumber.Text = item.SubItems[3].Text;
        }
    }
}
