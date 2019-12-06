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
        public short SpanAll { get; } = Int16.MaxValue; //32767

        //--------- COMMAND BINDINGS ------------//
        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand MoveItemUpCommand { get; }
        public ICommand MoveItemDownCommand { get; }
        public ICommand CrossOffCommand { get; }

        //--------- OTHER BINDINGS --------------//
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();
        
        private string _TextToAddToList = "";
        public string TextToAddToList
        {
            get => _TextToAddToList;
            set => SetProperty(ref _TextToAddToList, value);
        }

        private Item? _SelectedItem = null;
        public Item? SelectedItem {
            get => _SelectedItem!;
            set => SetProperty(ref _SelectedItem, value);
        }

        //------------ CONSTRUCTOR -------------//
        public MainWindowViewModel()
        {
            AddItemCommand = new Command(OnAddItem);
            DeleteItemCommand = new Command(OnDeleteItem);
            MoveItemUpCommand = new Command(OnMoveItemUp);
            MoveItemDownCommand = new Command(OnMoveItemDown);
            CrossOffCommand = new Command(OnCrossOff);
        }

        //---------- BINDING FUNCTIONS -----------//
        private void OnAddItem()
        {
            if (!string.IsNullOrEmpty(TextToAddToList))
            {
                ShoppingList.Add(new Item(TextToAddToList));
                TextToAddToList = "";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextToAddToList)));
            }
            DeselectListItem();
        }

        private void DeselectListItem()
        {
            SelectedItem = null!;
        }

        private void OnDeleteItem()
        {
            if(SelectedItem != null)
            {
                ShoppingList.Remove(SelectedItem);
                SelectedItem = null;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShoppingList)));
            }
        }

        private void OnMoveItemUp()
        {
            if(SelectedItem != null)
            {
                int index = ShoppingList.IndexOf(SelectedItem);
                if(index != 0)
                {
                    Item tempItem = SelectedItem;
                    ShoppingList.RemoveAt(index);
                    ShoppingList.Insert(index - 1, tempItem);
                    SelectedItem = tempItem;
                }
            }
        }

        private void OnMoveItemDown()
        {
            if (SelectedItem != null)
            {
                int index = ShoppingList.IndexOf(SelectedItem);
                if (index != ShoppingList.Count-1)
                {
                    Item tempItem = SelectedItem;
                    ShoppingList.RemoveAt(index);
                    ShoppingList.Insert(index + 1, tempItem);
                    SelectedItem = tempItem;
                }
            }
        }

        private void OnCrossOff()
        {
            if(SelectedItem != null)
            {
                if (SelectedItem.CheckedOff)
                    SelectedItem.CheckedOff = false;
                else
                    SelectedItem.CheckedOff = true;

                int index = ShoppingList.IndexOf(SelectedItem);

                //I'm not sure how else to get it to update - open to suggestions - because I don't like this
                Item tempItem = SelectedItem;
                ShoppingList.RemoveAt(index);
                ShoppingList.Insert(index, tempItem);

                SelectedItem = tempItem;
            }
        }
    }
}
