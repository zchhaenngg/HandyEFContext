using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.EAV.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.EAV.Abstracts
{
    public abstract class AttributeValueVarchar<TEntity> : CreatorModifier, IAttributeValue<TEntity, string> where TEntity : class
    {
        public IAttribute Attribute { get; set; }

        public TEntity Entity { get; set; }
        /// <summary>
        /// nvarchar(max)挺好
        /// </summary>
        public string Value { get; set; }
    }
}
