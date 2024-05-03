using Domic.Core.Persistence.Configs;
using Domic.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.C;

public class TemplateConfig : BaseEntityConfig<Template, string>
{
    public override void Configure(EntityTypeBuilder<Template> builder)
    {
        //Configs

        builder.ToTable("Templates");
        
        base.Configure(builder);
    }
}