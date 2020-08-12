using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter teacher name")]
        [Display(Name = "Teacher")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter contact no")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please select a designation")]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please select a department")]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter the desired credit")]
        [Display(Name = "Credit to be taken")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Credit must be positive")]
        public decimal CreditToBeTaken { get; set; }
        public decimal RemainingCredit { get; set; }
    }
}