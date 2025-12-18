namespace EMiniEmployeeTasks.Service.Contracts;

public interface IAuthService
{
    Task<string> LoginAsync(string username, string password);
}
