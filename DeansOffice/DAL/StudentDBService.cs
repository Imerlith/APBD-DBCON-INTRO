using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DeansOffice.Structures;
namespace DeansOffice.DAL
{
    class StudentDBService
    {


        public  static  ObservableCollection<Student> GetStudentData()
        {
            var students = new ObservableCollection<Student>();
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

                            students.Add(new Student
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
        public static ObservableCollection<Studies> GetStudiesList()
        {
            var ListOfStudies = new ObservableCollection<Studies>();


            return ListOfStudies;
        }
        public static void DeleteFromDB(IEnumerable<Student> toDelete)
        {

        }

    }
    
}
