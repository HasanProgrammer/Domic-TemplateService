using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class TemplateCommandRepository : ITemplateCommandRepository
{
    private readonly SQLContext _sqlContext;

    public TemplateCommandRepository(SQLContext sqlContext)
    {
        _sqlContext = sqlContext;
    }
}