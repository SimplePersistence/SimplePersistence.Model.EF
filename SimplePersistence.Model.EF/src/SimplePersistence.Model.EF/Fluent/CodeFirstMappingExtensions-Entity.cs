#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 SimplePersistence
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
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
