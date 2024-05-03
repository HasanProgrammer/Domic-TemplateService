using Domic.Domain.Service.Contracts.Interfaces;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class TemplateCommandRepository(Persistence.Contexts.Q.SQLContext context) : ITemplateCommandRepository;