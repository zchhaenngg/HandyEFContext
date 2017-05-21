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
        IMetaData MetaData { get; set; }
        string Name { get; set; }
        DataType DataType { get; set; }
    }
}
