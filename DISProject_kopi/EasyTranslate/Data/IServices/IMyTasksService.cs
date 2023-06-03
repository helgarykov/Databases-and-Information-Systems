namespace Data.IServices;

public interface IMyTasksService
{
    public IEnumerable<Task> GetClientTasksViaDapper(int clientId);
}