using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Todos.Dtos
{
    public class UpdateTodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int CourtCaseId { get; set; }
        public bool Done { get; set; }
    }
}
