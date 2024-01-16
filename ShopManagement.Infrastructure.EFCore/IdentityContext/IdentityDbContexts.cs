using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.IdentityContext
{
    public class IdentityDbContexts: IdentityDbContext
    {
        public IdentityDbContexts(DbContextOptions<IdentityDbContexts> options)
          : base(options)
        {

        }
    }
}
