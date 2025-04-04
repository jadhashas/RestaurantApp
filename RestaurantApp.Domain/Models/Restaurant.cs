using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Domain.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Adresse { get; set; }
        public required string Cuisine { get; set; }
        public double Note { get; set; }
        public string? ImagePath { get; set; }
    }
}
