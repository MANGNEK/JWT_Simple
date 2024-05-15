namespace JWT_Simple.Interface;

public interface IUnitOfWork 
{
    IUserRepository user { get; }
    int Save();
}
