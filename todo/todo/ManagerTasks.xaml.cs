using System.Windows;
using System.Windows.Controls;

namespace todo
{
    public partial class ManagerTasks : Window
    {
        public string NewTask { get; private set; }

        public ManagerTasks()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Можно здесь добавить логику, если нужно
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == AddedTask)
            {
                string nameTask = nametask1.Text.Trim(); // Получаем название задачи
                string typeTask = type.Text.Trim(); // Получаем категорию задачи
                string description = DescriptionTextBox.Text.Trim(); // Получаем описание задачи

                // Проверяем, что все поля заполнены
                if (!string.IsNullOrEmpty(nameTask) && !string.IsNullOrEmpty(typeTask) && !string.IsNullOrEmpty(description))
                {
                    // Создаем текст задачи в желаемом формате
                    NewTask = $"{nameTask} (Тип: {typeTask}) - {description}";
                    DialogResult = true; // Указываем, что окно было закрыто с результатом
                    Close(); // Закрываем окно
                }
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (sender == CancelTask)
            {
                Close(); // Закрываем окно без сохранения изменений
            }
        }
    }
}
