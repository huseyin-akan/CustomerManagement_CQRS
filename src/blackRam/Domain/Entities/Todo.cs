using Core.Domain.Common;
using Core.Persistence;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Todo : AuditableEntity, IHasDomainEvent
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? ExpirationDate { get; set; }
        public int CourtCaseId { get; set; }
        
        private bool _done;
        public bool Done
        {
            get => _done;
            set
            {
                if (value == true && _done == false)
                {
                    DomainEvents.Add(new TodoItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        public virtual CourtCase CourtCase { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public Todo()
        {
            CourtCase = new CourtCase();
        }

        public Todo(int id, string title, string description, DateTime expirationDate) :this()
        {
            Id = id;
            Title = title;
            Description = description;
            ExpirationDate = expirationDate;
        }
    }
}
