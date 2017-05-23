using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.EAV.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.EAV.Abstracts
{
    public abstract class AttributeValueBool<TAttribute, TMetaData> : CreatorModifier, IAttributeValue<TAttribute, TMetaData, bool>
        where TAttribute : IAttribute<TMetaData>
        where TMetaData : IMetaData<TAttribute>
    {
        public TAttribute Attribute { get; set; }
        public string EntityId { get; set; }
        public bool Value { get; set; }
    }
}
