using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeansOffice.DAL
{
    class StudentDBService
    {

        public static ObservableCollection<Structures.Student> GetStudentData()
        {
            var students = new ObservableCollection<Structures.Student>();
            string connectionString = "Data Source=db-mssql;Initial Catalog=s16540;Integrated Security=True";
            using (SqlConnection conn= new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand("select IndexNumber, FirstName, LastName," +
                    "Address, Studies.Name  from Student inner join Studies on Student.IdStudies = Studies.IdStudies"))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            students.Add(new Structures.Student { IndexNumber = reader["IndexNumber"].ToString(),
                                FirstName =reader["FirstName"].ToString(),LastName=reader["LastName"].ToString(),
                                Address=reader["Address"].ToString(),Studies = reader["Name"].ToString()});
                        }
                    }
                }
            }
            return students;
        }
        
    }
    
}
