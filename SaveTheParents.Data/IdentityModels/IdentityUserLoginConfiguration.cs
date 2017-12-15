using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SaveTheParents.Data.IdentityModels
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>, IConvention
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
}   