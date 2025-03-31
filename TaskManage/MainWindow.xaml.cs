using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        private List<Task> allTasks = new List<Task>();

        public MainWindow()
        {
            InitializeComponent();
            InitializeTasks();
            taskListView.ItemsSource = allTasks;
        }

        private void InitializeTasks()
        {
            allTasks.Add(new Task { Title = "Задача 1", Description = "Описание 1", Priority = "Высокий", Status = "В работе" });
            allTasks.Add(new Task { Title = "Задача 2", Description = "Описание 2", Priority = "Низкий", Status = "Выполнено" });
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDialog taskDialog = new TaskDialog();
            if (taskDialog.ShowDialog() == true)
            {
                allTasks.Add(taskDialog.NewTask);
                taskListView.ItemsSource = null;
                taskListView.ItemsSource = allTasks;
            }
        }

        private void StatusFilterComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selectedStatus = (statusFilterComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedStatus == "Все")
            {
                taskListView.ItemsSource = allTasks;
            }
            else
            {
                taskListView.ItemsSource = allTasks.Where(task => task.Status == selectedStatus).ToList();
            }
        }
    }
}