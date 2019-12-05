using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null!)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //--------- STYLE BINDINGS --------------//
        public string Margins { get; } = "10,10,10,10";
        public string Tomato { get; } = "#FFF65158";
        public string Sandy { get; } = "#FFFBDE44";
        public string SlateGray { get; } = "#FF28324B";
        public short SpanAll { get; } = Int16.MaxValue; //32767

        //--------- COMMAND BINDINGS ------------//
        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }

        //--------- OTHER BINDINGS --------------//
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();
        
        private string _TextToAddToList = "";
        public string TextToAddToList
        {
            get => _TextToAddToList;
            set => SetProperty(ref _TextToAddToList, value);
        }

        private Item _SelectedItem = null!;
        public Item SelectedItem {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        //------------ CONSTRUCTOR -------------//
        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
            DeleteItemCommand = new Command(OnDeleteItem);
        }

        //---------- BINDING FUNCTIONS -----------//
        private void OnAddItem()
        {
            if (!string.IsNullOrEmpty(TextToAddToList))
            {
                ShoppingList.Add(new Item(TextToAddToList));
                TextToAddToList = "";
                SelectedItem = null!;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToAddToList)));
            }
        }

        private void OnDeleteItem()
        {
            if(SelectedItem != null)
            {
                ShoppingList.Remove(SelectedItem);
                SelectedItem = null!;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
            }
        }
    }
}
