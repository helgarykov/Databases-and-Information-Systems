using Data.ViewModels;

namespace Data.IServices;

public interface ITaskService
{
    
    public int AddTaskViaDapper(TaskRequest newTask);

    public Task UpdateTaskAsync(int taskId, Data.Models.Task taskToUpdate);

    public void DeleteTaskById(int taskId);
    //public int AddTaskViaDapperP();
    
}