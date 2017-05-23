using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyModel.Entity.Interfaces;

namespace Handy.EF.Model.EAV.Interfaces
{
    public interface IAttributeValue<TAttribute, TMetaData, TValue> : IKey 
        where TAttribute : IAttribute<TMetaData>
        where TMetaData: IMetaData<TAttribute>
    {
        TAttribute Attribute { get; set; }
        string EntityId { get; set; }
        TValue Value { get; set; }
    }
}
 