using OrderService.Models;

namespace OrderService.Data
{
    public interface IRepo
    {
        Task<bool> PlaceOrder(int UserId, int OrderId, int Ammount);
        List<Order> GetAllOrders();
        Order? GetOrderById(int Id);
    }
}
