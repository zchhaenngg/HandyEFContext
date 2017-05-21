using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyModel.Entity.Interfaces;

namespace Handy.EF.Model.EAV.Interfaces
{
    /// <summary>
    /// When Update，通过Meta判定是否允许为空，允许不在列表中的值存入数据库等等设计
    /// </summary>
    public interface IMetaData : IKey
    {
        IAttribute Attribute { get; set; }
        bool IsRequired { get; set; }
    }
}
