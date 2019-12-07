using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        //--------- STYLE BINDINGS --------------//
        public short SpanAll { get; } = Int16.MaxValue; //32767

        //--------- COMMAND BINDINGS ------------//
        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand MoveItemUpCommand { get; }
        public ICommand MoveItemDownCommand { get; }
        public ICommand CrossOffCommand { get; }
        public ICommand ShowHelpCommand { get; }
        public ICommand ExportCommand { get; }

        //--------- OTHER BINDINGS --------------//
        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();

        private string _TextToAddToList = "";
        public string TextToAddToList
        {
            get => _TextToAddToList;
            set => Set(ref _TextToAddToList, value);
        }

        private Item? _SelectedItem = null;
        public Item? SelectedItem
        {
            get => _SelectedItem!;
            set => Set(ref _SelectedItem, value);
        }

        private bool _ShowPopUp = false;
        public bool ShowPopUp
        {
            get => _ShowPopUp;
            set => Set(ref _ShowPopUp, value);
        }

        //------------ CONSTRUCTOR -------------//
        public MainWindowViewModel()
        {
            AddItemCommand = new RelayCommand(OnAddItem);
            DeleteItemCommand = new RelayCommand(OnDeleteItem);
            MoveItemUpCommand = new RelayCommand(OnMoveItemUp);
            MoveItemDownCommand = new RelayCommand(OnMoveItemDown);
            CrossOffCommand = new RelayCommand(OnCrossOff);
            ShowHelpCommand = new RelayCommand(OnShowHelp);
            ExportCommand = new RelayCommand(OnExport);
        }

        //---------- BINDING FUNCTIONS -----------//
        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(TextToAddToList))
            {
                ShoppingList.Add(new Item(TextToAddToList));
            }
            TextToAddToList = "";
            DeselectListItem();
        }

        private void DeselectListItem()
        {
            SelectedItem = null;
        }

        private void OnDeleteItem()
        {
            if (SelectedItem != null)
            {
                ShoppingList.Remove(SelectedItem);
                SelectedItem = null;
            }
        }

        private void OnMoveItemUp()
        {
            if (SelectedItem != null)
            {
                int index = ShoppingList.IndexOf(SelectedItem);
                if (index != 0)
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
                if (index != ShoppingList.Count - 1)
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
            if (SelectedItem != null)
            {
                int index = ShoppingList.IndexOf(SelectedItem);

                if (SelectedItem.CheckedOff)
                    ShoppingList[index].CheckedOff = false;
                else
                    ShoppingList[index].CheckedOff = true;

                Item temp = ShoppingList[index];
                ShoppingList.RemoveAt(index);
                ShoppingList.Insert(index, temp);
                SelectedItem = temp;
            }
        }

        private void OnShowHelp() => 
            ShowPopUp = !ShowPopUp;

        private void OnExport()
        {
            if (ShoppingList.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text File | *.txt",
                    Title = "Save a Text File"
                };

                saveFileDialog.ShowDialog();
                string shoppingListFilePath = saveFileDialog.FileName;

                if (!string.IsNullOrEmpty(shoppingListFilePath))
                {
                    using StreamWriter outputFile = new StreamWriter(shoppingListFilePath);
                    foreach (Item item in ShoppingList)
                    {
                        if (item.CheckedOff)
                            outputFile.WriteLine($"{item.Name}✔");
                        else
                            outputFile.WriteLine(item.Name);
                    }
                }
            }
        }
    }
}
