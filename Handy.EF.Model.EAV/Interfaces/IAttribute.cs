using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.EAV.Enums;
using HandyModel.Entity.Interfaces;

namespace Handy.EF.Model.EAV.Interfaces
{
    public interface IAttribute : IKey
    {
        string Name { get; set; }
        DataType DataType { get; set; }
    }

    public interface IAttribute<TMetaData> : IAttribute where TMetaData : IMetaData
    {
        TMetaData MetaData { get; set; }
    }
}
