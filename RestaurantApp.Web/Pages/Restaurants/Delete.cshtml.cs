using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;

public class DeleteModel(IRestaurantService restaurantService) : PageModel
{
    private readonly IRestaurantService _restaurantService = restaurantService;

    [BindProperty]
    public required Restaurant Restaurant { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Restaurant = await _restaurantService.GetByIdAsync(id);
        if (Restaurant == null)
            return RedirectToPage("Index");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _restaurantService.DeleteAsync(Restaurant.Id);
        await _restaurantService.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
