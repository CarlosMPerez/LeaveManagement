namespace LeaveManagement.Business.CustomExceptions;

public class NoLeaveAllocationForUserException : Exception
{
    public NoLeaveAllocationForUserException()
    {
    }

    public NoLeaveAllocationForUserException(string message)
        : base(message)
    {
    }

    public NoLeaveAllocationForUserException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
