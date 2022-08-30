using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveTypeDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "Leave Type Name")]
    public string Name { get; set; }

    [Display(Name = "Default Number of Leave Days")]
    public int DefaultDays { get; set; }

    [Display(Name = "Creation Date")]
    public DateTime CreationDate { get; set; }
    
    [Display(Name = "Modification Date")] 
    public DateTime ModificationDate { get; set; } // I need it so I don't lose it?

}
