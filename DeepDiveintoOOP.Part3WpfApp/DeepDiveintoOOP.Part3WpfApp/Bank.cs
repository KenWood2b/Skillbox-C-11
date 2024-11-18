using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

        // Сохранение клиентов в файл
        public void SaveClientsToFile(string filePath)
        {
            try
            {
                var json = JsonSerializer.Serialize(Clients);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении клиентов: {ex.Message}");
            }
        }

        // Загрузка клиентов из файла
        public void LoadClientsFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    Clients = JsonSerializer.Deserialize<List<Client>>(json) ?? new List<Client>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке клиентов: {ex.Message}");
                Clients = new List<Client>(); // Создаем пустой список в случае ошибки
            }
        }

        public void TransferFunds(Client sender, Account<string> senderAccount, Client receiver, Account<string> receiverAccount, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумма перевода должна быть положительной.");
            senderAccount.Withdraw(amount);
            receiverAccount.Deposit(amount);
        }
    }
}