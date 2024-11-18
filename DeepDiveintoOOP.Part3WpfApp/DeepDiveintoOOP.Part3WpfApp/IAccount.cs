using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveintoOOP.Part3WpfApp
{
    public interface IAccount<out T>
    {
        T Type { get; }
        decimal Balance { get; }
        string ToString();
    }
}
