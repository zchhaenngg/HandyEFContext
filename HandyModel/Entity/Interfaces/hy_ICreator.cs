namespace HandyModel.Entity.Interfaces
{
    using System;
    public interface hy_ICreator
    {
        string created_by_id { get; set; }

        DateTime created_time { get; set; }
    }
}
