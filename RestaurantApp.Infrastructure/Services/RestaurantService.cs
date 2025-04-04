using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence;

namespace RestaurantApp.Infrastructure.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly AppDbContext _context;

        public RestaurantService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Restaurant restaurant) =>
            await _context.Restaurants.AddAsync(restaurant);

        public async Task DeleteAsync(int id)
        {
            var r = await _context.Restaurants.FindAsync(id);
            if (r != null) _context.Restaurants.Remove(r);
        }

        public async Task<List<Restaurant>> GetAllAsync() =>
            await _context.Restaurants.ToListAsync();

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await _context.Restaurants.FindAsync(id) ?? throw new KeyNotFoundException($"Aucun restaurant avec l'ID {id}");
        }

        public void Update(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
