using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Xml.Linq;
using WebApplication1.Controllers;

namespace WebApplication1
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly List<Contact> contacts;
        public ContactsController()
        {
            contacts = new List<Contact>();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return Ok(contacts);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest("Данные контакта не предоставлены.");
            }

            contacts.Add(contact);

            return Ok("Контакт создан.");
        }
    }
}
