namespace HandyModel.Entity.Abstracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HandyModel.Entity.Interfaces;
    public abstract class Modifier : IModifier
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }

        [StringLength(40)]
        public string LastModifiedById { get; set; }

        public DateTime LastModifiedTime { get; set; }
    }
}
