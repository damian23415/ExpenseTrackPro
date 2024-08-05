using AutoMapper;
using ExpenseTraackPro.Domain.Entities;
using ExpenseTraackPro.Domain.Entities.Identity;
using ExpenseTrackPro.Application.DTOs.Auth;
using ExpenseTrackPro.Application.DTOs.Categories;

namespace ExpenseTrackPro.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<ApplicationUser, UserEditDTO>();
            CreateMap<UserEditDTO, ApplicationUser>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
