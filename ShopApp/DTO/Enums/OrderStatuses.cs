using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DTO.Enums
{
    public enum OrderStatuses
    {
        Pending = 1,
        Awaiting_Shipment = 2,
        Shipped,
        Completed
    }
}