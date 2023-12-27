using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WebApplication1;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.UnitTests
{
    public class NotebookControllerTests
    {
        [Fact]
        public void ViewAll_ReturnsOkResult_WhenContactsExist()
        {
            // Arrange
            var notebookController = new NotebookController();
            // Assuming you have a method to populate contacts in the controller
            notebookController.PopulateContactsForTesting();

            // Act
            var result = notebookController.ViewAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Search_ReturnsOkResult_WhenContactsExist()
        {
            // Arrange
            var notebookController = new NotebookController();
            notebookController.PopulateContactsForTesting();

            // Act
            var result = notebookController.Search(1, "John");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void NewContact_ReturnsOkResult_WhenContactIsAdded()
        {
            // Arrange
            var notebookController = new NotebookController();
            var contactViewModel = new Contact
            {
                Name = "Anya",
                Surname = "Kuranova",
                Phone = "123456789",
                Email = "anya@yandex.com"
            };

            // Act
            var result = notebookController.NewContact(contactViewModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
