using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Service.Events;

[MessageBroker(ExchangeType = Exchange.FanOut, Exchange = "", Queue = "")]
public class TemplateActived : UpdateDomainEvent<string>
{
    public bool IsActive { get; init; }
}