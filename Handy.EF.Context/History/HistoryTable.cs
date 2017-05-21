using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Context.History
{
    public abstract class HistoryTable : Creator
    {//表名、字段名、Json数据
        [StringLength(128)]
        public string TableName { get; set; }
    }
}
