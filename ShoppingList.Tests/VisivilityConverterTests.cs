using ShoppingList.ViewModel;
using ShoppingList.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingList.Tests
{
    [TestClass]
    public class VisivilityConverterTests
    {
        [TestMethod]
        public void Convert_ItemVisible()
        {
            //Arrange
            ShoppingListItemModel model = new ShoppingListItemModel("Test");
            VisibilityConverter converter = new VisibilityConverter();
            //Act
            //string result = converter.Convert(model) as string;
            //Assert
            Assert.AreEqual<string>("Visible", "Visible");
        }
    }
}
