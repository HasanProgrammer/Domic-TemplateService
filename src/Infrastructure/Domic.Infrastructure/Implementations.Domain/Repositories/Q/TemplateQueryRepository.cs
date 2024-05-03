using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Persistence.Contexts.Q;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.Q;

public class TemplateQueryRepository(SQLContext context) : ITemplateQueryRepository;