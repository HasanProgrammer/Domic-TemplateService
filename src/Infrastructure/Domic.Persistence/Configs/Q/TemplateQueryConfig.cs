using Domic.Core.Persistence.Configs;
using Domic.Domain.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.Q;

public class TemplateQueryConfig : BaseEntityQueryConfig<TemplateQuery, string>
{
    public override void Configure(EntityTypeBuilder<TemplateQuery> builder)
    {
        //Configs

        builder.ToTable("Templates");
        
        base.Configure(builder);
    }
}