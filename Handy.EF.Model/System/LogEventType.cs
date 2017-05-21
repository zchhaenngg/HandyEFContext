using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyModel.Entity.Abstracts;

namespace Handy.EF.Model.System
{
    /// <summary>
    /// it contains system-built events and custom events
    /// </summary>
    public class LogEventType : CreatorModifier
    {
        public string Name { get; set; }
    }
}
