namespace HandyModel.Entity.Abstracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HandyModel.Entity.Interfaces;

    public abstract class CreatorModifier : ICreator, IModifier
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }

        [StringLength(40)]
        public string CreatedById { get; set; }

        public DateTime CreatedTime { get; set; }

        [StringLength(40)]
        public string LastModifiedById { get; set; }

        public DateTime LastModifiedTime { get; set; }
    }
}
