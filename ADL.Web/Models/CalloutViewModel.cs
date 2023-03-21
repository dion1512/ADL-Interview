using ADL.Data.Entities;
using ADL.Repositories.Context;
using ADL.Services.Implementations;
using ADL.Services.Interfaces;
using ADL.Web.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADL.Web.Models
{
    public class CalloutViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Contact Number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string ContactNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name ="Choose a date")]
        public string DateBooked { get; set; }
        [Required]
        public string TimeSlot { get; set; }

        [Required]
        [Display(Name = "Vehicle Registration")]
        [StringLength(7,
        ErrorMessage = "Vehicle Registration has a maximum of 7 characters")]
        public string VehicleReg { get; set; }
        [Required]
        public int Category { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        [StringLength(500,
        ErrorMessage = "Comments has a maximum of 500 characters.")]
        public string? Notes { get; set; }
    }
}
