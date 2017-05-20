namespace HandyModel.Entity.Interfaces
{
    using System;
    public interface ICreator : IKey
    {
        string CreatedById { get; set; }

        DateTime CreatedTime { get; set; }
    }
}
