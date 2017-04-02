namespace HandyModel.Entity.Interfaces
{
    using System;

    public interface hy_IModifier
    {
        string last_modified_by_id { get; set; }

        DateTime last_modified_time { get; set; }
    }
}
