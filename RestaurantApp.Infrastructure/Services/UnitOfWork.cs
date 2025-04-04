using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence;

namespace RestaurantApp.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRestaurantService Restaurants { get; }

        public UnitOfWork(AppDbContext context, IRestaurantService restaurantService)
        {
            _context = context;
            Restaurants = restaurantService;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
