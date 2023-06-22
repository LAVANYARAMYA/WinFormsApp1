using System.Data;
using UI.DataAccess;
using UI.Model;

namespace UI.BusinessRule
{
    public class BusinessClass
    {

        private SqlServerAccess objSqlServerAccess = new SqlServerAccess();

        public BusinessClass() { }

        public bool AddStudent(Student student)
        {

            if (objSqlServerAccess.createStudent(student) > 0)
            {
                return true;
            }
            return false;
        }


        public DataTable FetchStudent()
        {
            DataTable dataTable= new DataTable();
                dataTable=objSqlServerAccess.FetchStudent();
            return dataTable;
        }

        public bool DeleteStudent(Student student) {
            if(objSqlServerAccess.DeleteStudent( student)>0)
            {
                return true;
            }
            return false;
        }


        public bool UpdateStudent(Student student)
        {
            if (objSqlServerAccess.UpdateStudent(student) > 0)
            {
                return true;
            }
            return false;
        }
       
    }
}