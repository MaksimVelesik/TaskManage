using System.Windows;
using System.Windows.Controls;

namespace TaskManager
{
    public partial class TaskDialog : Window
    {
        public Task NewTask { get; private set; }

        public TaskDialog()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название задачи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewTask = new Task
            {
                Title = titleTextBox.Text,
                Description = descriptionTextBox.Text,
                Priority = (priorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Status = (statusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
            };

            DialogResult = true;
            Close();
        }
    }
}