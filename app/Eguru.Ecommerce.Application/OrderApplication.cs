using Eguru.Ecommerce.Domain.Entities;
using Eguru.Ecommerce.Domain.Interfaces;
using Eguru.Ecommerce.Infra.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eguru.Ecommerce.Application
{
    public class OrderApplication
    {
        protected IProductRepository productRepository = null;
        protected IOrderRepository orderRepository = null;
        protected IItemRepository itemRepository = null;

        public OrderApplication(ISession session)
        {
            this.productRepository = new ProductRepository(session);
            this.orderRepository = new OrderRepository(session);
            this.itemRepository = new ItemRepository(session);
        }

        public void Save(Order order)
        {
            this.orderRepository.BeginTransaction();
            var orderId = this.orderRepository.Create(order);
            
            foreach (var item in order.Items)
            {
                var product = this.productRepository.Get(item.Product.Id);

                if (!product.IsAvailable || (product.Quantity - item.Quantity) < 0)
                {
                    throw new Exception("Não há itens em estoque ou estoque insuficiente");
                }

                item.OrderId = orderId;
                item.ProductId = product.Id;                                
                this.itemRepository.Create(item);

                product.Quantity -= item.Quantity;
                this.productRepository.Edit(product);
            }

            this.orderRepository.Commit();
        }
    }
}
