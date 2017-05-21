using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Context.History.Interfaces;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Context.History
{
    /// <summary>
    /// 可以查看一个实体每个字段的历史变更记录
    /// </summary>
    public class HistoryField : CreatorModifier, INotRecordHistory
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
        public bool IsDeleted { get; set; }
        public ICollection<HistoryFieldValue> Values { get; set; }
        public HistoryTable Table { get; set; }
    }
}
