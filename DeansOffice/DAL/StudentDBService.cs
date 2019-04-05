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
        public static List<Studies> ListOfStudies;
        public static List<Subject> ListOfSubjects;

        public  static  ObservableCollection<Student> GetStudentData()
        {
            var students = new ObservableCollection<Student>();
            ListOfStudies = new List<Studies>();
            ListOfSubjects = new List<Subject>();
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
                                Studies = new Studies { Name = reader["Name"].ToString() }
                            });
                        }
                    }
                    using (var command = new SqlCommand("select * from apbd.studies", conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListOfStudies.Add(new Studies { Name = reader["Name"].ToString() });
                        }
                    }
                    using (var command = new SqlCommand("select * from apbd.subject", conn))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListOfSubjects.Add(new Subject { Name = reader["Name"].ToString() });
                        }
                    }

                }
                catch (SqlException)
                {
                    MessageBox.Show("Błąd połączenia z bazą danych");
                }
            }
            return students;
        }
       
        public static void DeleteFromDB(IEnumerable<Student> toDelete)
        {

        }
        public static void AddToDB(Student student)
        {

        }

    }
    
}
