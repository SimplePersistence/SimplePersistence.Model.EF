namespace SimplePersistence.Model.EF.Fluent
{
#if (NET40 || NET45)
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Configuration;

    /// <summary>
    /// Extension methods for Entity Framework code first mappings
    /// </summary>
    public static partial class CodeFirstMappingExtensions
    {
        /// <summary>
        /// Adds an index to the given <see cref="DateTimePropertyConfiguration"/>
        /// </summary>
        /// <param name="cfg">The property configuration</param>
        /// <param name="name">The name of the index if needed</param>
        /// <param name="order">The index order</param>
        /// <returns>The configuration after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static DateTimePropertyConfiguration AddIndex(this DateTimePropertyConfiguration cfg, string name = null, int? order = null)
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var ia = name == null
                ? new IndexAttribute()
                : (order == null
                    ? new IndexAttribute(name)
                    : new IndexAttribute(name, order.Value));
            return cfg.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(ia));
        }

        /// <summary>
        /// Adds an index to the given <see cref="PrimitivePropertyConfiguration"/>
        /// </summary>
        /// <param name="cfg">The property configuration</param>
        /// <param name="name">The name of the index if needed</param>
        /// <param name="order">The index order</param>
        /// <returns>The configuration after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static PrimitivePropertyConfiguration AddIndex(this PrimitivePropertyConfiguration cfg, string name = null, int? order = null)
        {
            if (cfg == null) throw new ArgumentNullException(nameof(cfg));

            var ia = name == null
                ? new IndexAttribute()
                : (order == null
                    ? new IndexAttribute(name)
                    : new IndexAttribute(name, order.Value));
            return cfg.HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(ia));
        }
    }
#endif
}
