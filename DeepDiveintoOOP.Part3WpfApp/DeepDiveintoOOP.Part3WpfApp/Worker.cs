using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveintoOOP.Part3WpfApp
{
    public abstract class Worker
    {
        public abstract void ViewClientInfo(Client client);
        public abstract void EditClient(Client client, string field, string newValue);
    }
}
