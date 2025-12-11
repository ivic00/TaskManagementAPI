using TaskManagementAPI2.Dtos.TaskDtos;

namespace TaskManagementAPI2.Services.TaskService
{
    public interface ITaskService
    {
        public Task<GetTaskDto> GetTaskById(int id);
        public Task<bool> CreateTask(CreateTaskDto newTask, int creatorId);
        public Task<ICollection<GetTaskDto>> GetMyTasks(int userId);
    }
}
