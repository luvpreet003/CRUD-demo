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
            services.AddSingleton<ISchoolService, SchoolService>();
            services.AddSingleton<ISchoolRepository, SchoolReposirtory>();
            services.AddSingleton<IStudentService, StudentService>();
            services.AddSingleton<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
