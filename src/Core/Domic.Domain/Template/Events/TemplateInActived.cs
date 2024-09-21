using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Service.Events;

[EventConfig(ExchangeType = Exchange.FanOut, Exchange = "", Queue = "")]
public class TemplateInActived : UpdateDomainEvent<string>
{
    public bool IsActive { get; init; }
}