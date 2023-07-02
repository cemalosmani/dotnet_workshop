using AutoMapper;
using DTOLayer.DTOs;
using EntityLayer.Concrete;

namespace ResumeDemo.Mapping.AutoMapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Admin, AdminDTO>();
        CreateMap<AdminDTO, Admin>();
        
        CreateMap<Contact, ContactDTO>();
        CreateMap<ContactDTO, Contact>();
        
        CreateMap<Education, EducationDTO>();
        CreateMap<EducationDTO, Education>();
        
        CreateMap<Experience, ExperienceDTO>();
        CreateMap<ExperienceDTO, Experience>();
        
        CreateMap<Language, LanguageDTO>();
        CreateMap<LanguageDTO, Language>();
        
        CreateMap<Skill, SkillDTO>();
        CreateMap<SkillDTO, Skill>();
    }
}