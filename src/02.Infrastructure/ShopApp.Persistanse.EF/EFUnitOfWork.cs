using ShopApp.Services.Contracts;

namespace ShopApp.Persistanse.EF;

public class EFUnitOfWork : UnitOfWork
{
    private readonly EFDataContext _context;

    public EFUnitOfWork(EFDataContext context)
    {
        _context = context;
    }
    public void Complete()
    {
        _context.SaveChanges();
    }
}