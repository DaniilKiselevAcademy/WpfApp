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
        // Создаю контекст для управления базой данных
        Context context = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Создаю базу данных, если ее нет
            context.Database.EnsureCreated();
            // Загружаю таблицу студентов в локальный кэш приложения
            context.Students.Load();
            // Привязываю данные к графической таблице
            studentsTable.ItemsSource = context.Students.Local.ToObservableCollection();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            // Создаю новое окно
            FormStudent form = new(new Student(), "Добавить");
            // Жду результат выполнения окна
            bool? result = form.ShowDialog();
            // Если все хорошо, то добавляю студента в базу данных и сохраняю изменения
            if (result == true)
            {
                context.Students.Add(form.student);
                context.SaveChanges();
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            // Проверяю, чтобы было выделен элемент
            if (studentsTable.SelectedItems.Count == 0) return;

            // Получаю выделенный элемент и привожу его к нужному мне типу для работы с базой данных
            Student selStudent = (Student)studentsTable.SelectedItem;
            // Создаю новое окно
            FormStudent form = new(selStudent, "Изменить");
            bool? result = form.ShowDialog();
            if (result == true)
            {
                // Произвожу обновление выделенного студента
                context.Students.Update(selStudent);
                context.SaveChanges();
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            if (studentsTable.SelectedItems.Count == 0) return;

            Student selStudent = (Student)studentsTable.SelectedItem;
            // Показываю диалоговое окно и прошу подтвердить удаление пользователя
            MessageBoxResult result = MessageBox.Show($"Удалить пользователя: {selStudent}?", "Удалить", MessageBoxButton.OKCancel);
            // Если нажали ОК, тогда удаляю
            if (result == MessageBoxResult.OK)
            {
                context.Students.Remove(selStudent);
                context.SaveChanges();
            }

        }
    }
}