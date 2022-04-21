using Core.Persistence;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Todo : AuditableEntity
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime? ExpirationDate { get; set; }
        public int CourtCaseId { get; set; }

        public virtual CourtCase CourtCase { get; set; }

        public Todo()
        {
            CourtCase = new CourtCase();
        }

        public Todo(int id, string title, string description, DateTime expirationDate) :this()
        {
            Id = id;
            Title = Title;
            Description = Description;
            ExpirationDate = expirationDate;
        }

    }
}
