using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    //private readonly ApplicationDbContext context;
    public LeaveTypeRepository(ApplicationDbContext context) : base(context)
    {
        //this.context = context;
    }
}
