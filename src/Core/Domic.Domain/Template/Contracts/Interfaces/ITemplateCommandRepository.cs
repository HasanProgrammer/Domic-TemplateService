using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Service.Contracts.Interfaces;

public interface ITemplateCommandRepository : ICommandRepository<Entities.Template, string>
{
    
}