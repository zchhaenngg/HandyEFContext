using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyModel.Entity.Abstracts;

namespace HandyContextTest
{
    public class hy_auth_role: CreatorModifier
    {
        public hy_auth_role()
        {
            hy_users = new HashSet<hy_user>();
        }
        

        [StringLength(50)]
        public string name { get; set; }

        public virtual ICollection<hy_user> hy_users { get; set; }
    }
}
