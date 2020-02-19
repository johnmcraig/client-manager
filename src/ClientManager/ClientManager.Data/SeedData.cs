using ClientManager.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientManager.Data
{
    public class SeedData
    {
        public static void Seed(DataDbContext dbContext)
        {
            if (!dbContext.Employees.Any())
            {
                var employeeData = System.IO.File.ReadAllText("../ClientManager.Data/EmployeeSeed.json");
                var employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData);

                foreach (var employee in employees)
                {
                    dbContext.Employees.Add(employee);
                }

            }

            dbContext.SaveChanges();
        }
    }
}
