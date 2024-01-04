using InvoiceSystem.DataLayer.Context;
using InvoiceSystem.Entities.Invoice;
using InvoiceSystem.Services.Contracts.InvoiceSystem;
using InvoiceSystem.ViewModels.InvoiceSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.InvoiceSystem
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _uow;
        private DbSet<Order> _order;
        private DbSet<OrderDetail> _orderDetails;

        public OrderService(
            IUnitOfWork uow
            )
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _order = uow.Set<Order>();
            _orderDetails = uow.Set<OrderDetail>();
        }


        //public void Create(Order order)
        //{
        //    _order.Add(order);
        //    _uow.SaveChangesAsync();
        //}
        public async Task<Order> Create(Order order)

        {
            //Order nOrder = new Order();
            //nOrder.OrderDetails = new List<OrderDetail>();

            //nOrder.BuyerId = order.BuyerId;
            //nOrder.CreatDatetime = order.CreatDatetime;
            //nOrder.OrderDatetime = order.OrderDatetime;

            _order.Add(order);

            //foreach (var od in order.OrderDetails)
            //{
            //    od.OrderId = nOrder.Id;
            //    nOrder.OrderDetails.Add(od);
            //}

            _orderDetails.AddRange(order.OrderDetails);
            await _uow.SaveChangesAsync();
            return order;
        }

        public void Update(Order order, int userId)
        {
            if (_order.Any(x => x.CreatedByUserId == userId && x.Id == order.Id))
            {
                order.CreatedByUserId = userId;
                _order.Update(order);
                _uow.SaveChangesAsync();
            }
        }
        public async Task<Order> FindAsync(int id, int userId)
        {
            return await _order.Include(x => x.OrderDetails).FirstOrDefaultAsync(x => x.CreatedByUserId == userId && x.Id == id);
        }

        public async Task<List<Order>> GetAll(int userId)
        {
            return await _order.Where(x => x.CreatedByUserId == userId).ToListAsync();
            //return await _order.ToListAsync();
        }


        public void Remove(Order order, int userId)
        {
            if (_order.Any(x => x.CreatedByUserId == userId && x.Id == order.Id))
            {
                _order.Remove(order);
                _uow.SaveChangesAsync();
            }
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByOrderId(int id)
        {
            return await _orderDetails.Where(x => x.OrderId == id).ToListAsync();
        }

    }
}
