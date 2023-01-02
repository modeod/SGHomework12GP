using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Interface
{
    public interface IProxyPay : IPayment
    {
        public IPayment ChoosePaymentSystem();
    }
}
