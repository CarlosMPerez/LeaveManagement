using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class EmployeeCollectionItemViewModel
{
    public string Id { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Display(Name = "Name")]
    public string FullName { get { return string.Format("{0} {1}", FirstName, LastName);  } }

    public string Email { get; set; }

    [Display(Name = "Joined")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy")]
    [DataType(DataType.Date)]
    public string DateJoined { get; set; }
}
