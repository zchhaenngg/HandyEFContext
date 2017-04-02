namespace HandyContextTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class hy_user
    {
        public hy_user()
        {
            hy_auth_roles = new HashSet<hy_auth_role>();
        }

        [Key]
        [StringLength(40)]
        public string id { get; set; }

        public int access_failed_times { get; set; }

        public bool is_locked { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public ICollection<hy_auth_role> hy_auth_roles { get; set; }
    }
}
