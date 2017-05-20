namespace HandyModel.Entity.Interfaces
{
    using System;

    public interface IModifier : IKey
    {
        string LastModifiedById { get; set; }

        DateTime LastModifiedTime { get; set; }
    }
}
