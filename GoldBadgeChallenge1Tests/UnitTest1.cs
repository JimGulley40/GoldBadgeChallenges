using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoldBadgeChallenge1Repo;

namespace GoldBadgeChallenge1Tests
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        private void AddItemsToMenu_ShouldGetCorrectBoolean()
        {

            //Arrange
            C1MenuItems menuItem = new C1MenuItems();
            Methods repository = new Methods();

            //Act
            bool addResult = repository.AddMenuItemToMenu(menuItem);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetByNumber_ShouldReturnCorrectmenuItem()
        {
            //Arrange
            Methods repo = new Methods();
            C1MenuItems newmenuItem = new C1MenuItems(3, "Burrito", "A tasty Burrito", 2.99, "tortilla, and fillings");
            repo.AddMenuItemToMenu(newmenuItem);
            int itemNum = 3;

            //Act
            C1MenuItems searchResult = repo.GetMenuItemByNumber(itemNum);
            //Assert
            Assert.AreEqual(searchResult.MealNum, itemNum);
        }



        [TestMethod]
        public void DeleteExistingmenuItem_ShouldReturnTrue()
        {
            //Arrange
            Methods repo = new Methods();
            C1MenuItems menuItem = new C1MenuItems(3, "Burrito", "A tasty Burrito", 2.99, "tortilla, and fillings");
            repo.AddMenuItemToMenu(menuItem);
            int itemNum = 3;
            //Act
            C1MenuItems oldmenuItem = repo.GetMenuItemByNumber(itemNum);
            bool removeResult = repo.DeleteExistingMenuItem(oldmenuItem);
            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
 