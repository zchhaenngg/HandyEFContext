using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandyContextTest
{
    public class hy_auth_role
    {
        public hy_auth_role()
        {
            hy_users = new HashSet<hy_user>();
        }

        [Key]
        public string id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public hy_user Creator { get; set; }

        public virtual ICollection<hy_user> hy_users { get; set; }
    }
}
