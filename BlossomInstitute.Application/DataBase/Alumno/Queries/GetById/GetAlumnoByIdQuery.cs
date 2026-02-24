using AutoMapper;
using BlossomInstitute.Application.DataBase.Alumno.Queries.GetAll;
using BlossomInstitute.Common.Features;
using BlossomInstitute.Domain.Entidades.Usuario;
using BlossomInstitute.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BlossomInstitute.Application.DataBase.Alumno.Queries.GetById
{
    public class GetAlumnoByIdQuery : IGetAlumnoByIdQuery
    {
        private readonly UserManager<UsuarioEntity> _userManager;
        private readonly IMapper _mapper;

        public GetAlumnoByIdQuery(UserManager<UsuarioEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<BaseResponseModel> Execute(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Alumno no encontrado");

            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Alumno"))
                return ResponseApiService.Response(StatusCodes.Status404NotFound, "Alumno no encontrado");

            return ResponseApiService.Response(StatusCodes.Status200OK, _mapper.Map<GetAlumnoModel>(user));
        }
    }
}
