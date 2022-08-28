using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Configuration;

public class MapperConfig : Profile
{
	public MapperConfig()
	{
		CreateMap<LeaveType, LeaveTypeCollectionItemViewModel>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeCreateViewModel>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeEditViewModel>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsViewModel>().ReverseMap();
    }
}
