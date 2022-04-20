using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Expense : AuditableEntity
    {
        public string ExpenseTitle { get; set; } = "";
        public double Amount { get; set; }
        public int CourtCaseId { get; set; }

        public CourtCase CourtCase { get; set; }

        public Expense()
        {
            CourtCase = new CourtCase();
        }
    }
}
