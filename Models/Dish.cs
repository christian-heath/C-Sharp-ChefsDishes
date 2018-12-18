using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace chefsdishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get; set;}

        [Display(Name = "Chef:")]
        public int ChefId {get; set;}
        
        public Chef Chef{get; set;}

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Name of Dish:")]
        public string Name{get; set;}

        [Required]
        [Range(1,10000)]
        [Display(Name = "# of Calories:")]
        public int Calories{get;set;}

        [Required]
        [Range(1,6)]
        [Display(Name = "Tastiness:")]
        public int Tastiness{get;set;}

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        [Display(Name = "Description:")]
        public string Description{get; set;}
        public DateTime CreatedAt{get; set;}
        public DateTime UpdatedAt{get; set;}
    }
}