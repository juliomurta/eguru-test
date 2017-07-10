using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Domain.Entities
{
    public class Product
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
               
        public virtual int Quantity { get; set; }
                               
        public virtual decimal Price { get; set; }
               
        public virtual string ImagePath { get; set; }

        public virtual bool IsAvailable
        {
            get
            {
                return this.Quantity > 0;
            }
        }
    }
}
