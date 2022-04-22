using Core.Persistence;
using Domain.Common;
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
        //Fields
        public string Name { get; set; } = "";
        public CaseStatus CaseStatus { get; set; } = CaseStatus.Open;
        public string CaseNumber { get; set; } = "";

        //Foreign Keys
        public int CourtId { get; set; }        

        //Virtual Connections
        public virtual Court Court { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }       
        public virtual List<Todo> Todos{ get; set; }

        public virtual List<DomainEvent> DomainEvents { get; set; }

        public CourtCase()
        {
            this.Expenses = new List<Expense>();
            this.DomainEvents = new List<DomainEvent>();
            this.Todos = new List<Todo>();
            this.Court = new Court();
        }
    }
}
