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
    using System.Data.Entity.ModelConfiguration;
    using System.Data.Entity.ModelConfiguration.Configuration;
    
    public static partial class CodeFirstMappingExtensions
    {
        #region IHaveCreatedMeta

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="byMaxLength">The max length for the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> property.</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index?</param>
        /// <param name="byNeedsIndex">Does <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/> needs an index?</param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapCreatedMeta<T>(
            this EntityTypeConfiguration<T> cfg, int byMaxLength = DefaultMaxLength, bool onNeedsIndex = DefaultPropertyNeedsIndex,
            bool byNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveCreatedMeta<string>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.CreatedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(byMaxLength);
            if (byNeedsIndex)
                byCfg.AddIndex();

            return cfg;
        }

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The by property type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index?</param>
        /// <param name="byMapping">An optional lambda for mapping the <see cref="IHaveCreatedMeta{TCreatedBy}.CreatedBy"/></param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapCreatedMeta<T, TBy>(
            this EntityTypeConfiguration<T> cfg, bool onNeedsIndex = DefaultPropertyNeedsIndex, 
            Action<PrimitivePropertyConfiguration> byMapping = null)
            where T : class, IHaveCreatedMeta<TBy>
            where TBy : struct 
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.CreatedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.Property(e => e.CreatedBy).IsRequired();
            byMapping?.Invoke(byCfg);

            return cfg;
        }

        #endregion

        #region IHaveLocalCreatedMeta

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveLocalCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="byMaxLength">The max length for the <see cref="IHaveLocalCreatedMeta{TCreatedBy}.CreatedBy"/> property.</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveLocalCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index?</param>
        /// <param name="byNeedsIndex">Does <see cref="IHaveLocalCreatedMeta{TCreatedBy}.CreatedBy"/> needs an index?</param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapLocalCreatedMeta<T>(
            this EntityTypeConfiguration<T> cfg, int byMaxLength = DefaultMaxLength, bool onNeedsIndex = DefaultPropertyNeedsIndex,
            bool byNeedsIndex = DefaultPropertyNeedsIndex)
            where T : class, IHaveLocalCreatedMeta<string>
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.CreatedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.Property(e => e.CreatedBy).IsRequired().HasMaxLength(byMaxLength);
            if (byNeedsIndex)
                byCfg.AddIndex();

            return cfg;
        }

        /// <summary>
        /// Maps the created metadata for an entity implementing the <see cref="IHaveLocalCreatedMeta{TCreatedBy}"/>
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The by property type</typeparam>
        /// <param name="cfg">The entity configuration</param>
        /// <param name="onNeedsIndex">Does <see cref="IHaveLocalCreatedMeta{TCreatedBy}.CreatedOn"/> needs an index?</param>
        /// <param name="byMapping">An optional lambda for mapping the <see cref="IHaveLocalCreatedMeta{TCreatedBy}.CreatedBy"/></param>
        /// <returns>The entity configuration after changes</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static EntityTypeConfiguration<T> MapLocalCreatedMeta<T, TBy>(
            this EntityTypeConfiguration<T> cfg, bool onNeedsIndex = DefaultPropertyNeedsIndex,
            Action<PrimitivePropertyConfiguration> byMapping = null)
            where T : class, IHaveLocalCreatedMeta<TBy>
            where TBy : struct 
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var onCfg = cfg.Property(e => e.CreatedOn).IsRequired();
            if (onNeedsIndex)
                onCfg.AddIndex();

            var byCfg = cfg.Property(e => e.CreatedBy).IsRequired();
            byMapping?.Invoke(byCfg);

            return cfg;
        }

        #endregion
    }
}
