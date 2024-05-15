using JWT_Simple.Context;
using JWT_Simple.Interface;

namespace JWT_Simple.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JwtContext _jwtContext;


        public IUserRepository user { get; }

        public UnitOfWork(JwtContext jwtContext, IUserRepository user)
        {
            _jwtContext = jwtContext;
            this.user = user;
        }

        public int Save()
        {
            return _jwtContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _jwtContext.Dispose();
            }
        }
    }
}
