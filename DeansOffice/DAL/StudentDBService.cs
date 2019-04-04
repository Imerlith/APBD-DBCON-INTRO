using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeansOffice.DAL
{
    class StudentDBService
    {


        public  static  ObservableCollection<Structures.Student> GetStudentData()
        {
            var students = new ObservableCollection<Structures.Student>();
            const string connectionString = "Data Source=db-mssql;Initial Catalog=s16540;Integrated Security=True";
            using (var conn= new SqlConnection(connectionString))
            {
                try
                {


                    conn.Open();

                    using (var command = new SqlCommand("select * from apbd.student inner join apbd.Studies on " +
                        "apbd.student.idstudies = apbd.studies.idstudies", conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            students.Add(new Structures.Student
                            {
                                IndexNumber = reader["IndexNumber"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                Studies = reader["Name"].ToString()
                            });
                        }
                    }
                }catch (SqlException)
                {
                    MessageBox.Show("Błąd połączenia z bazą danych");
                }
            }
            return students;
        }
        public static ObservableCollection<Structures.Studies> GetStudiesList()
        {
            var ListOfStudies = new ObservableCollection<Structures.Studies>();


            return ListOfStudies;
        }

    }
    
}
