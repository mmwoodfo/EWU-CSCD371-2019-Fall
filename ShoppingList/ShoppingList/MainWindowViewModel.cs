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

        //--------- OTHER BINDINGS --------------//
        public ObservableCollection<string> ShoppingList { get; } = new ObservableCollection<string>();
        public string TextToAddToList { get; set; } = "";
        public string SelectedItem { get; set; } = "";
        public ICommand AddItemCommand { get; }
        public string DeleteBtnVisiblity { get; set; } = "Hidden";
        public string UpdateBtnVisibility { get; set; } = "Hidden";
        public string UpdateTxtVisibility { get; set; } = "Hidden";

        //------------ CONSTRUCTOR -------------//
        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
        }

        //---------- BINDING COMMANDS ------------//
        private void OnAddItem()
        {
            if (!string.IsNullOrEmpty(TextToAddToList))
            {
                ShoppingList.Add($"• {TextToAddToList}");
                TextToAddToList = "";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToAddToList)));
            }
        }
    }
}
