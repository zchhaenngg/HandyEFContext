using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Context.History.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Context.History
{
    public abstract class HistoryTable : Creator, INotRecordHistory
    {
        [Index(IsUnique = true)]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
