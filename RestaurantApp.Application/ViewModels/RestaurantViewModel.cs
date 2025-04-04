using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Application.ViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [MaxLength(100)]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'adresse est requise.")]
        public string Adresse { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Cuisine { get; set; } = string.Empty;

        [Range(0, 5, ErrorMessage = "La note doit être entre 0 et 5.")]
        public double Note { get; set; }

        public string? ImagePath { get; set; }
    }
}
