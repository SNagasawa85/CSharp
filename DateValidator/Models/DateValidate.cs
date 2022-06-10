namespace DateValidator.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


public class NewDate
{
    [Required]
    [FutureDate]

    public DateTime ChosenDate {get; set;}
}

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Assign a new variable to today
        DateTime comp = (DateTime)value;
        // check our inputted date against that
        if(comp.Date > DateTime.Today.Date)
        {
            return new ValidationResult("You Cannot Choose a Date in the Future!!!");
        }
        return ValidationResult.Success;

    }
}

