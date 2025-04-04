using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Application.ViewModels;


namespace RestaurantApp.Web.Pages.Restaurants
{
    public class IndexModel(IRestaurantService restaurantService, IMapper mapper) : PageModel
    {
        private readonly IRestaurantService _restaurantService = restaurantService;
        private readonly IMapper _mapper = mapper;

        public List<RestaurantViewModel> Restaurants { get; set; } = new();

        public async Task OnGetAsync()
        {
            var entities = await _restaurantService.GetAllAsync();
            Restaurants = _mapper.Map<List<RestaurantViewModel>>(entities);
        }
    }
}
