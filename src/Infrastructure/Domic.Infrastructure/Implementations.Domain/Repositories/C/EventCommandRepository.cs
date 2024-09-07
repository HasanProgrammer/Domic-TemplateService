using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Entities;
using Domic.Core.Domain.Enumerations;
using Domic.Persistence.Contexts.C;
using Microsoft.EntityFrameworkCore;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

//Config
public partial class EventCommandRepository(SQLContext context) : IEventCommandRepository;

//Transaction
public partial class EventCommandRepository
{
    public async Task AddAsync(Event entity, CancellationToken cancellationToken) 
        => await context.Events.AddAsync(entity, cancellationToken);

    public void Change(Event entity) => context.Events.Update(entity);

    public void Remove(Event entity) => context.Events.Remove(entity);
}

//Query
public partial class EventCommandRepository
{
    public IEnumerable<Event> FindAll() => context.Events.ToList();

    public IEnumerable<Event> FindAllWithOrdering(Order order, bool accending = true)
    {
        var entity = context.Events;

        return order switch {
            Order.Date => entity.OrderBy(@event => @event.CreatedAt_EnglishDate).ToList(),
            Order.Id   => entity.OrderBy(@event => @event.Id).ToList(),
            _ => null
        };
    }

    public async Task<IEnumerable<Event>> FindAllAsync(CancellationToken cancellationToken) 
        => await context.Events.ToListAsync(cancellationToken);

    public async Task<IEnumerable<Event>> FindAllWithOrderingAsync(Order order, bool accending = true,
        CancellationToken cancellationToken = new CancellationToken()
    )
    {
        var entity = context.Events;

        return order switch {
            Order.Date => await entity.OrderBy(@event => @event.CreatedAt_EnglishDate).ToListAsync(cancellationToken),
            Order.Id   => await entity.OrderBy(@event => @event.Id).ToListAsync(cancellationToken),
            _ => null
        };
    }
}