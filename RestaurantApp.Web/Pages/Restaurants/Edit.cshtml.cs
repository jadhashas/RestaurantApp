using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Application.ViewModels;
using RestaurantApp.Domain.Models;

public class EditModel(
        IRestaurantService restaurantService,
        IImageUploadService imageUploadService,
        IMapper mapper) : PageModel
{
    private readonly IRestaurantService _restaurantService = restaurantService;
    private readonly IImageUploadService _imageUploadService = imageUploadService;
    private readonly IMapper _mapper = mapper;

    [BindProperty]
    public RestaurantViewModel Restaurant { get; set; } = new();

    [BindProperty]
    public IFormFile? Image { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var entity = await _restaurantService.GetByIdAsync(id);
        if (entity == null) return RedirectToPage("Index");

        Restaurant = _mapper.Map<RestaurantViewModel>(entity);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        if (Image != null)
        {
            var imagePath = await _imageUploadService.UploadAsync(
                Image.OpenReadStream(),
                Image.ContentType,
                Image.FileName
            );
            Restaurant.ImagePath = imagePath;
        }

        var updatedEntity = _mapper.Map<Restaurant>(Restaurant);
        _restaurantService.Update(updatedEntity);
        await _restaurantService.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}
