using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Comman;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Services
{
    public abstract class AbstractService
    {
        public AbstractService(ApplicationDbContext context)
        {
            Context = context;
        }

        public void InsertEntity(AbstractEntity entity)
        {
            using (var trans = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Add(entity);
                    Context.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void UpdateEntity(AbstractEntity entity)
        {
            using (var trans = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    Context.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void DeleteEntity(AbstractEntity entity)
        {
            using (var trans = Context.Database.BeginTransaction())
            {
                try
                {
                    if (entity != null)
                    {
                        Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                        Context.Remove(entity);
                        Context.SaveChanges();
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public ApplicationDbContext Context { get; set; }
    }
}
