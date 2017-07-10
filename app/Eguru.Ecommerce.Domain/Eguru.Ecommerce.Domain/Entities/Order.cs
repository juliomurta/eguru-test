using Eguru.Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Domain.Entities
{
    public class Order
    {
        public virtual int Id { get; set; }

        public virtual decimal Total
        {
            get
            {
                if (this.Items != null)
                {
                    decimal total = 0;

                    foreach (var item in this.Items)
                    {
                        total += item.Quantity * item.Price;
                    }

                    return total;
                }
                else
                {
                    return 0;
                }                
            }

            set { }
        }

        public virtual int FormOfPayment { get; set; }

        public virtual IList<Item> Items { get; set; }
    }
}
