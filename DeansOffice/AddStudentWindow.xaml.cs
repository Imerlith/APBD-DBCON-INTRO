using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DeansOffice.Structures;
namespace DeansOffice
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>

    public delegate void AddStudentHandler(object sender, Structures.Student nStudent);
    public partial class AddStudentWindow : Window
    {
        public event AddStudentHandler AddStudent;  
        public AddStudentWindow()
        {
            InitializeComponent();
            StudiesComboBox.ItemsSource = DAL.StudentDBService.ListOfStudies;
            SubjectListBox.ItemsSource = DAL.StudentDBService.ListOfSubjects;
        }
        public AddStudentWindow(Student student)
        {
            InitializeComponent();
            FillForm(student);
            
        }

        private void FillForm(Student student)
        {
            LastNameTxtBox.Text = student.LastName;
            FirstNameTxtBox.Text = student.FirstName;
            IndexTxtBox.Text = student.IndexNumber;
            StudiesComboBox.ItemsSource = DAL.StudentDBService.ListOfStudies;
            StudiesComboBox.SelectedItem = student.Studies;
            var subjects = DAL.StudentDBService.ListOfSubjects;
            foreach(Subject subject in subjects)
            {
                if (student.Subjects.Contains(subject))
                {
                    subject.IsChecked = true;
                }
            }
            SubjectListBox.ItemsSource = subjects;

        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Blędne dane");
            }
            else
            {
                var nStudent = new Student
                {
                    FirstName = NormalizeInput(FirstNameTxtBox.Text),
                    LastName = NormalizeInput(LastNameTxtBox.Text),
                    IndexNumber = IndexTxtBox.Text
                };
                AddStudent(this, nStudent);
                Close();
            }
        }
        private bool ValidateInput()
        {
            var lName = LastNameTxtBox.Text;
            var fName = FirstNameTxtBox.Text;
            var index = IndexTxtBox.Text;
            if(string.IsNullOrWhiteSpace(lName) || string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(index))
            {
                return false;
            }
            string indexPattern = "[s]\\d{5}";
            Regex regex = new Regex(indexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matches = regex.Match(index);
            if (!matches.Success)
            {
                return false;
            }

            return true;
        }
        private string NormalizeInput(string input)
        {
           input = Regex.Replace(input, @"\s+", "");
            return input.First().ToString().ToUpper() + input.Substring(1).ToLower();
        }
       
    }
}
