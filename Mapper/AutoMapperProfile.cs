
using AutoMapper;
using evenement.Dto;
using evenement.Modals;

namespace evenement.Mapper
{
    public class AutoMapperProfile : Profile
    {
    public AutoMapperProfile(){
        CreateMap<CreateRoleDto , Role>();
    }
    }
}