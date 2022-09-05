namespace LeaveManagement.Business.CustomExceptions;

public class TotalLeaveRequestTimeExceedsAllocationException : Exception
{
    public TotalLeaveRequestTimeExceedsAllocationException()
    {
    }

    public TotalLeaveRequestTimeExceedsAllocationException(string message)
        : base(message)
    {
    }

    public TotalLeaveRequestTimeExceedsAllocationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
