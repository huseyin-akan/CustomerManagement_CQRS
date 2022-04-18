using Core.Domain;
using Core.Persistence.Repositories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class CourtCase : AuditableEntity, IHasDomainEvent
    {
        public string Name { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public CaseStatus CaseStatus { get; set; } = CaseStatus.Open;
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
