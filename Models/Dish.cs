using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        [Display(Name="Dish Name")]
        public string Name {get;set;}
        [Required]
        [Range(0, 5000, ErrorMessage = "Calories must be greater than 0")]
        public int Calories {get;set;}
        [Required]
        [Range(1,5, ErrorMessage = "Tastiness range must 1-5")]
        public int Tastiness {get;set;}
        [Required]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int ChefId {get;set;}
        public Chef Chef {get;set;}

    }
}
