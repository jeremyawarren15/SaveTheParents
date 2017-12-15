using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SaveTheParents.Data.IdentityModels
{
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>, IConvention
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.RoleId);
        }
    }
}