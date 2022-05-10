using NeedACourse.Services.CustomerService.Models;

namespace NeedACourse.Services.CustomerService;

public interface ICustomerService
{
    Task<IEnumerable<CustomerModel>> GetCustomers();
    Task<CustomerModel> GetCustomerById(int id);
}
