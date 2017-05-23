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
    public abstract class AttributeValueVarchar<TAttribute, TMetaData> : CreatorModifier, IAttributeValue<TAttribute, TMetaData, string>
        where TAttribute : IAttribute<TMetaData>
        where TMetaData : IMetaData<TAttribute>
    {
        public TAttribute Attribute { get; set; }
        public string EntityId { get; set; }
        /// <summary>
        /// nvarchar(max)挺好
        /// </summary>
        public string Value { get; set; }
    }
}
