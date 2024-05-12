namespace JWT_Simple.Interface;

public interface IUnitOfWork : IDisposable
{
    int Save();
}
