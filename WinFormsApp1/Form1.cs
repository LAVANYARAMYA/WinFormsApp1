using System.Data;
using UI.BusinessRule;
using UI.Model;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private BusinessClass objBusinessClass = new BusinessClass();
        Student objStudent = new Student();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtButton_Click(object sender, EventArgs e)
        {
           
            objStudent.FirstName = txtFirstName.Text.Trim();
            objStudent.LastName = txtLastName.Text.Trim();
            objStudent.Email = txtEmail.Text.Trim();


            if (string.IsNullOrEmpty(txtAge.Text.Trim()))
            {
                objStudent.Age = 0;
            }
            else
            {
                objStudent.Age = Convert.ToInt32(txtAge.Text.Trim());
            }


            bool status = objBusinessClass.AddStudent(objStudent);
            if (status)
            {
                MessageBox.Show("Record Saved");
                DataTable table = objBusinessClass.FetchStudent();
                dataGridView.DataSource = table;

            }



        }

        private void txtEmail_Click(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable table = objBusinessClass.FetchStudent();
            dataGridView.DataSource = table;

            objStudent.FirstName = txtFirstName.Text.Trim();
            objStudent.LastName = txtLastName.Text.Trim();
            objStudent.Email = txtEmail.Text.Trim();


            if (string.IsNullOrEmpty(txtAge.Text.Trim()))
            {
                objStudent.Age = 0;
            }
            else
            {
                objStudent.Age = Convert.ToInt32(txtAge.Text.Trim());
            }


            bool status = objBusinessClass.UpdateStudent(objStudent);
            if (status)
            {
                MessageBox.Show("Record Updated");
                DataTable table1 = objBusinessClass.FetchStudent();
                dataGridView.DataSource = table1;

            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            objStudent.FirstName= txtFirstName.Text.Trim();
             bool status = objBusinessClass.DeleteStudent(objStudent);

            if (status)
            {
                MessageBox.Show("Record Deleted");
                DataTable table = objBusinessClass.FetchStudent();
                dataGridView.DataSource = table;


            }

           

        }
     }
 }
    
