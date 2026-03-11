using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Dashboard.Queries.GetAlumnoDashboard
{
    public interface IGetAlumnoDashboardQuery
    {
        Task<BaseResponseModel> Execute(int userId, CancellationToken ct = default);
    }
}
