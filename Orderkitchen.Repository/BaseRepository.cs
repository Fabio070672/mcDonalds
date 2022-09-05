using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderKitchen.Repository.Context;
namespace OrderKitchen.Repository
{
    public class BaseRepository<T> where T : class
    {
        internal readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task Add(T entity)
        {

            try
            {
                Type entityType = typeof(T);

                PropertyInfo CreatedAtProperty = entityType.GetProperty("CreatedAt");

                if (CreatedAtProperty != null)
                {
                    CreatedAtProperty.SetValue(entity, DateTime.UtcNow);
                }

                PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdateddAt");

                if (UpdatedAtProperty != null)
                {
                    UpdatedAtProperty.SetValue(entity, DateTime.UtcNow);
                }
                await this._context.Set<T>().AddAsync(entity);
                await this._context.SaveChangesAsync();


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task Update(T entity)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Type entityType = typeof(T);

                    PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                    if (UpdatedAtProperty != null)
                    {
                        UpdatedAtProperty.SetValue(entity, DateTime.UtcNow);
                    }
                    await this._context.Set<T>().AddAsync(entity);

                    await this._context.SaveChangesAsync();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task BulkInsert(List<T> entities)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Type entityType = typeof(T);

                    foreach (var entity in entities)
                    {
                        PropertyInfo CreatedAtProperty = entityType.GetProperty("CreatedAt");

                        if (CreatedAtProperty != null)
                        {
                            CreatedAtProperty.SetValue(entity, DateTime.UtcNow);
                        }

                        PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                        if (UpdatedAtProperty != null)
                        {
                            UpdatedAtProperty.SetValue(entity, DateTime.UtcNow);
                        }

                        this._context.Add(entity);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }
        }

        public async Task BulkUpdate(List<T> entities)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    Type entityType = typeof(T);

                    foreach (var entity in entities)
                    {
                        PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                        if (UpdatedAtProperty != null)
                        {
                            UpdatedAtProperty.SetValue(entity, DateTime.UtcNow);
                        }

                        this._context.Set<T>().Update(entity);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }
        }

        public DbSet<T> Query()
        {
            return this._context.Set<T>();
        }

        public async Task Delete(T entity)
        {
            if (entity != null)
            {
                Type entityType = typeof(T);

                PropertyInfo activeProperty = entityType.GetProperty("Active");

                PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                using (var transaction = await this._context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // DELETE IF NOT EXISTS PROPERTY

                        if (activeProperty == null)
                        {
                            this._context.Set<T>().Remove(entity);
                        }
                        else // SET DELETED (TRUE) IF EXISTS AND SAVE
                        {
                            if (UpdatedAtProperty != null)
                            {
                                UpdatedAtProperty.SetValue(entity, DateTime.UtcNow);
                            }

                            activeProperty.SetValue(entity, false);

                            this._context.Set<T>().Update(entity);
                        }

                        await this._context.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw ex;
                    }
                }
            }
            else
            {
                throw new ApplicationException("Object Not Found");
            }
        }

        public async Task Delete(List<T> entities)
        {
            using (var transaction = await this._context.Database.BeginTransactionAsync())
            {
                foreach (var entity in entities)
                {
                    Type entityType = typeof(T);

                    PropertyInfo activeProperty = entityType.GetProperty("Active");

                    PropertyInfo UpdatedAtProperty = entityType.GetProperty("UpdatedAt");

                    try
                    {
                        // DELETE IF NOT EXISTS PROPERTY

                        if (activeProperty == null)
                        {
                            this._context.Set<T>().Remove(entity);
                        }
                        else // SET DELETED (TRUE) IF EXISTS AND SAVE
                        {
                            if (UpdatedAtProperty != null)
                            {
                                UpdatedAtProperty.SetValue(entity, DateTime.UtcNow);
                            }

                            activeProperty.SetValue(entity, false);

                            this._context.Set<T>().Update(entity);
                        }

                        await this._context.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        throw ex;
                    }
                }
            }
        }
    }
}