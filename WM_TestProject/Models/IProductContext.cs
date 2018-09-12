using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WM_TestProject.Models
{
    public interface IProductContext : IDisposable
    {
        IDbSet<Product> Products { get; set; }
        int SaveChanges();
        
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}