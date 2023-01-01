using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Interface
{
    public interface IPayment
    {
        public bool Pay(uint _amount);
    }
}
