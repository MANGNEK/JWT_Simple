using JWT_Simple.Context;
using JWT_Simple.Interface;

namespace JWT_Simple.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JwtContext _jwtContext;
        public UnitOfWork(JwtContext jwtContext)
        {
            _jwtContext = jwtContext;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public int Save()
        {
            return _jwtContext.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) Dispose(disposing);
        }
    }
}
