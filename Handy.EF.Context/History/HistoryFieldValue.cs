using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Context.History.Interfaces;
using Handy.EF.Model.Entity;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Context.History
{
    public class HistoryFieldValue : Creator, INotRecordHistory
    {
        public string Value { get; set; }
        
        public LogEvent LogEvent { get; set; }

        [Required]
        public HistoryField Field { get; set; }
    }
}
