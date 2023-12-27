namespace WebApplication1
{
    public class Contact
    {
        // поля для информации контакта
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // контструктор
        public Contact(string name, string surname, string phone, string email)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
        }

        // метод для отображения данных контакта
        public string Display()
        {
            // возвращаем строку с данными контакта
            return $"Name: {Name}\nSurname: {Surname}\nPhone: {Phone}\nE-mail: {Email}";
        }
    }
}
