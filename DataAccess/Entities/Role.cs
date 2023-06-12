using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Role:IdentityRole<int>
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        public ICollection<User> Users { get; set; }
    }
}
