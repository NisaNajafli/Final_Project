using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User : IdentityUser<int>,IBaseEntity
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Role> Roles { get; set; }

    }
}
 