using LeaveManagement.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace LeaveManagement.Web.Models;

public class LeaveAllocationEditViewModel
{
    LeaveTypeCollectionItemViewModel _leave;
    EmployeeCollectionItemViewModel _employee;

    [Required]
    public int Id { get; set; }

    [Display(Name = "Number of Days")]
    [Required]
    [Range(1, 50, ErrorMessage = "Invalid number entered")]
    public int NumberOfDays { get; set; }

    [Required]
    [Display(Name ="Allocation Period")]
    public int Period { get; set; }

    public LeaveTypeCollectionItemViewModel LeaveType 
    { 
        get { return _leave; } 
        
        set 
        {
            _leave = value;
            this.LeaveTypeSerialized = JsonSerializer.Serialize(_leave); 
        } 
    }

    public EmployeeCollectionItemViewModel Employee 
    { 
        get { return _employee;  }
        set
        {
            _employee = value;
            this.EmployeeSerialized = JsonSerializer.Serialize(_employee);
        }
    }

    public string EmployeeSerialized { get; set; }
    public string LeaveTypeSerialized { get; set; }

    //public DateTime CreationDate { get; set; }
    //public DateTime ModificationDate { get; set; }

}
