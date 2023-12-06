
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repostories;
        private readonly streamerDbContext _context;
        private IVideoRepository _videoRepository;
        private IStreamerRepository _streamerRepository;

        public IVideoRepository VideoRepository => _videoRepository??=new VideoRepository(_context);
        public IStreamerRepository StreamerRepository => _streamerRepository ??= new StreamerRepository(_context);
        public UnitOfWork(streamerDbContext context)
        {
            
            _context = context;
        }
        public streamerDbContext StreamerDbContext => _context;
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repostories == null) {
                _repostories = new Hashtable();
            }
            var type = typeof(TEntity).Name;
            if (!_repostories.ContainsKey(type)) { 
                var repositoryType= typeof(RepositoryBase<>);
                var repositoryInstane = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
                _repostories.Add(type, repositoryInstane);
            }

            return (IAsyncRepository<TEntity>)_repostories[type];
        }
    }
}
