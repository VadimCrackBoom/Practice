using System;
using System.Windows;
using System.Windows.Controls;

namespace todo
{

    public partial class Tasks : Window
    {
        public Tasks()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            ManagerTasks managerTasks = new ManagerTasks();
            bool? result = managerTasks.ShowDialog(); // Используем ShowDialog для блокировки ввода в родительском окне

            if (result == true) // Проверяем, успешно ли создана задача
            {
                string newTask = managerTasks.NewTask; // Получаем созданную задачу
                TaskList.Items.Add(newTask); // Добавляем задачу в левый список

                // Добавим задачу в правый список с более подробной информацией
                string[] taskDetail = newTask.Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                if (taskDetail.Length > 0)
                {
                    string details = taskDetail[0]; // Название задачи
                    TaskDescriptionList.Items.Add(details + "\n" + (taskDetail.Length > 1 ? taskDetail[1] : "Описание не задано"));
                }
            }
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                ReadyTask.Visibility = Visibility.Visible;
                DeleteTask.Visibility = Visibility.Visible;

                // Обновление правого ListBox с выбором
                var selectedTask = TaskList.SelectedItem.ToString();
                TaskDescriptionList.Items.Clear();
                TaskDescriptionList.Items.Add(selectedTask);
            }
            else
            {
                ReadyTask.Visibility = Visibility.Collapsed;
                DeleteTask.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TaskList.SelectedItem != null)
            {
                TaskList.Items.Remove(TaskList.SelectedItem); // Удаляем из левого списка
                TaskDescriptionList.Items.Clear(); // Очищаем правый список, если удаляем задачу
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Логика для пометки задачи как готовой
        }

        private void TaskDescriptionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Тут может быть логика для обработки выбора в правом списке, если это необходимо
        }
    }
}

