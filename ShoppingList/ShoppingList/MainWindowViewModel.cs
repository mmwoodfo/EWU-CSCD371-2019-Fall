using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //--------- STYLE BINDINGS --------------//
        public string Margins { get; }
        public string Tomato { get; }
        public string Sandy { get; }
        public string SlateGray { get; }

        //--------- OTHER BINDINGS --------------//
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();
        public string TextToAddToList { get; set; } = "";
        public ICommand AddItemCommand { get; }

        public MainWindowViewModel()
        {
            Margins = "10,10,10,10";
            Tomato = "#FFF65158";
            Sandy = "#FFFBDE44"; 
            SlateGray = "#FF28324B"; 

            AddItemCommand = new Command(OnAddItem);
        }

        private void OnAddItem()
        {
            ShoppingList.Add(new Item($"{TextToAddToList}", 3));
            TextToAddToList = "";
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToAddToList)));
        }
    }
}
