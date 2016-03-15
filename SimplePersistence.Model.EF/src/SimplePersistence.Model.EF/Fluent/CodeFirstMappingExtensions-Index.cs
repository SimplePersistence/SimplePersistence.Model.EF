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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration.Configuration;
    
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
}
