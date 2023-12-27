using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;

namespace WebApplication1.UnitTests
{
    public class ContactsControllerTests
    {
        [Fact]
        public void GetAllContacts_ReturnsOkResult_WhenContactsExist()
        {
            // Arrange
            var contactsController = new ContactsController();
            contactsController.PopulateContactsForTesting();

            // Act
            var result = contactsController.GetAllContacts();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetContact_ReturnsOkResult_WhenContactExists()
        {
            // Arrange
            var contactsController = new ContactsController();
            contactsController.PopulateContactsForTesting();

            // Act
            var result = contactsController.GetContact(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddContact_ReturnsOkResult_WhenContactIsAdded()
        {
            // Arrange
            var contactsController = new ContactsController();
            var contactViewModel = new Contact
            {
                Name = "Anya",
                Surname = "Kuranova",
                Phone = "123456789",
                Email = "anya.@yandex.com"
            };

            // Act
            var result = contactsController.AddContact(contactViewModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
