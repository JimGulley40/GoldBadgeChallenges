using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C4_Repo;

namespace C4_Tests
{
    [TestClass]
    public class C4_Tests
    {
        [TestMethod]
        private void AddItemsToMenu_ShouldGetCorrectBoolean()
        {
            //Arrange
            C4Repo repo = new C4Repo();
            C4_Outings outing = new C4_Outings();
            //Act
            bool addResult = repo.AddEventToList(outing);
            //Assert
            Assert.IsTrue(addResult);
        }
    }
}
