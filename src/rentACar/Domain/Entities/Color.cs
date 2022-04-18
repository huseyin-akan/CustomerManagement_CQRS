using Core.Persistence.Repositories;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Color : AuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Car> Cars{ get; set; }

        public Color()
        {
            Cars = new HashSet<Car>();
        }
        public Color(int id, string name ) :this()
        {
            Name = name;
            Id = id;
        }
    }
}
