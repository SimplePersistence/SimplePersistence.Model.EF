namespace SimplePersistence.Model.EF.Fluent
{
#if (NET40 || NET45)
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// Extension methods for Entity Framework code first mappings
    /// </summary>
    public static partial class CodeFirstMappingExtensions
    {
        /// <summary>
        /// Sets up a new entity in the given model and applies the configuration lambda to it
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="modelBuilder">The model builder to be used</param>
        /// <param name="configurations">The lambda which applies the configuration</param>
        /// <returns>The entity configuration</returns>
        /// <exception cref="ArgumentNullException"/>
        public static EntityTypeConfiguration<T> Entity<T>(
            this DbModelBuilder modelBuilder, Action<EntityTypeConfiguration<T>> configurations) 
            where T : class
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));
            if (configurations == null) throw new ArgumentNullException(nameof(configurations));

            var entityTypeConfiguration = modelBuilder.Entity<T>();
            configurations(entityTypeConfiguration);
            return entityTypeConfiguration;
        }

        /// <summary>
        /// Sets up a new entity in the given model and applies the configuration lambda to it
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="modelBuilder">The model builder to be used</param>
        /// <param name="configurations">The lambda which applies the configuration</param>
        /// <param name="tableName">The table name</param>
        /// <param name="schemaName">If specified, the schema name</param>
        /// <returns>The entity configuration</returns>
        /// <exception cref="ArgumentNullException"/>
        public static EntityTypeConfiguration<T> Entity<T>(
            this DbModelBuilder modelBuilder, Action<EntityTypeConfiguration<T>> configurations,
            string tableName, string schemaName = null) 
            where T : class
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));
            if (configurations == null) throw new ArgumentNullException(nameof(configurations));
            if (tableName == null) throw new ArgumentNullException(nameof(tableName));

            var entityTypeConfiguration = modelBuilder.Entity(configurations);

            if (schemaName == null)
                entityTypeConfiguration.ToTable(tableName);
            else
                entityTypeConfiguration.ToTable(tableName, schemaName);

            configurations(entityTypeConfiguration);
            return entityTypeConfiguration;
        }
    }
#endif
}
