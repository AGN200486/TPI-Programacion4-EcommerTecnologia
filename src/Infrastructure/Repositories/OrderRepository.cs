using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

// Hereda la funcionalidad generica de Repository<Order> e implementa IOrderRepository
public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationContext context) : base(context)
    {
    }
    
}