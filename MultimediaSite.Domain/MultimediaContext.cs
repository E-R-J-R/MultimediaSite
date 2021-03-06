﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using MultimediaSite.Domain.Entities;

namespace MultimediaSite.Domain
{
    public class MultimediaContext : DbContext, IMultimediaContext
    {
        public MultimediaContext() : base ("name=MultimediaContext")
        {

        }

        static MultimediaContext()
        {
            Database.SetInitializer<MultimediaContext>(null);
        }

        public virtual DbSet<NEWS> NEWS { get; set; }
        public virtual DbSet<MOVIE> MOVIE { get; set; }
        public virtual DbSet<MOVIELINK> MOVIELINK { get; set; }
        public virtual DbSet<TAG> TAG { get; set; }
        public virtual DbSet<TAGMAP> TAGMAP { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public IEnumerable<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<TElement>(commandText, parameters).AsEnumerable<TElement>();
        } 
    }
}
