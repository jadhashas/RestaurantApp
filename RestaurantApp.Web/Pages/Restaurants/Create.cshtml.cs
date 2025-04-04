using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Application.ViewModels;
using RestaurantApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantApp.Web.Pages.Restaurants
{
    public class CreateModel(
        IRestaurantService restaurantService,
        IImageUploadService imageUploadService,
        IMapper mapper,
        IUnitOfWork unitOfWork) : PageModel
    {
        private readonly IRestaurantService _restaurantService = restaurantService;
        private readonly IImageUploadService _imageUploadService = imageUploadService;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public RestaurantViewModel Restaurant { get; set; } = new();

        [BindProperty]
        public IFormFile? Image { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Image != null)
            {
                try
                {
                    var imagePath = await _imageUploadService.UploadAsync(
                        Image.OpenReadStream(),
                        Image.ContentType,
                        Image.FileName
                    );
                    Restaurant.ImagePath = imagePath;
                }
                catch (InvalidDataException ex)
                {
                    ModelState.AddModelError("Image", ex.Message);
                    return Page();
                }
            }

            var entity = _mapper.Map<Restaurant>(Restaurant);
            await _restaurantService.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
