using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CourtCases.Dtos
{
    public class CreateCourtCaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CaseStatus CaseStatus { get; set; }
    }
}
