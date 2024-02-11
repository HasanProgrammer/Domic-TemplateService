using Domic.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.C;

public class TemplateConfig : IEntityTypeConfiguration<Template>
{
    public void Configure(EntityTypeBuilder<Template> builder)
    {
        //PrimaryKey
        
        builder.HasKey(Permission => Permission.Id);

        builder.ToTable("Permissions");
        
        /*-----------------------------------------------------------*/

        //Property

        /*-----------------------------------------------------------*/
        
        //Relations
    }
}