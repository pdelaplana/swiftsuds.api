namespace SwiftSuds.Application.Abstractions;
public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}
