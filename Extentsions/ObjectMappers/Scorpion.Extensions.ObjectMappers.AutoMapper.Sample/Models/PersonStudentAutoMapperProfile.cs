namespace Zamin.Extensions.ObjectMappers.AutoMapper.Sample.Models
{
    public class PersonStudentAutoMapperProfile
    {
        CreateMap<Person, Student>().ReverseMap();
    }
}
