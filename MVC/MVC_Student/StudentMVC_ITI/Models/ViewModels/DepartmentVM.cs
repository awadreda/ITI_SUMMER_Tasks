
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentMVC_ITI.Models.ViewModels
{
    public class DepartmentVM
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name="Department Name")]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Location { get; set; } = string.Empty;

        public IEnumerable<SelectListItem>? Locations { get; set; }
    }
}
