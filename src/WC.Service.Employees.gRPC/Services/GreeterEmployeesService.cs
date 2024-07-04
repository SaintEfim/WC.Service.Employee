using Grpc.Core;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;
using WC.Service.Employees.gRPC.Server.Services;

namespace WC.Service.Employees.gRPC.Services;

public class GreeterEmployeesService : GreeterEmployees.GreeterEmployeesBase
{
    private readonly IEmployeeManager _manager;

    public GreeterEmployeesService(IEmployeeManager manager)
    {
        _manager = manager;
    }

    public override async Task<EmployeeCreateResponse> Create(EmployeeCreateRequest entity, ServerCallContext context)
    {
        var createItem = await _manager.Create(new EmployeeModel
        {
            Name = entity.Employee.Name,
            Surname = entity.Employee.Surname,
            Patronymic = entity.Employee.Patronymic,
            Email = entity.Employee.Email,
            Password = entity.Employee.Password,
            PositionId = Guid.Parse(entity.Employee.PositionId)
        });

        return new EmployeeCreateResponse
        {
            Id = createItem.Id.ToString()
        };
    }
}