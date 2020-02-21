using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class ChefDishesViewModel
    {
        public Dish Food {get;set;}
        public List<Chef> Cooks {get;set;}
    }
}
