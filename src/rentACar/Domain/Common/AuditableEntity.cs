using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common;

public class AuditableEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public AuditableEntity()
    {
    }

    public AuditableEntity(int id, DateTime created = default, string? createdBy = null, DateTime? lastModified = null, string? lastModifiedBy = null) : this()
    {
        Id = id;
        Created = created;
        CreatedBy = createdBy;
        LastModified = lastModified;
        LastModifiedBy = lastModifiedBy;
    }

}
