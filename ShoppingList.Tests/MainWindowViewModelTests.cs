using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList.ViewModel;

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void OnAddItem_AddsItemToList_CountMatches()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            model.Item = "Eggs";
            int listSize = model.Items.Count;
            //Act
            ICommand addItemCommand = model.AddItem;
            addItemCommand.Execute(model.Item);
            //Assert
            Assert.AreEqual(listSize + 1, model.Items.Count);            
        }

        [TestMethod]
        public void OnAddItem_AddsItemToList_ItemMatches()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            model.Item = "Eggs";            
            //Act
            ICommand addItemCommand = model.AddItem;
            addItemCommand.Execute(model.Item);
            //Assert            
            Assert.AreEqual("Eggs", model.Items[model.Items.Count - 1].ItemName);
        }

        [TestMethod]
        public void OnAddItem_DoesntAddItemWhenTextBoxTextIsntChanged()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            int defaultListSize = model.Items.Count;
            //Act
            ICommand addItemCommand = model.AddItem;
            addItemCommand.Execute(model.Item);
            //Assert
            Assert.AreEqual(defaultListSize, model.Items.Count);
        }

        [TestMethod]
        public void OnAddItem_NotChangingTextBoxTextOnAddChangesTextBoxTextToErrorText()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();            
            //Act
            ICommand addItemCommand = model.AddItem;
            addItemCommand.Execute(model.Item);
            //Assert
            Assert.AreEqual("You have to type SOMETHING.", model.Item);
            
        }

        [TestMethod]
        public void ViewModel_ListItemSelectedIsFirstListItem()
        {
            //Arrange
            MainWindowViewModel model = new MainWindowViewModel();
            //Act
            //Assert
            Assert.AreEqual(model.Items[0], model.Model);
        }
    }
}
