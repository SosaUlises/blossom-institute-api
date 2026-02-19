using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Login.Command
{
    public interface ILoginCommand
    {
        Task<BaseResponseModel> Execute(LoginModel model);
    }
}
