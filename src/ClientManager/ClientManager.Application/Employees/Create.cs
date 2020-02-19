using ClientManager.Data;
using ClientManager.Domain;
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
    public class Create
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
                var newEmployee = new Employee
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Position = request.Position,
                    Salary = request.Salary,
                    HourlyRate = request.HourlyRate,
                    StartDate = request.StartDate,
                    EndDate =   request.EndDate

                };

                _dbContext.Employees.Add(newEmployee);
                var success = await _dbContext.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
