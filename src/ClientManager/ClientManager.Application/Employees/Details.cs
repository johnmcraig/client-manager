using ClientManager.Data;
using ClientManager.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ClientManager.Application.Employees
{
	public class Details
	{
        public class Query : IRequest<Employee>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Employee>
        {
            private readonly DataDbContext _dbContext;

            public Handler(DataDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Employee> Handle(Query request,
                CancellationToken cancellationToken)
            {
                var singleEmployee = await _dbContext.Employees.FindAsync(request.Id);

                return singleEmployee;
            }
        }
    }
}
