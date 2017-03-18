namespace HandyContext.Entity.Abstracts
{
    using HandyContext.Entity.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;
    public abstract class hy_Modifier : hy_IModifier
    {
        [Key]
        [StringLength(40)]
        public string id { get; set; }

        [StringLength(40)]
        public string last_modified_by_id { get; set; }

        public DateTime last_modified_time { get; set; }
    }
}
