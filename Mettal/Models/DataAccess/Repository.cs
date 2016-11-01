using System.Data.Entity;
using System.Linq;
using Mettal.Models.Entities;

namespace Mettal.Models.DataAccess
{
    public class Repository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;
		protected readonly IDbSet<T> Items;

        public Repository(DbContext context)
		{
			Context = context;
            Items = context.Set<T>();
		}

		public virtual T GetById(object id)
		{
			T result = Items.Find(id);
		    if (result == null || result.IsDeleted)
		    {
		        return null;
		    }
		    return result;
		}

		public virtual IQueryable<T> GetAll()
		{
			return Items.Where(i => !i.IsDeleted);
		}

		public virtual T Create(T item)
		{
			item = Items.Add(item);
			return item;
		}

		public virtual T Update(T item)
		{
			Context.Entry(item).State = EntityState.Modified;
			return item;
		}

		public virtual T Delete(object id)
		{
		    T item = GetById(id);

		    if (item != null)
		    {
                item.IsDeleted = true;
                Update(item);
		    }
		        
			return item;
		}
    }
}