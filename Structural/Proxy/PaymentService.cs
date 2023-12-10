using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;
class PaymentService
{
    private ProxyService _proxyService;

    public void Pay()
    {
        _proxyService = new();
    }
}
