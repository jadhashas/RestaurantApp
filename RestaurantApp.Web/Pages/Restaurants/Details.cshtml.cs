using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;

public class DetailsModel(IRestaurantService restaurantService) : PageModel
{
    private readonly IRestaurantService _restaurantService = restaurantService;

    public required Restaurant Restaurant { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Restaurant = await _restaurantService.GetByIdAsync(id);
        if (Restaurant == null)
            return RedirectToPage("Index");

        return Page();
    }
}
