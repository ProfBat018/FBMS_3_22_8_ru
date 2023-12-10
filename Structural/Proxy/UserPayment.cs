using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;
class UserPayment
{
    public IPayment Payment { get; set; }

    public UserPayment(IPayment payment)
    {
        Payment = payment;
    }

    public void Pay(int amount)
    {
        Payment.Pay(amount);
    }
}
