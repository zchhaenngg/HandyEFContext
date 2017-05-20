namespace HandyModel.Entity.Abstracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HandyModel.Entity.Interfaces;
    public abstract class Creator : ICreator
    {
        [Key]
        [StringLength(40)]
        public string Id { get; set; }

        [StringLength(40)]
        public string CreatedById { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
