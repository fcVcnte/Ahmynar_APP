using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmynar_Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "fdc8200b-03de-4894-b59f-93ff7d3d1420",
                    UserId = "bf69fb3e-0c5c-4dd4-95ae-d567336b20b1"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "5138340c-3f7f-492a-b3a1-9f3bd56d6d8d",
                    UserId = "53f5ba45-12e6-4c12-981f-f27fd172fd70"
                }
            );
        }
    }
}
