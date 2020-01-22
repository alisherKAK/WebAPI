using AutoMapper;

namespace Domain.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Config()
        {
            return new MapperConfiguration(c =>
            {
                c.AddProfile(new CarProfile());
            }).CreateMapper();
        }
    }
}
