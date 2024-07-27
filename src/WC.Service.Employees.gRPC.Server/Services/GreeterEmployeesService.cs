using Grpc.Core;
using WC.Service.Employees.Domain.Models;
using WC.Service.Employees.Domain.Services.Employee;

namespace WC.Service.Employees.gRPC.Server.Services;

public class GreeterEmployeesService : GreeterEmployees.GreeterEmployeesBase
{
    private readonly IEmployeeManager _manager;

    public GreeterEmployeesService(
        IEmployeeManager manager)
    {
        _manager = manager;
    }

    public override async Task<EmployeeCreateResponse> Create(
        EmployeeCreateRequest request,
        ServerCallContext context)
    {
        var createItem = await _manager.Create(new EmployeeModel
        {
            Name = request.Name,
            Surname = request.Surname,
            Patronymic = request.Patronymic,
            Email = request.Email,
            Password = request.Password,
            Position = new PositionModel { Name = request.Name }
        }, context.CancellationToken);

        return new EmployeeCreateResponse { Id = createItem.Id.ToString() };
    }
}
