using System.Windows;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; }

        public MainWindow()
        {
            DataContext = ViewModel = new MainWindowViewModel();
            InitializeComponent();
        }

        private void TextBox_OnGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            ViewModel.SelectedItem = null;
        }
    }
}
