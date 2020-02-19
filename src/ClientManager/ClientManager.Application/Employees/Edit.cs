using ClientManager.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientManager.Application.Employees
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string PhoneNumber { get; set; }

            public string Position { get; set; }

            public decimal? Salary { get; set; }

            public decimal? HourlyRate { get; set; }

            public DateTime? StartDate { get; set; }

            public DateTime? EndDate { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataDbContext _dbContext;

            public Handler(DataDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(Command request,
            CancellationToken cancellationToken)
            {
                var employee = await _dbContext.Employees.FindAsync(request.Id);

                if (employee == null)
                    throw new Exception("Could not find employee");

                employee.FirstName = request.FirstName ?? employee.FirstName;
                employee.LastName = request.LastName ?? employee.LastName;
                employee.Email = request.Email ?? employee.Email;
                employee.PhoneNumber = request.PhoneNumber ?? employee.PhoneNumber;
                employee.Position = request.Position ?? employee.Position;
                employee.Salary = request.Salary ?? employee.Salary;
                employee.HourlyRate = request.HourlyRate ?? employee.HourlyRate;
                employee.StartDate = request.StartDate ?? employee.StartDate;
                employee.EndDate = request.EndDate ?? employee.EndDate;

                var success = await _dbContext.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
