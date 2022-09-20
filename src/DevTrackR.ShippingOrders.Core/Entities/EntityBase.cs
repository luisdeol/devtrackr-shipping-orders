using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrackR.ShippingOrders.Core.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; private set; }
    }
}