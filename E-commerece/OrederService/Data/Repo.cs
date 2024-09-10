using Azure;
using OrderService.Models;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;


namespace OrderService.Data
{
    public class Repo : IRepo
    {
        private readonly OrderDbContext _context;
        private readonly HttpClient _httpClientUser = new HttpClient();
        private readonly HttpClient _httpClientProduct = new HttpClient();
        public Repo()
        {
            _context = new OrderDbContext();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            _httpClientUser.BaseAddress = new Uri(config.GetConnectionString("UserServer")!);
            _httpClientUser.DefaultRequestHeaders.Accept.Clear();
            _httpClientUser.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClientProduct.BaseAddress = new Uri(config.GetConnectionString("ProductServer")!);
            _httpClientProduct.DefaultRequestHeaders.Accept.Clear();
            _httpClientProduct.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList() ?? [];
        }

        public Order? GetOrderById(int Id)
        {
            return _context.Orders.FirstOrDefault(x => x.Id == Id);
        }

        public async Task<bool> PlaceOrder(int UserId, int OrderId, int Ammount)
        {
            try
            {

                //checks if the endpoint returns something if it does we add the order since the entries are valid
                HttpResponseMessage responseUser = await _httpClientUser.GetAsync($"api/User/GetUserById{UserId}");
                HttpResponseMessage responseProduct = await _httpClientProduct.GetAsync($"api/Products/GetbyId{OrderId}");

                Console.WriteLine(responseUser.StatusCode.ToString());
                Console.WriteLine(responseProduct.StatusCode.ToString());
                if(responseUser.StatusCode.ToString() == "OK" && responseProduct.StatusCode.ToString() == "OK")
                {
                    Console.WriteLine("suucee");
                    _context.Orders.Add(new Order { UserId = UserId, OrderId = OrderId, Ammount = Ammount });
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (HttpRequestException e)
            { 
                Console.WriteLine($"Request error: {e.Message}");
                return false;
            }
        }
    }
}
