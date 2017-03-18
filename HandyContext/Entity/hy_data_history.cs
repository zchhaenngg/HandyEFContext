namespace HandyContext.Entity
{
    using HandyContext.Entity.Abstracts;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("hy_data_history")]
    public partial class hy_data_history : hy_Creator
    {
        [StringLength(50)]
        public string entity_name { get; set; }

        [Required]
        [StringLength(40)]
        public string unique_key { get; set; }

        [StringLength(50)]
        public string operation { get; set; }

        [Required]
        public string description { get; set; }
    }
}
