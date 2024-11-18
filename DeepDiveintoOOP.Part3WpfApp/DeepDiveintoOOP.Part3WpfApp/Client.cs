using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveintoOOP.Part3WpfApp
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<IAccount<string>> Accounts { get; private set; }

        public Client(int id, string name, string phoneNumber = "")
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Accounts = new List<IAccount<string>>();
        }

        public void AddAccount(IAccount<string> account)
        {
            if (Accounts.Exists(a => a.Type == account.Type))
                throw new InvalidOperationException($"У клиента уже есть счёт типа {account.Type}.");
            Accounts.Add(account);
        }

        public override string ToString() => $"{Name} (ID: {Id}) — Телефон: {PhoneNumber}, Счета: {Accounts.Count}";
    }
}
