using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Business.Configuration;

public class MapperConfig : Profile
{
	public MapperConfig()
	{
        CreateMap<LeaveType, LeaveTypeCollectionItemViewModel>();
        CreateMap<LeaveType, LeaveTypeCreateViewModel>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeEditViewModel>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsViewModel>();

        //.ForMember(dest => dest.Alpha2, opt => opt.MapFrom(src => src.ShortName.Substring(0, 2).ToUpper()))
        CreateMap<Employee, EmployeeCollectionItemViewModel>()
            .ForMember(dest => dest.DateJoined, opt => opt.MapFrom(src => src.DateJoined.Value.ToString("dd/MM/yyyy")));

        CreateMap<Employee, EmployeeCreateViewModel>().ReverseMap();
        CreateMap<Employee, EmployeeEditViewModel>().ReverseMap();
        CreateMap<Employee, EmployeeAllocationViewModel>().ReverseMap();

        CreateMap<LeaveAllocation, LeaveAllocationCollectionItemViewModel>();
        CreateMap<LeaveAllocation, LeaveAllocationEditViewModel>().ReverseMap();

        CreateMap<LeaveRequest, LeaveRequestCreateViewModel>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestViewModel>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestCollectionItemViewModel>()
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.RequestDate, opt => opt.MapFrom(src => src.RequestDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.Approved, opt => opt.MapFrom(src => src.Approved.HasValue ? (src.Approved.Value ? "Approved" : "Rejected") : "Pending"))
            .ForMember(dest => dest.Cancelled, opt => opt.MapFrom(src => src.Cancelled ? "Yes" : "No"))
            .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.LeaveType.Name))
            .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => string.Format("{0} {1}", src.Employee.FirstName, src.Employee.LastName)));
    }
}
