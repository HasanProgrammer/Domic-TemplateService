using Domic.Domain.Service.Entities;
using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Service.Contracts.Interfaces;

public interface ITemplateQueryRepository : IQueryRepository<TemplateQuery, string>
{
    
}