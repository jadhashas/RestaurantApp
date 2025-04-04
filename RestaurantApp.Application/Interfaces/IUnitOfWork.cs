using System.Threading.Tasks;

namespace RestaurantApp.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRestaurantService Restaurants { get; }
        Task<int> SaveChangesAsync();
    }
}
