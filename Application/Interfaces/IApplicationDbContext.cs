namespace Application.Interfaces;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync();
}