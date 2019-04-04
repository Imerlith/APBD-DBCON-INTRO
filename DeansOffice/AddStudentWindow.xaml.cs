using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
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
            StudiesComboBox.ItemsSource = DAL.StudentDBService.GetStudiesList();
            StudiesComboBox.SelectedItem = student.Studies;
        }

        private void AddStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Blędne dane");
            }
            else
            {

            }
        }
        private bool ValidateInput()
        {
            return false;
        }
    }
}
