using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyModel.Entity.Interfaces;

namespace Handy.EF.Model.EAV.Interfaces
{
    public interface IAttributeValue<TEntity, TValue> : IKey where TEntity : class
    {
        IAttribute Attribute { get; set; }
        TEntity Entity { get; set; }
        TValue Value { get; set; }
    }
}
