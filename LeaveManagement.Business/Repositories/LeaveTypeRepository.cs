using LeaveManagement.Business.Contracts;
using LeaveManagement.Data;

namespace LeaveManagement.Business.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    //private readonly ApplicationDbContext context;
    public LeaveTypeRepository(ApplicationDbContext context) : base(context)
    {
        //this.context = context;
    }
}
