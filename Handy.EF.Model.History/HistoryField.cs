using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.History.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.History
{
    /// <summary>
    /// 某个实体的字段变更历史
    /// </summary>
    public class HistoryField : Creator, INotRecordHistory
    {
        public HistoryField()
        {
            Values = new HashSet<HistoryFieldValue>();
        }
        /// <summary>
        /// 关联数据实体
        /// </summary>
        [Required]
        [StringLength(40)]
        public string UniqueKey { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<HistoryFieldValue> Values { get; set; }
        public HistoryTable Table { get; set; }
    }
}
