using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LeaveManagement.Common.Models;

public class LeaveAllocationEditViewModel
{
    [Required]
    public int Id { get; set; }

    [Display(Name = "Number of Days")]
    [Required]
    [Range(1, 50, ErrorMessage = "Invalid number entered")]
    public int NumberOfDays { get; set; }

    public int LeaveTypeId { get; set; }

    public LeaveTypeEditViewModel? LeaveType { get; set; }

    public string EmployeeId { get; set; }

    public EmployeeEditViewModel? Employee { get; set; }
}
