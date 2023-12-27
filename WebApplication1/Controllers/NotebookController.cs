using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.UnitTests;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotebookController : ControllerBase
    {
        private readonly List<Contact> contacts;

        public NotebookController()
        {
            contacts = new List<Contact>();
        }

        // метод для отображения меню
        [HttpGet("ShowMenu")]
        public ActionResult<string> ShowMenu()
        {
            var menu = new List<string>
        {
            "Введите номер действия и нажмите [Enter].",
            "Menu:",
            "1. View all contacts",
            "2. Search",
            "3. New contact",
            "4. Exit"
        };

            // Преобразовываем список в строку с переносами строк
            var menuString = string.Join("\n", menu);

            // Возвращаем результат
            return Ok(menuString);
        }

        // метод поиска контактов
        [HttpGet("Search")]
        public ActionResult<IEnumerable<Contact>> Search([FromQuery] int searchType, [FromQuery] string searchInfo)
        {
            // Выполняем поиск контакта...
            List<Contact> results = new List<Contact>();
            switch (searchType)
            {
                case 1: // поиск по Name
                    results = contacts.Where(c => c.Name.Contains(searchInfo)).ToList();
                    break;
                case 2: // поиск по Surname
                    results = contacts.Where(c => c.Surname.Contains(searchInfo)).ToList();
                    break;
                case 3: // поиск по Name and Surname
                    results = contacts.Where(c => c.Name.Contains(searchInfo) || c.Surname.Contains(searchInfo)).ToList();
                    break;
                case 4: // поиск по Phone
                    results = contacts.Where(c => c.Phone.Contains(searchInfo)).ToList();
                    break;
                case 5: // поиск по E-mail
                    results = contacts.Where(c => c.Email.Contains(searchInfo)).ToList();
                    break;
                default: // некорректное значение
                    return BadRequest("Некорректное значение для параметра searchType. Допустимы значения от 1 до 5.");
            }

            if (results.Count == 0)
            {
                // Возвращаем NotFound, если контакты не найдены
                return NotFound("Контакты не найдены.");
            }
            else
            {
                // Возвращаем результат поиска в виде успешного ответа (код 200)
                return Ok(results);
            }
        }

        // метод создания нового контакта
        [HttpPost("NewContact")]
        public ActionResult<string> NewContact([FromBody] Contact contactViewModel)
        {
            if (contactViewModel == null)
            {
                return BadRequest("Данные контакта не предоставлены.");
            }

            // Проверяем, что все обязательные поля не пустые
            if (string.IsNullOrEmpty(contactViewModel.Name) || string.IsNullOrEmpty(contactViewModel.Surname) ||
                string.IsNullOrEmpty(contactViewModel.Phone) || string.IsNullOrEmpty(contactViewModel.Email))
            {
                return BadRequest("Имя, фамилия, телефон и e-mail не могут быть пустыми.");
            }

            Contact newContact = new Contact(contactViewModel.Name, contactViewModel.Surname, contactViewModel.Phone, contactViewModel.Email);
            contacts.Add(newContact);

            // Возвращаем успешный результат
            return Ok("Контакт создан.");
        }

        // метод закрытия записной книжки
        [HttpGet("Exit")]
        public ActionResult<string> Exit()
        {
            // Возвращаем сообщение о завершении
            return Ok("Выход...");
        }

        // ИЗМЕНЁННЫЙ метод для отображения всех контактов
        [HttpGet("ViewAll")]
        public ActionResult<IEnumerable<string>> ViewAll()
        {
            if (contacts.Count == 0)
            {
                // Возвращаем NotFound, если контакты не найдены
                return NotFound("Контакты не найдены.");
            }
            else
            {
                // Возвращаем строки с данными контактов в виде успешного ответа (код 200)
                var contactStrings = contacts.Select(c => c.Display()).ToList();
                return Ok(contactStrings);
            }
        }
    }
}
