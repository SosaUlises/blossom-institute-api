using BlossomInstitute.Domain.Model;

namespace BlossomInstitute.Application.DataBase.Dashboard.Queries.GetProfesorDashboard
{
    public interface IGetProfesorDashboardQuery
    {
        Task<BaseResponseModel> Execute(int userId, CancellationToken ct = default);
    }
}
