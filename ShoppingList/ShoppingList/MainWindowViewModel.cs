using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmDialogs;
using MvvmDialogs.FrameworkDialogs.SaveFile;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using IOPath = System.IO.Path;

namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IDialogService _DialogService;

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

        private string _Path = "";
        public string Path
        {
            get => _Path;
            set => Set(ref _Path, value);
        }

        //------------ CONSTRUCTOR -------------//
        public MainWindowViewModel(IDialogService dialogService)
        {
            AddItemCommand = new RelayCommand(OnAddItem);
            DeleteItemCommand = new RelayCommand(OnDeleteItem);
            MoveItemUpCommand = new RelayCommand(OnMoveItemUp);
            MoveItemDownCommand = new RelayCommand(OnMoveItemDown);
            CrossOffCommand = new RelayCommand(OnCrossOff);
            ShowHelpCommand = new RelayCommand(OnShowHelp);
            ExportCommand = new RelayCommand(OnExport);

            _DialogService = dialogService;
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
                var settings = new SaveFileDialogSettings
                {
                    Title = "Save a Text File",
                    InitialDirectory = IOPath.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                    Filter = "Text File | *.txt",
                    CheckFileExists = false
                };

                bool? success = _DialogService.ShowSaveFileDialog(this, settings);
                if (success == true)
                {
                    using StreamWriter outputFile = new StreamWriter(settings.FileName);
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
