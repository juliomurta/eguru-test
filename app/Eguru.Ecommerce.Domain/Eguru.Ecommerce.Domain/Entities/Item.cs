using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Domain.Entities
{
    public class Item
    {
        public virtual int OrderId { get; set; }

        public virtual int ProductId { get; set; }

        public virtual int Quantity { get; set; }

        public virtual decimal Price { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Item;

            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return this.ProductId == other.ProductId &&
                this.OrderId == other.OrderId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ this.ProductId.GetHashCode();
                hash = (hash * 31) ^ this.OrderId.GetHashCode();

                return hash;
            }
        }
    }
}
