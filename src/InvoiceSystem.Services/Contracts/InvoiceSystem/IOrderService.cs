using InvoiceSystem.Entities.Invoice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Services.Contracts.InvoiceSystem
{
    public  interface IOrderService
    {
        Task<Order> FindAsync(int id,int userId);
        Task<List<Order>> GetAll(int userId);
        Task<Order> Create(Order order);
        Task<List<OrderDetail>> GetOrderDetailsByOrderId(int id);
        void Remove(Order order,int userId);
        void Update(Order order,int userId);
    }

}
