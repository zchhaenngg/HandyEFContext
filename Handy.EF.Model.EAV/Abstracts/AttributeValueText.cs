using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.EAV.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.EAV.Abstracts
{
    public abstract class AttributeValueText<TAttribute, TMetaData> : CreatorModifier, IAttributeValue<TAttribute, TMetaData, string>
        where TAttribute : IAttribute<TMetaData>
        where TMetaData : IMetaData<TAttribute>
    {
        public TAttribute Attribute { get; set; }
        public string EntityId { get; set; }

        [Column(TypeName= "text")]
        public string Value { get; set; }
    }
}
