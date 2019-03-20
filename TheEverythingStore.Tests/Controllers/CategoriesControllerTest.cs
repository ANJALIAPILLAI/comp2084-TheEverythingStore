using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// new references
using System.Web.Mvc;
using TheEverythingStore.Controllers;
using Moq;
using TheEverythingStore.Models;
using System.Linq;
using System.Collections.Generic;

namespace TheEverythingStore.Tests.Controllers
{
    [TestClass]
    public class CategoriesControllerTest
    {
        //moq data
        CategoriesController controller;
        List<Category> categories;
        Mock<IMockCategories> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            //create some mock data
            categories = new List<Category>
            {
                new Category{ CategoryId=500, Name="Fake category"},
                new Category{ CategoryId=501, Name="Fake category 2"},
                new Category{ CategoryId=502, Name="Fake category 3"}
            };

            //set up and populate our mmock object to inject into our controller
            mock = new Mock<IMockCategories>();
            mock.Setup(c => c.Categories).Returns(categories.AsQueryable());

            //initialize the controller and inject the mock object
            controller = new CategoriesController(mock.Object);
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadsCategories()
        {
            //act
            //call the index method
            //access the data model return ed to the view
            //cast the data as a list of type category
            var results=(List<Category>)((ViewResult)controller.Index()).Model;
            //assert
            CollectionAssert.AreEqual(categories.OrderBy(c=> c.Name).ToList(), results);
        }
    }
}
