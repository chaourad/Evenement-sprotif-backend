
using AutoMapper;
using evenement.Dto;
using evenement.Dto.Evenement;
using evenement.Dto.Message;
using evenement.Dto.Type;
using evenement.Modals;

namespace evenement.Mapper
{
    public class AutoMapperProfile : Profile
    {
    public AutoMapperProfile(){
        CreateMap<CreateRoleDto , Role>();
        CreateMap<CreateEvemenet , Evenement>();
        CreateMap<CreateTypeDto , TypeEvn>();
        CreateMap<CreateMessageDto , Message>();
        CreateMap<Message, ResponseMessageDto>();
    }
    }
}