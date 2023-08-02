namespace ShopApp.Services.Contracts;

public interface UnitOfWork
{
    void Complete();
}