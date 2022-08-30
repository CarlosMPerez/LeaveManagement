using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Configuration;

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
    }
}
