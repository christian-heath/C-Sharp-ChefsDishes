using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace chefsdishes.Models
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }
        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if(dt <= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}

        public List<Dish> Dishes {get; set;}

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "First Name:")]
        public string FirstName{get; set;}

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Last Name:")]
        public string LastName{get; set;}

        [CurrentDate]
        [Required]
        public DateTime BirthDate{get; set;}
        public DateTime CreatedAt{get; set;}
        public DateTime UpdatedAt{get; set;}

        [NotMapped]
        public int Total{get;set;}
        public int CalculateAge(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Year - dob.Year;
            if(DateTime.Now.DayOfYear < dob.DayOfYear)
            {
                age -= 1;
            }
            return age;
        }
    }
}