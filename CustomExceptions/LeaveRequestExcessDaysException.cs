namespace LeaveManagement.Web.CustomExceptions;

public class LeaveRequestExcessDaysException : Exception
{
    public LeaveRequestExcessDaysException()
    {
    }

    public LeaveRequestExcessDaysException(string message)
        : base(message)
    {
    }

    public LeaveRequestExcessDaysException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
