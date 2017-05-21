using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.EAV.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.EAV.Abstracts
{
    public abstract class AttributeValueDateTime<TEntity> : CreatorModifier, IAttributeValue<TEntity, DateTime> where TEntity : class
    {
        public IAttribute Attribute { get; set; }
        public TEntity Entity { get; set; }
        public DateTime Value { get; set; }
    }
}
