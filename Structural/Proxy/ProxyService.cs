using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;
class ProxyService
{
    private UserPayment _userPayment = new(new PayByCard());
    public ProxyService()
    {
        var paymentType = _userPayment.Payment.GetType().Name;
        Console.WriteLine($"Payment by {paymentType}");

        _userPayment.Pay(100);
    }
}
