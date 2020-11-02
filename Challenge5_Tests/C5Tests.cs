using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Challenge5_Repo;

namespace Challenge5_Tests
{
    [TestClass]
    public class C5Tests
    {
        
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            C5Emails content = new C5Emails();
            C5_Repo repository = new C5_Repo();

            //Act
            bool addResult = repository.AddToList(content);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            C5Emails content = new C5Emails();
            C5_Repo repo = new C5_Repo();

            repo.AddToList(content);

            //Act
            List<C5Emails> contents = repo.GetCustomers();

            bool directoryHasContent = contents.Contains(content);

            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            C5_Repo repo = new C5_Repo();
            C5Emails newContent = new C5Emails("Jim", "Istired",  "verytired", CustomerType.Past);
            repo.AddToList(newContent);
            string id = "Jim";

            //Act
            C5Emails searchResult = repo.GetCustomerByID(id);
            //Assert
            Assert.AreEqual(searchResult.ID, id);
        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            C5_Repo repo = new C5_Repo();
            C5Emails oldContent = new C5Emails("Jim", "Istired", "verytired", CustomerType.Past);
            repo.AddToList(oldContent);

            C5Emails newContent = new C5Emails("James", "Is", "verytired", CustomerType.Past);

            //Act
            bool updateResult = repo.UpdateExistingCustomer(oldContent.ID, newContent);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            C5_Repo repo = new C5_Repo();
            C5Emails content = new C5Emails("Jim", "Istired", "verytired", CustomerType.Past);
            repo.AddToList(content);

            //Act
            C5Emails oldContent = repo.GetCustomerByID("Jim");

            bool removeResult = repo.DeleteExisting(oldContent);

            //Assert
            Assert.IsTrue(removeResult);
        }

    }
}
