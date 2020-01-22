using AutoMapper;
using Domain.DTO;
using Domain.Resources;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>();
            CreateMap<CarDTO, CarResource>();
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<CarDTO, CarResource>().ReverseMap();
        }
    }
}
