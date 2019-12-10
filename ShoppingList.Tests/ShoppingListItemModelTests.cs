using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingList.Models;

namespace ShoppingList.Tests
{
    [TestClass]
    public class ShoppingListItemModelTests
    {
        [TestMethod]
        public void ShoppingListItemModel_CanAssignName()
        {
            //Arrange
            string itemName = "Mayonaise";
            //Act
            var model = new ShoppingListItemModel(itemName);
            //Assert
            Assert.AreEqual(itemName, model.ItemName);
        }
    }
}
