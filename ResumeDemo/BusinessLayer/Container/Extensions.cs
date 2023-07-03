using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container;

public static class Extensions
{
    public static void ContainerDependency(this IServiceCollection services)
    {
        services.AddScoped<IAdminService, AdminManager>();
        services.AddScoped<IAdminDal, EFAdminRepository>();
        
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IContactDal, EFContactRepository>();
        
        services.AddScoped<IEducationService, EducationManager>();
        services.AddScoped<IEducationDal, EFEducationRepository>();
        
        services.AddScoped<IExperienceService, ExperienceManager>();
        services.AddScoped<IExperienceDal, EFExperienceRepository>();
        
        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<ILanguageDal, EFLanguageRepository>();
        
        services.AddScoped<ISkillService, SkillManager>();
        services.AddScoped<ISkillDal, EFSkillRepository>();

        services.AddScoped<IProjectService, ProjectManager>();
        services.AddScoped<IProjectDal, EFProjectRepository>();
    }
}