using Microsoft.AspNetCore.SignalR;
using OrderRestaurant.DataAccessLayer.Concrete;

namespace OrderRestaurantAPI.Hubs
{
    public class SignalRHub:Hub
    {
        OrderRestaurantContext context = new OrderRestaurantContext();
        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("RecieveCategoryCount", value);
        }
    }
}
