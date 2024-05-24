﻿using System;
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

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для FormStudent.xaml
    /// </summary>
    public partial class FormStudent : Window
    {
        public Student student;

        public FormStudent(Student student, string title)
        {
            InitializeComponent();
            this.student = student;
            DataContext = student;
            Title = title;
            confirmBtn.Content = title;
        }

        private void confirmBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
