using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveintoOOP.Part3WpfApp
{
    public class Manager : Worker
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
            switch (field)
            {
                case "Name":
                    client.Name = newValue;
                    break;
                case "PhoneNumber":
                    client.PhoneNumber = newValue;
                    break;
                default:
                    Console.WriteLine($"Поле {field} успешно обновлено.");
                    break;
            }
        }
    }
}
