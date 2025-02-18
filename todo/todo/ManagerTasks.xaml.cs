using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using todo.Repository;

namespace todo
{
    /// <summary>
    /// Логика взаимодействия для ManagerTasks.xaml
    /// </summary>
    public partial class ManagerTasks : Window
    {
        private Main _main;

        public ManagerTasks(Main main)
        {
            InitializeComponent();
            _main = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получаем данные из полей ввода
            string taskName = taskTitle.Text;
            string category = GroupTitle.Text;
            string description = DescriptionTitle.Text;
            DateTime? dueDate = datePicker.SelectedDate;

            // Проверяем, что все обязательные поля заполнены
            if (string.IsNullOrWhiteSpace(taskName))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                MessageBox.Show("Введите категорию задачи!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создаем объект задачи
            TaskModel newTask = new TaskModel
            {
                Title = taskName,
                Category = category,
                Description = description,
                DueDate = dueDate ?? DateTime.Now.AddDays(1), // Если дата не выбрана, используем завтрашний день
                IsCompleted = false
            };

            // Добавляем задачу в основное окно
            _main.AddTask(newTask);

            // Закрываем окно
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
