using CRUD_OPERATION.Entities;
using CRUD_OPERATION.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_OPERATION
{
    public class Repo : IRepo
    {
        private DataContext _dataContext;
        public Repo(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public void Create<T>(T entity) where T : BaseEntity
        {
            var dbset = _dataContext.Set<T>();
            entity.CreatedDateTime = DateTime.Now;
            entity.UpdatedDateTime = DateTime.Now;
            dbset.Add(entity);
        }
        public T Read<T>(int Id) where T : BaseEntity
        {
            var dbset = _dataContext.Set<T>();
            var entity = dbset.FirstOrDefault(x => x.Id == Id);
            return entity;
        }
        public void Update<T>(T entity) where T : BaseEntity
        {
            var dbset = _dataContext.Set<T>();
            var Updateentity = dbset.FirstOrDefault(x => x.Id == entity.Id);

            if (Updateentity != null)
            {
                Updateentity = entity;
            }

        }
        public void Delete<T>(int Id) where T : BaseEntity
        {
            var dbset = _dataContext.Set<T>();
            var entity = dbset.FirstOrDefault(x => x.Id == Id);
            if (entity != null)
            {
                entity.UpdatedDateTime = DateTime.Now;
                entity.IsDeleted = true;
            }
        }
        public void CommitTransacton()
        {
            _dataContext.SaveChanges();
        }

        public List<T> GetAll<T>() where T : BaseEntity
        {
            var dbset = _dataContext.Set<T>();
            List<T> entity = dbset.Where(c => c.IsDeleted == false).ToList();
            return entity;
        }
    }
}
