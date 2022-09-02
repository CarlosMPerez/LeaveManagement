namespace LeaveManagement.Web.CustomExceptions;

public class NoLeaveAllocationForPeriodOrUserException : Exception
{
    public NoLeaveAllocationForPeriodOrUserException()
    {
    }

    public NoLeaveAllocationForPeriodOrUserException(string message)
        : base(message)
    {
    }

    public NoLeaveAllocationForPeriodOrUserException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
