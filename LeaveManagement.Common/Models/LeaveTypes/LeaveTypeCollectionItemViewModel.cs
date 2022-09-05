using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models;

public class LeaveTypeCollectionItemViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    [Display(Name="Default Number of Leave Days")]
    public int DefaultDays { get; set; }
}
