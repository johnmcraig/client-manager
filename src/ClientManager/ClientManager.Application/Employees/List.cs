using ClientManager.Data;
using ClientManager.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientManager.Application.Employees
{
    public class List
    {
        public class Query : IRequest<List<Employee>> { }

        public class Handler : IRequestHandler<Query, List<Employee>>
        {
            private readonly DataDbContext _dbContext;

            public Handler(DataDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<Employee>> Handle(Query request,
            CancellationToken cancellationToken)
            {
                var employees = await _dbContext.Employees.ToListAsync();

                return employees;
            }
        }
    }
}
