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
    public abstract class AttributeValueText<TEntity> : CreatorModifier, IAttributeValue<TEntity, string> where TEntity : class
    {
        public IAttribute Attribute { get; set; }
        public TEntity Entity { get; set; }

        [Column(TypeName= "text")]
        public string Value { get; set; }
    }
}
