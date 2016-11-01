using System;
using System.Collections.Generic;
using Mettal.Models.Entities;

namespace Mettal.Models.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        protected readonly ApplicationDbContext Context;
        private Dictionary<string, object> repositories = new Dictionary<string, object>();
        private bool disposed;

        public UnitOfWork()
        {
            Context = ApplicationDbContext.Create();
        }

        public Repository<T> GetRepository<T>() where T : BaseEntity
        {
            var typeName = typeof(T).Name;

            if (repositories.ContainsKey(typeName))
            {
                return (Repository<T>)repositories[typeName];
            }

            var repo = new Repository<T>(Context);

            repositories.Add(typeName, repo);

            return repo;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposed = true;
            }
        }
    }
}