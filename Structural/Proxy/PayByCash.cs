using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;
class PayByCash : IPayment
{
    public void Pay(int amount)
    {
        Console.WriteLine($"Paying {amount} using cash");
    }
}
