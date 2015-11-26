﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Crap.Data.Entities.Common;
using Crap.Data.Providers.EF.Mappings;

namespace Crap.Data.Providers.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("name=DefaultConnection")
        {
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(BaseMap<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
