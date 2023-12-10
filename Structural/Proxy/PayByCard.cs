using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;
class PayByCard : IPayment
{
    public void Pay(int amount)
    {
        Console.WriteLine("PayByCard");
    }
}
