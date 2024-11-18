using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveintoOOP.Part3WpfApp
{
    public class Consultant : Worker
    {
        public override void ViewClientInfo(Client client)
        {
            Console.WriteLine($"ID: {client.Id}");
            Console.WriteLine($"Имя: {client.Name}");
            Console.WriteLine($"Телефон: {client.PhoneNumber}");
            Console.WriteLine($"Счета: {client.Accounts.Count}");
        }

        public override void EditClient(Client client, string field, string newValue)
        {
            if (field == "PhoneNumber")
            {
                client.PhoneNumber = newValue;
                Console.WriteLine("Номер телефона успешно изменен.");
            }
            else
            {
                Console.WriteLine("Консультант может изменять только номер телефона.");
            }
        }
    }
}
