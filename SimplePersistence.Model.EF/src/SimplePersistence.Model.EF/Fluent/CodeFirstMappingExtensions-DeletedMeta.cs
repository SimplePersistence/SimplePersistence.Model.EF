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
    
    public static partial class CodeFirstMappingExtensions
    {
        #region IHaveDeletedMeta

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="byMaxLength">The max length for the <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedBy"/> property.</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byNeedsIndex">Does <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedBy"/> needs an index?</param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapDeletedMeta<T>(
            this EntityTypeConfiguration<T> cfg, int byMaxLength = DefaultMaxLength, bool onNeedsIndex = DefaultPropertyNeedsIndex,
            bool byNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveDeletedMeta<string>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.Property(e => e.DeletedBy).IsRequired().HasMaxLength(byMaxLength);
            if (byNeedsIndex)
                byCfg.AddIndex();

            return cfg;
        }

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The by property type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byMapping">An optional lambda for mapping the <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedBy"/></param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapDeletedMeta<T, TBy>(
            this EntityTypeConfiguration<T> cfg, bool onNeedsIndex = DefaultPropertyNeedsIndex, 
            Action<RequiredNavigationPropertyConfiguration<T, TBy>> byMapping = null)
            where T : class, IHaveDeletedMeta<TBy>
            where TBy : class
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.HasRequired(e => e.DeletedBy);
            byMapping?.Invoke(byCfg);

            return cfg;
        }

        #endregion

        #region IHaveLocalDeletedMeta

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveLocalDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="byMaxLength">The max length for the <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedBy"/> property.</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byNeedsIndex">Does <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedBy"/> needs an index?</param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapLocalDeletedMeta<T>(
            this EntityTypeConfiguration<T> cfg, int byMaxLength = DefaultMaxLength, bool onNeedsIndex = DefaultPropertyNeedsIndex,
            bool byNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveLocalDeletedMeta<string>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.Property(e => e.DeletedBy).IsRequired().HasMaxLength(byMaxLength);
            if (byNeedsIndex)
                byCfg.AddIndex();

            return cfg;
        }

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveLocalDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The by property type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byMapping">An optional lambda for mapping the <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedBy"/></param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapLocalDeletedMeta<T, TBy>(
            this EntityTypeConfiguration<T> cfg, bool onNeedsIndex = DefaultPropertyNeedsIndex, 
            Action<RequiredNavigationPropertyConfiguration<T, TBy>> byMapping = null)
            where T : class, IHaveLocalDeletedMeta<TBy>
            where TBy : class
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.HasRequired(e => e.DeletedBy);
            byMapping?.Invoke(byCfg);

            return cfg;
        }

        #endregion
    }

#else
    using Microsoft.Data.Entity.Metadata.Builders;
    
    public static partial class CodeFirstMappingExtensions
    {
        #region IHaveDeletedMeta

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="byMaxLength">The max length for the <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedBy"/> property.</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byNeedsIndex">Does <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedBy"/> needs an index?</param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeBuilder<T> MapDeletedMeta<T>(
            this EntityTypeBuilder<T> cfg, int byMaxLength = DefaultMaxLength, bool onNeedsIndex = DefaultPropertyNeedsIndex, 
            bool byNeedsIndex = DefaultPropertyNeedsIndex) 
            where T : class, IHaveDeletedMeta<string>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                cfg.HasIndex(e => e.DeletedOn);

            cfg.Property(e => e.DeletedBy).IsRequired().HasMaxLength(byMaxLength);
            if (byNeedsIndex)
                cfg.HasIndex(e => e.DeletedBy);

            return cfg;
        }

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The by property type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byMapping">An optional lambda for mapping the <see cref="IHaveDeletedMeta{TDeletedBy}.DeletedBy"/></param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeBuilder<T> MapDeletedMeta<T, TBy>(
            this EntityTypeBuilder<T> cfg, bool onNeedsIndex = DefaultPropertyNeedsIndex, Action < PropertyBuilder<TBy>> byMapping = null)
            where T : class, IHaveDeletedMeta<TBy>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                cfg.HasIndex(e => e.DeletedOn);

            var byCfg = cfg.Property(e => e.DeletedBy).IsRequired();
            byMapping?.Invoke(byCfg);

            return cfg;
        }

        #endregion

        #region IHaveLocalDeletedMeta

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveLocalDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="byMaxLength">The max length for the <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedBy"/> property.</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byNeedsIndex">Does <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedBy"/> needs an index?</param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeBuilder<T> MapLocalDeletedMeta<T>(
            this EntityTypeBuilder<T> cfg, int byMaxLength = DefaultMaxLength, bool onNeedsIndex = DefaultPropertyNeedsIndex,
            bool byNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveLocalDeletedMeta<string>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                cfg.HasIndex(e => e.DeletedOn);

            cfg.Property(e => e.DeletedBy).IsRequired().HasMaxLength(byMaxLength);
            if (byNeedsIndex)
                cfg.HasIndex(e => e.DeletedBy);

            return cfg;
        }

        /// <summary>
        /// Maps the deleted metadata for an entity implementing the <see cref="IHaveLocalDeletedMeta{TDeletedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The by property type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedOn"/> needs an index?</param>
        /// <param name="byMapping">An optional lambda for mapping the <see cref="IHaveLocalDeletedMeta{TDeletedBy}.DeletedBy"/></param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeBuilder<T> MapLocalDeletedMeta<T, TBy>(
            this EntityTypeBuilder<T> cfg, bool onNeedsIndex = DefaultPropertyNeedsIndex, Action<PropertyBuilder<TBy>> byMapping = null)
            where T : class, IHaveLocalDeletedMeta<TBy>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            cfg.Property(e => e.DeletedOn).IsRequired();
            if (onNeedsIndex)
                cfg.HasIndex(e => e.DeletedOn);

            var byCfg = cfg.Property(e => e.DeletedBy).IsRequired();
            byMapping?.Invoke(byCfg);

            return cfg;
        }

        #endregion
    }
#endif
}
