using ShooesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShooesStore.Interface
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shipingDetails);
    }
}