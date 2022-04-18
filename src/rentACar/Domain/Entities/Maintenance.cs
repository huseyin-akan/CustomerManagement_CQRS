using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;

namespace Domain.Entities
{
    public class Maintenance :AuditableEntity
    {
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public Maintenance()
        {

        }
        public Maintenance(int id, string description, DateTime maintenanceDate, DateTime returnDate, int carId) :this()
        {
            Id = id;
            Description = description;
            MaintenanceDate = maintenanceDate;
            ReturnDate = returnDate;
            CarId = carId;
        }
    }
}
