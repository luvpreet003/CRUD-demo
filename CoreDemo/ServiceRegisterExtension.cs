using CoreDemoCore.Commands.Authentication;
using CoreDemoCore.Commands.StudentServices;
using CoreDemoCore.Infrastructure;
using CoreDemoRepositories.SchoolRepository;
using CoreDemoRepositories.Student;
using CoreDemoServices.SchoolServices;

namespace CoreDemoAPI
{
    public static class ServiceRegisterExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ISchoolRepository, SchoolReposirtory>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<JwtService>();
            return services;
        }
    }
}
