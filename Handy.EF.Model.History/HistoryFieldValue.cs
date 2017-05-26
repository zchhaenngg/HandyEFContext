using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.Entity;
using Handy.EF.Model.History.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.History
{
    public class HistoryFieldValue : Creator, INotRecordHistory
    {
        public string Value { get; set; }

        public LogEvent LogEvent { get; set; }

        [Required]
        public HistoryField Field { get; set; }
    }
}
