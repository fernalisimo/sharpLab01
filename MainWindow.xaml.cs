using System.Windows;

namespace _01Kolomeytsev
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Zodiacview();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
