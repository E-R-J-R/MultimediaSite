using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimeSatellite.Domain.Entities;

namespace AnimeSatellite.Domain
{
    public interface IAnimationContext : IDisposable
    {
        DbSet<NEWS> NEWS { get; set; }
        DbSet<MOVIE> MOVIE { get; set; }
        DbSet<MOVIELINK> MOVIELINK { get; set; }

        int SaveChanges();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        IEnumerable<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);
    }
}
