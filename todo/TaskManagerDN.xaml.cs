using System.Windows;

namespace todo
{
    public partial class AddTaskWindow : Window
    {
        public string TaskTitle { get; private set; }
        public string TaskDescription { get; private set; }
        public bool IsTaskCreated { get; private set; }

        public AddTaskWindow()
        {
            InitializeComponent();
            IsTaskCreated = false;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            TaskTitle = TaskTitleTextBox.Text;
            TaskDescription = TaskDescriptionTextBox.Text;

            if (!string.IsNullOrWhiteSpace(TaskTitle))
            {
                IsTaskCreated = true;
                Close(); // Закрываем окно
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите название задачи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // Просто закрываем окно без создания задачи
        }
    }
}
