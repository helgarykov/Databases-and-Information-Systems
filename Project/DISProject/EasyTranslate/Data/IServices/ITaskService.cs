namespace Data.IServices;

public interface ITaskService
{
    public IEnumerable<Task> AddTaskViaDapper();
}