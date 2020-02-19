using ClientManager.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientManager.Application.Employees
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataDbContext _dbContext;

            public Handler(DataDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.Id);

                if (employee == null) 
                    throw new Exception("Could not find employee");

                _dbContext.Remove(employee);

                var success = await _dbContext.SaveChangesAsync() > 0;

                if (success) 
                    return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
