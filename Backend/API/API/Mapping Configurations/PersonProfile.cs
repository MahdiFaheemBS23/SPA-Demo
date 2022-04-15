using API.DTOs;
using AutoMapper;
using Data.Entity;

namespace API.Mapping_Configurations
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonDTO, Person>().ReverseMap();
        }
    }
}
