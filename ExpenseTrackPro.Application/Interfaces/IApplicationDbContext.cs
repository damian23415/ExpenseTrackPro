namespace ExpenseTrackPro.Application.Interfaces;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync();
}