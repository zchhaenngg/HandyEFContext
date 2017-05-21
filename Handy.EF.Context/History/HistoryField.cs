using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Context.History
{
    /// <summary>
    /// 可以查看一个实体每个字段的历史变更记录
    /// </summary>
    public class HistoryField : CreatorModifier
    {
        public HistoryField()
        {
            FieldValues = new HashSet<HistoryFieldValue>();
        }
        /// <summary>
        /// 关联数据实体
        /// </summary>
        [Required]
        [StringLength(40)]
        public string UniqueKey { get; set; }
        
        public ICollection<HistoryFieldValue> FieldValues { get; set; }
        public HistoryTable Table { get; set; }
    }
}
