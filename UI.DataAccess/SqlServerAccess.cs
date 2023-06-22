using Microsoft.Data.SqlClient;
using System.Data;
using UI.Model;


namespace UI.DataAccess
{
    public class SqlServerAccess
    {


        private string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public SqlServerAccess() { }

       
        public int createStudent(Student student)
        {
            SqlConnection objSqlConnection = new SqlConnection(ConnectionString);
            objSqlConnection.Open();

            string query = $"INSERT INTO StudentTable (FirstName,LastName,Email,Age) VALUES('{student.FirstName}','{student.LastName}','{student.Email}','{student.Age}')";

            SqlCommand sqlCommand = new SqlCommand(query, objSqlConnection);
            sqlCommand.CommandText = query;
            sqlCommand.Connection = objSqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.Text;

            int result = sqlCommand.ExecuteNonQuery();

            if (objSqlConnection.State == System.Data.ConnectionState.Open)
            {
                objSqlConnection.Close();
            }
            return result;

        }

        public DataTable FetchStudent()
        {
            SqlConnection objSqlConnection = new SqlConnection(ConnectionString);
            objSqlConnection.Open();

            string query = "select FirstName,LastName,Email,Age from StudentTable";

            SqlCommand sqlCommand = new SqlCommand(query, objSqlConnection);
           
            sqlCommand.CommandType = System.Data.CommandType.Text;

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataSet ds = new DataSet("StudentDataSet");

            adapter.Fill(ds);
            
            return ds.Tables[0];
        }


        public int DeleteStudent(Student student)
        {


            SqlConnection objSqlConnection = new SqlConnection(ConnectionString);
            objSqlConnection.Open();

            string query = $"delete from StudentTable where FirstName = '{student.FirstName}' ";

            SqlCommand sqlCommand = new SqlCommand(query, objSqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.Text;


            int result = sqlCommand.ExecuteNonQuery();

            if (objSqlConnection.State == System.Data.ConnectionState.Open)
            {
                objSqlConnection.Close();
            }
            return result;


            
        }


        public int UpdateStudent(Student student)
        {
            SqlConnection objSqlConnection = new SqlConnection(ConnectionString);
            objSqlConnection.Open();

            string query = $"update StudentTable set LastName='{student.LastName}',Email='{student.Email}',Age='{student.Age}' where FirstName='{student.FirstName}'";

            SqlCommand sqlCommand = new SqlCommand(query, objSqlConnection);
            sqlCommand.CommandText = query;
            sqlCommand.Connection = objSqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.Text;

            int result = sqlCommand.ExecuteNonQuery();

            if (objSqlConnection.State == System.Data.ConnectionState.Open)
            {
                objSqlConnection.Close();
            }
            return result;

        }


    }
}