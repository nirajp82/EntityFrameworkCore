using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// Employee entity class representing your database table
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    // Other properties
}

// DbContext representing your database
public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your database connection here
        optionsBuilder.UseSqlServer("YourConnectionString");
    }
}

// Repository class containing the method to execute dynamic SQL query
public class EmployeeRepository
{
    private readonly MyDbContext _dbContext;

    public EmployeeRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Employee> GetEmployeesUsingDynamicFunction(string functionName, int parameterValue)
    {
        // Construct the SQL query dynamically and select specific columns
        string sqlQuery = $"SELECT e.Id, e.Name FROM Employees AS e CROSS APPLY {functionName}(e.Id) AS f WHERE e.Id = {parameterValue}";

        // Execute the raw SQL query and return the results
        var result = _dbContext.Employees.FromSqlRaw(sqlQuery).ToList();

        return result;
    }
}
