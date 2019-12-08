using System.Windows;

namespace ShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModelLocator ViewModel { get; }

        public MainWindow()
        {
            ViewModel = new ViewModelLocator();
            InitializeComponent();
        }

        private void TextBox_OnGotKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            ViewModel.MainWindow.SelectedItem = null;
        }
    }
}
