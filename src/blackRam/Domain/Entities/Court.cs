using Core.Persistence;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Court : AuditableEntity
    {
        public string CourtNumber { get; set; } = "";
        public CourtType CourtType { get; set; }

        public List<CourtCase> CourtCases { get; set; }

        public Court()
        {
            CourtCases = new List<CourtCase>();            
        }

    }
}
