
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveRequestViewModel
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
    [DataType(DataType.Date)]
    public DateTime RequestDate { get; set; }

    public string? RequestComments { get; set; }

    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }

    public LeaveTypeCollectionItemViewModel LeaveType { get; set; }

    public EmployeeCollectionItemViewModel Employee { get; set; }

}
