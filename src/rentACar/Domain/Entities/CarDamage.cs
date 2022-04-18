using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Domain.Entities
{
    public class CarDamage :AuditableEntity
    {
        public int CarId { get; set; }
        public string Description { get; set; }

        public virtual Car Car { get; set; }

        public CarDamage()
        {
            Car = new Car();
        }

        public CarDamage(int id, int carId, string description)
        {
            Id = id;
            CarId = carId;
            Description = description;
        }
    }
}
