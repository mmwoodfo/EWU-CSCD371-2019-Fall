using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //--------- STYLE BINDINGS --------------//
        public string Margins { get; } = "10,10,10,10";
        public string Tomato { get; } = "#FFF65158";
        public string Sandy { get; } = "#FFFBDE44";
        public string SlateGray { get; } = "#FF28324B";
        public short SpanAll { get; } = Int16.MaxValue; //32767

        //--------- COMMAND BINDINGS ------------//
        public ICommand AddItemCommand { get; }

        //--------- OTHER BINDINGS --------------//
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();
        public string TextToAddToList { get; set; } = "";
        public string SelectedItem { get; set; } = "";
        public string AddItemControls { get; set; } = "Visible";
        public string SelectedItemControls { get; set; } = "Hidden";

        //------------ CONSTRUCTOR -------------//
        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
        }

        //---------- BINDING FUNCTIONS -----------//
        private void OnAddItem()
        {
            if (!string.IsNullOrEmpty(TextToAddToList))
            {
                ShoppingList.Add(new Item($"• {TextToAddToList}"));
                TextToAddToList = "";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToAddToList)));
            }
        }
    }
}
