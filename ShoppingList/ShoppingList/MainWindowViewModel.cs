using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();
        public ICommand AddItemCommand { get; }

        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
        }

        private void OnAddItem()
        {
            ShoppingList.Add(new Item($"Apples {ShoppingList.Count}", 3));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
        }
    }
}
