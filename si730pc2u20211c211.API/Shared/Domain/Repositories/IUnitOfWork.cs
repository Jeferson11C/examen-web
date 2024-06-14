namespace si730pc2u20211c211.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}