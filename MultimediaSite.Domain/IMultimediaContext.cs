using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MultimediaSite.Domain.Entities;

namespace MultimediaSite.Domain
{
    public interface IMultimediaContext : IDisposable
    {
        DbSet<NEWS> NEWS { get; set; }
        DbSet<MOVIE> MOVIE { get; set; }
        DbSet<MOVIELINK> MOVIELINK { get; set; }
        DbSet<TAG> TAG { get; set; }
        DbSet<TAGMAP> TAGMAP { get; set; }

        int SaveChanges();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);
    }
}
