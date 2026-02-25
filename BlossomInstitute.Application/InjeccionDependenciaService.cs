using BlossomInstitute.Application.Configuration;
using BlossomInstitute.Application.DataBase.Alumno.Command.CreateAlumno;
using BlossomInstitute.Application.DataBase.Alumno.Command.DesactivarAlumno;
using BlossomInstitute.Application.DataBase.Alumno.Command.UpdateAlumno;
using BlossomInstitute.Application.DataBase.Alumno.Queries.GetAll;
using BlossomInstitute.Application.DataBase.Alumno.Queries.GetById;
using BlossomInstitute.Application.DataBase.Curso.Commands.ActivarCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.CreateCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.DesactivarCurso;
using BlossomInstitute.Application.DataBase.Curso.Commands.UpdateCurso;
using BlossomInstitute.Application.DataBase.Login.Command;
using BlossomInstitute.Application.DataBase.Password.Command.ForgotPassword;
using BlossomInstitute.Application.DataBase.Password.Command.ResetPassword;
using BlossomInstitute.Application.DataBase.Profesor.Command.CreateProfesor;
using BlossomInstitute.Application.DataBase.Profesor.Command.DeleteProfesor;
using BlossomInstitute.Application.DataBase.Profesor.Command.UpdateProfesor;
using BlossomInstitute.Application.DataBase.Profesor.Queries.GetAllProfesores;
using BlossomInstitute.Application.DataBase.Profesor.Queries.GetById;
using BlossomInstitute.Application.Validator.Alumno;
using BlossomInstitute.Application.Validator.Curso;
using BlossomInstitute.Application.Validator.Login;
using BlossomInstitute.Application.Validator.Password;
using BlossomInstitute.Application.Validator.Profesor;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BlossomInstitute.Application
{
    public static class InjeccionDependenciaService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            // Login
            services.AddTransient<ILoginCommand, LoginCommand>();

            // Password
            services.AddTransient<IForgotPasswordCommand, ForgotPasswordCommand>();
            services.AddTransient<IResetPasswordCommand, ResetPasswordCommand>();

            // Profesor
            services.AddTransient<ICreateProfesorCommand, CreateProfesorCommand>();
            services.AddTransient<IUpdateProfesorCommand, UpdateProfesorCommand>();
            services.AddTransient<IDesactivarProfesorCommand, DesactivarProfesorCommand>();
            services.AddTransient<IGetAllProfesoresQuery, GetAllProfesoresQuery>();
            services.AddTransient<IGetProfesorByIdQuery, GetProfesorByIdQuery>();

            // Alumno
            services.AddTransient<ICreateAlumnoCommand, CreateAlumnoCommand>();
            services.AddTransient<IUpdateAlumnoCommand, UpdateAlumnoCommand>();
            services.AddTransient<IDesactivarAlumnoCommand, DesactivarAlumnoCommand>();
            services.AddTransient<IGetAllAlumnosQuery, GetAllAlumnosQuery>();
            services.AddTransient<IGetAlumnoByIdQuery, GetAlumnoByIdQuery>();

            // Curso

            services.AddTransient<ICreateCursoCommand, CreateCursoCommand>();
            services.AddTransient<IUpdateCursoCommand, UpdateCursoCommand>();
            services.AddTransient<IDesactivateCursoCommand, DesactivateCursoCommand>();
            services.AddTransient<IActivateCursoCommand, ActivateCursoCommand>();

            // Validators
            services.AddScoped<IValidator<LoginModel>, LoginValidator>();
            services.AddScoped<IValidator<ForgotPasswordModel>, ForgotPasswordValidator>();
            services.AddScoped<IValidator<ResetPasswordModel>, ResetPasswordValidator>();
            services.AddScoped<IValidator<CreateProfesorModel>, CreateProfesorValidator>();
            services.AddScoped<IValidator<UpdateProfesorModel>, UpdateProfesorValidator>();
            services.AddScoped<IValidator<CreateAlumnoModel>, CreateAlumnoValidator>();
            services.AddScoped<IValidator<UpdateAlumnoModel>, UpdateAlumnoValidator>();
            services.AddScoped<IValidator<CreateCursoModel>, CreateCursoValidator>();
            services.AddScoped<IValidator<CreateCursoHorarioModel>, CreateCursoHorarioValidator>();
            services.AddScoped<IValidator<UpdateCursoModel>, UpdateCursoValidator>();
            services.AddScoped<IValidator<UpdateCursoHorarioModel>, UpdateCursoHorarioValidator>();


            return services;
        }
    }
}
