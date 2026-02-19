namespace BlossomInstitute.Application.DataBase
{
    public interface IDataBaseService
    {
        Task<bool> SaveAsync(CancellationToken ct = default);
    }
}

