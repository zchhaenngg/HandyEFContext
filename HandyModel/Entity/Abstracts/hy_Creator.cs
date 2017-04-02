namespace HandyModel.Entity.Abstracts
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HandyModel.Entity.Interfaces;
    public abstract class hy_Creator : hy_ICreator
    {
        [Key]
        [StringLength(40)]
        public string id { get; set; }

        [StringLength(40)]
        public string created_by_id { get; set; }

        public DateTime created_time { get; set; }
    }
}
