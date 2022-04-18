using Core.Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events;

internal class CaseCreatedEvent : DomainEvent
{
    public CaseCreatedEvent(CourtCase courtCase)
    {
        CourtCase = courtCase;
    }

    public CourtCase CourtCase { get; set; }
}
