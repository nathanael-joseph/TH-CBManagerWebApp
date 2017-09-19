using System;
using ComicBookShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookShared.Data
{
    public abstract class BaseRepository<TEntity>
        where TEntity: class, IEntity, new()
    {
        protected Context Context = null;
        public BaseRepository(Context context)
        {
            Context = context;
        }
 
        public abstract TEntity Get(int id, bool IncludeRelatedEntities = true);
        public abstract IList<TEntity> GetList();
      
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }
        
        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            TEntity entity = new TEntity()
            {
                Id = id
            };
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
        }

    }
}
