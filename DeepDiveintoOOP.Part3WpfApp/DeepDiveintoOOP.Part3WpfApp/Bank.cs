using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveintoOOP.Part3WpfApp
{
    public class Bank : ITransaction<Client>
    {
        public List<Client> Clients { get; private set; }

        public Bank()
        {
            Clients = new List<Client>();
        }

        public void AddClient(Client client)
        {
            if (Clients.Exists(c => c.Id == client.Id))
                throw new InvalidOperationException("Клиент с таким ID уже существует.");
            Clients.Add(client);
        }

        public void TransferFunds(Client sender, Account<string> senderAccount, Client receiver, Account<string> receiverAccount, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма перевода должна быть положительной.");
            senderAccount.Withdraw(amount);
            receiverAccount.Deposit(amount);
        }
    }
}
