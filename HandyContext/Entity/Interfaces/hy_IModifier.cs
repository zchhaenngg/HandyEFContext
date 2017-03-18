using System;
namespace HandyContext.Entity.Interfaces
{
    public interface hy_IModifier
    {
        string last_modified_by_id { get; set; }

        DateTime last_modified_time { get; set; }
    }
}
