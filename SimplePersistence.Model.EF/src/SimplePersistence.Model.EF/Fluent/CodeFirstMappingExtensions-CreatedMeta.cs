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
    using System;

#if (NET40 || NET45)
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;

    /// <summary>
    /// Extension methods for Entity Framework code first mappings
    /// </summary>
    public static partial class CodeFirstMappingExtensions
    {
        #region IHaveCreatedMeta

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="maxLength">
        /// The max length for the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> property. By default <see cref="DefaultMaxLength"/> will be used.
        /// </param>
        /// <param name="propertyCreatedOnNeedsIndex">
        /// Does <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index? By default <see cref="DefaultPropertyNeedsIndex"/> will be used.
        /// </param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static EntityTypeConfiguration<T> MapCreatedMeta<T>(this EntityTypeConfiguration<T> cfg, int maxLength = DefaultMaxLength, bool propertyCreatedOnNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveCreatedMeta<string>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var propertyConfiguration = cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyCreatedOnNeedsIndex)
                propertyConfiguration.AddIndex();
            cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(maxLength);

            return cfg;
        }

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="mapping">
        /// Optional extra mapping for the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> property.
        /// May be used to map the inverse relation.
        /// </param>
        /// <param name="propertyCreatedOnNeedsIndex">
        /// Does <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index? By default <see cref="DefaultPropertyNeedsIndex"/> will be used.
        /// </param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TCreatedBy">The type of the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> property</typeparam>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static EntityTypeConfiguration<T> MapCreatedMeta<T, TCreatedBy>(
            this EntityTypeConfiguration<T> cfg, Action<RequiredNavigationPropertyConfiguration<T, TCreatedBy>> mapping = null, bool propertyCreatedOnNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveCreatedMeta<TCreatedBy>
            where TCreatedBy : class
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var propertyCreatedOnConfiguration = cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyCreatedOnNeedsIndex)
                propertyCreatedOnConfiguration.AddIndex();
            var propertyConfiguration = cfg.HasRequired(e => e.CreatedBy);
            mapping?.Invoke(propertyConfiguration);

            return cfg;
        }

        #endregion

        #region IHaveLocalCreatedMeta

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="maxLength">
        /// The max length for the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> property. By default <see cref="DefaultMaxLength"/> will be used.
        /// </param>
        /// <param name="propertyCreatedOnNeedsIndex">
        /// Does <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index? By default <see cref="DefaultPropertyNeedsIndex"/> will be used.
        /// </param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static EntityTypeConfiguration<T> MapLocalCreatedMeta<T>(this EntityTypeConfiguration<T> cfg, int maxLength = DefaultMaxLength, bool propertyCreatedOnNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveLocalCreatedMeta
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var propertyConfiguration = cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyCreatedOnNeedsIndex)
                propertyConfiguration.AddIndex();
            cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(maxLength);

            return cfg;
        }

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="mapping">
        /// Optional extra mapping for the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> property.
        /// May be used to map the inverse relation.
        /// </param>
        /// <param name="propertyCreatedOnNeedsIndex">
        /// Does <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index? By default <see cref="DefaultPropertyNeedsIndex"/> will be used.
        /// </param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TCreatedBy">The type of the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> property</typeparam>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static EntityTypeConfiguration<T> MapLocalCreatedMeta<T, TCreatedBy>(
            this EntityTypeConfiguration<T> cfg, Action<RequiredNavigationPropertyConfiguration<T, TCreatedBy>> mapping = null, bool propertyCreatedOnNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveLocalCreatedMeta<TCreatedBy>
            where TCreatedBy : class
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var propertyCreatedOnConfiguration = cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyCreatedOnNeedsIndex)
                propertyCreatedOnConfiguration.AddIndex();
            var propertyConfiguration = cfg.HasRequired(e => e.CreatedBy);
            mapping?.Invoke(propertyConfiguration);

            return cfg;
        }

        #endregion
    }

#else
    
    using Microsoft.Data.Entity.Metadata.Builders;

    /// <summary>
    /// Extension methods for Entity Framework code first mappings
    /// </summary>
    [CLSCompliant(false)]
    public static partial class CodeFirstMappingExtensions
    {
    #region IHaveCreatedMeta

        public static EntityTypeBuilder<T> MapCreatedMeta<T>(
            this EntityTypeBuilder<T> cfg, int maxLength = DefaultMaxLength, bool propertyOnNeedsIndex = DefaultPropertyNeedsIndex, 
            bool propertyByNeedsIndex = DefaultPropertyNeedsIndex) 
            where T : class, IHaveCreatedMeta
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyOnNeedsIndex)
                cfg.HasIndex(e => e.CreatedOn);

            cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(maxLength);
            if (propertyByNeedsIndex)
                cfg.HasIndex(e => e.CreatedBy);

            return cfg;
        }

        public static EntityTypeBuilder<T> MapCreatedMeta<T, TCreatedBy>(
            this EntityTypeBuilder<T> cfg, int maxLength = DefaultMaxLength, bool propertyOnNeedsIndex = DefaultPropertyNeedsIndex,
            bool propertyByNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveCreatedMeta<TCreatedBy>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyOnNeedsIndex)
                cfg.HasIndex(e => e.CreatedOn);

            cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(maxLength);
            if (propertyByNeedsIndex)
                cfg.HasIndex(e => e.CreatedBy);

            return cfg;
        }

    #endregion

    #region IHaveLocalCreatedMeta

        public static EntityTypeBuilder<T> MapLocalCreatedMeta<T>(
            this EntityTypeBuilder<T> cfg, int maxLength = DefaultMaxLength, bool propertyOnNeedsIndex = DefaultPropertyNeedsIndex,
            bool propertyByNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveLocalCreatedMeta
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyOnNeedsIndex)
                cfg.HasIndex(e => e.CreatedOn);

            cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(maxLength);
            if (propertyByNeedsIndex)
                cfg.HasIndex(e => e.CreatedBy);

            return cfg;
        }

        public static EntityTypeBuilder<T> MapLocalCreatedMeta<T, TCreatedBy>(
            this EntityTypeBuilder<T> cfg, int maxLength = DefaultMaxLength, bool propertyOnNeedsIndex = DefaultPropertyNeedsIndex,
            bool propertyByNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveLocalCreatedMeta<TCreatedBy>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.CreatedOn).IsRequired();
            if (propertyOnNeedsIndex)
                cfg.HasIndex(e => e.CreatedOn);

            cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(maxLength);
            if (propertyByNeedsIndex)
                cfg.HasIndex(e => e.CreatedBy);

            return cfg;
        }

    #endregion
    }
#endif
}
