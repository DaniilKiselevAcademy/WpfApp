using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Database.EnsureCreated();
            context.Students.Load();
            studentsTable.ItemsSource = context.Students.Local.ToObservableCollection();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            FormStudent form = new(new Student(), "Добавить");
            bool? result = form.ShowDialog();
            if (result == true)
            {
                context.Students.Add(form.student);
                context.SaveChanges();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            if (studentsTable.SelectedItems.Count == 0) return;

            Student selStudent = (Student)studentsTable.SelectedItem;
            FormStudent form = new(selStudent, "Изменить");
            bool? result = form.ShowDialog();
            if (result == true)
            {
                context.Students.Update(selStudent);
                context.SaveChanges();
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (studentsTable.SelectedItems.Count == 0) return;

            Student selStudent = (Student)studentsTable.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Удалить пользователя: {selStudent}?", "Удалить", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                context.Students.Remove(selStudent);
                context.SaveChanges();
            }

        }
    }
}