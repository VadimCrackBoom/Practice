using System;
using System.Windows;
using System.Windows.Controls;
using todo.Repository;

namespace todo.View
{
    /// <summary>
    /// Логика взаимодействия для ManagerTasks.xaml
    /// </summary>
    public partial class ManagerTasks : Page
    {
        private Main _main;

        public ManagerTasks(Main main)
        {
            InitializeComponent();
            _main = Main.Current;
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

            // Возвращаемся на предыдущую страницу
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Возвращаемся на предыдущую страницу
            NavigationService.GoBack();
        }
    }
}