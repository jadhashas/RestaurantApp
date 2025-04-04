using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces
{
    public interface IRestaurantService
    {
        Task<Restaurant> GetByIdAsync(int id);
        Task<List<Restaurant>> GetAllAsync();
        Task AddAsync(Restaurant restaurant);
        void Update(Restaurant restaurant);
        Task DeleteAsync(int id);

        Task SaveChangesAsync();
    }
}
