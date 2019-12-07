using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        //------------------- ADD ITEM COMMAND -----------------------//
        [TestMethod()]
        public void AddItem_TextNotEmpty_AddToList()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            string text = "Apples";
            vm.TextToAddToList = text;

            //Act
            vm.AddItemCommand.Execute(text);
            
            //Assert
            Assert.AreEqual(1, vm.ShoppingList.Count);
        }

        [TestMethod()]
        public void AddItem_TextEmpty_DoNotAddToList()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            string text = "";
            vm.TextToAddToList = text;

            //Act
            vm.AddItemCommand.Execute(text);

            //Assert
            Assert.AreEqual(0, vm.ShoppingList.Count);
        }

        [TestMethod()]
        public void AddItem_TextNull_DoNotAddToList()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            vm.TextToAddToList = null!;

            //Act
            vm.AddItemCommand.Execute(null);

            //Assert
            Assert.AreEqual(0, vm.ShoppingList.Count);
        }

        //------------------- DELETE ITEM COMMAND -----------------------//
        [TestMethod()]
        public void DeleteItem_NotNull_RemoveFromList()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item = new Item("Apples");
            vm.ShoppingList.Add(item);
            vm.SelectedItem = item;

            //Act
            vm.DeleteItemCommand.Execute(item);

            //Assert
            Assert.AreEqual(0, vm.ShoppingList.Count);
        }

        [TestMethod()]
        public void DeleteItem_Null_RemoveFromList()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item = new Item("Apples");
            vm.ShoppingList.Add(item);
            vm.SelectedItem = null;

            //Act
            vm.DeleteItemCommand.Execute(null);

            //Assert
            Assert.AreEqual(1, vm.ShoppingList.Count);
        }

        //------------------- MOVE ITEM UP COMMAND -----------------------//
        [TestMethod()]
        public void MoveItemUp_NotNullOrFirstIndex_IncreaseIndex()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item1 = new Item("Apples");
            Item item2 = new Item("Bread");
            Item item3 = new Item("Milk");
            vm.ShoppingList.Add(item1);
            vm.ShoppingList.Add(item2);
            vm.ShoppingList.Add(item3);

            vm.SelectedItem = item2;

            //Act
            vm.MoveItemUpCommand.Execute(item2);

            //Assert
            Assert.AreEqual(0, vm.ShoppingList.IndexOf(item2));
        }

        [TestMethod()]
        public void MoveItemUp_FirstIndex_RemainSame()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item1 = new Item("Apples");
            Item item2 = new Item("Bread");
            Item item3 = new Item("Milk");
            vm.ShoppingList.Add(item1);
            vm.ShoppingList.Add(item2);
            vm.ShoppingList.Add(item3);

            vm.SelectedItem = item1;

            //Act
            vm.MoveItemUpCommand.Execute(item1);

            //Assert
            Assert.AreEqual(0, vm.ShoppingList.IndexOf(item1));
        }

        [TestMethod()]
        public void MoveItemUp_Null_RemainSame()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item1 = new Item("Apples");
            Item item2 = new Item("Bread");
            Item item3 = new Item("Milk");
            vm.ShoppingList.Add(item1);
            vm.ShoppingList.Add(item2);
            vm.ShoppingList.Add(item3);

            vm.SelectedItem = null;

            //Act
            vm.MoveItemUpCommand.Execute(null);

            //Assert
            Assert.AreEqual(0, vm.ShoppingList.IndexOf(item1));
            Assert.AreEqual(1, vm.ShoppingList.IndexOf(item2));
            Assert.AreEqual(2, vm.ShoppingList.IndexOf(item3));
        }

        //------------------- MOVE ITEM DOWN COMMAND -----------------------//
        [TestMethod()]
        public void MoveItemDown_NotNullOrLastIndex_IncreaseIndex()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item1 = new Item("Apples");
            Item item2 = new Item("Bread");
            Item item3 = new Item("Milk");
            vm.ShoppingList.Add(item1);
            vm.ShoppingList.Add(item2);
            vm.ShoppingList.Add(item3);

            vm.SelectedItem = item2;

            //Act
            vm.MoveItemDownCommand.Execute(item2);

            //Assert
            Assert.AreEqual(2, vm.ShoppingList.IndexOf(item2));
        }

        [TestMethod()]
        public void MoveItemDown_LastIndex_RemainSame()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item1 = new Item("Apples");
            Item item2 = new Item("Bread");
            Item item3 = new Item("Milk");
            vm.ShoppingList.Add(item1);
            vm.ShoppingList.Add(item2);
            vm.ShoppingList.Add(item3);

            vm.SelectedItem = item3;

            //Act
            vm.MoveItemDownCommand.Execute(item3);

            //Assert
            Assert.AreEqual(2, vm.ShoppingList.IndexOf(item3));
        }

        [TestMethod()]
        public void MoveItemDown_Null_RemainSame()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item1 = new Item("Apples");
            Item item2 = new Item("Bread");
            Item item3 = new Item("Milk");
            vm.ShoppingList.Add(item1);
            vm.ShoppingList.Add(item2);
            vm.ShoppingList.Add(item3);

            vm.SelectedItem = null;

            //Act
            vm.MoveItemDownCommand.Execute(null);

            //Assert
            Assert.AreEqual(0, vm.ShoppingList.IndexOf(item1));
            Assert.AreEqual(1, vm.ShoppingList.IndexOf(item2));
            Assert.AreEqual(2, vm.ShoppingList.IndexOf(item3));
        }

        //------------------- CROSS ITEM OFF COMMAND -----------------------//
        [TestMethod()]
        public void CrossOff_ItemNotCrossedOff_SetTrue()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item = new Item("Apples");

            vm.ShoppingList.Add(item);

            vm.SelectedItem = item;

            //Act
            vm.CrossOffCommand.Execute(item);

            //Assert
            Assert.IsTrue(item.CheckedOff);
        }

        [TestMethod()]
        public void CrossOff_ItemCrossedOff_SetFalse()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item = new Item("Apples")
            {
                CheckedOff = true
            };

            vm.ShoppingList.Add(item);

            vm.SelectedItem = item;

            //Act
            vm.CrossOffCommand.Execute(item);

            //Assert
            Assert.IsFalse(item.CheckedOff);
        }

        [TestMethod()]
        public void CrossOff_SelectedItemNull_DoNothing()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            Item item = new Item("Apples")
            {
                CheckedOff = true
            };

            vm.ShoppingList.Add(item);

            vm.SelectedItem = null;

            //Act
            vm.CrossOffCommand.Execute(null);

            //Assert
            Assert.IsTrue(item.CheckedOff);
        }

        //------------------- SHOW POPUP COMMAND -----------------------//
        [TestMethod()]
        public void ShowHelp_IsTrue_SetToFalse()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            vm.ShowPopUp = true;

            //Act
            vm.ShowHelpCommand.Execute(true);

            //Assert
            Assert.IsFalse(vm.ShowPopUp);
        }

        [TestMethod()]
        public void ShowHelp_IsFalse_SetToTrue()
        {
            //Arrange
            MainWindowViewModel vm = new MainWindowViewModel();
            vm.ShowPopUp = false;

            //Act
            vm.ShowHelpCommand.Execute(false);

            //Assert
            Assert.IsTrue(vm.ShowPopUp);
        }

    }
}