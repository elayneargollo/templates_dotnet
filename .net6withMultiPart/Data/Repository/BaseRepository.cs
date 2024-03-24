using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using arquivoApi.Models;
using Microsoft.EntityFrameworkCore;
using arquivoApi.Data.Interface;

namespace arquivoApi.Data.Repository
{
   public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySqlContext _context;
        private DbSet<T> dataset;
        private IExecutionStrategy strategy;

        public BaseRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
            strategy = _context.Database.CreateExecutionStrategy();
        }

        public async Task<T> Add(T item)
        {   
            try
            {
                strategy.Execute(() =>
                {
                    dataset.Add(item);
                    _context.SaveChangesAsync();
                });

                return item;
            }        
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(id));

            try
            {
                if (result != null)
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return dataset.Any(b => b.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return dataset.ToList();
        }
      
        public T GetById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public async Task<T> Update(T item)
        {
            if (!Exists(item.Id)) return null;

            var result = dataset.SingleOrDefault(b => b.Id == item.Id);

            if (result != null)
            {
                try
                {
                    strategy.Execute(() =>
                    {
                        _context.Entry(result).CurrentValues.SetValues(item);
                        _context.SaveChangesAsync();
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
            return result;
        }
    }
}