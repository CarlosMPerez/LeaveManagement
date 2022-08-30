using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class EmployeeAllocationViewModel
{
    public string Id { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    public List<LeaveAllocationCollectionItemViewModel> LeaveAllocations { get; set; }

}
