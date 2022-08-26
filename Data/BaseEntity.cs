namespace LeaveManagement.Web.Data;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

}
