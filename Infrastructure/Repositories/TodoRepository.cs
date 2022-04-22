using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TodoRepository : EfRepositoryBase<Todo, BaseDbContext>, ITodoRepository
    {
        public TodoRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
