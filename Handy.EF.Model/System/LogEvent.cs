using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handy.EF.Model.System;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.Entity
{
    /// <summary>
    /// 记录系统发生的每一次事件
    /// </summary>
    public class LogEvent : Creator
    {
        public LogEventType EventType { get; set; }       
    }
}
