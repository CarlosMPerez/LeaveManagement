using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;
public class EmployeeEditViewModel
{
    public string Id { get; set; }

    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Display(Name = "Name")]
    public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

}
