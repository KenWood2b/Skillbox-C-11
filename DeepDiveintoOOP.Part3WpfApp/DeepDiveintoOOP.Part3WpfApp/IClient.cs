using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveintoOOP.Part3WpfApp
{
    public interface IClient<in T>
    {
        void TransferTo(T client, decimal amount);
    }
}
