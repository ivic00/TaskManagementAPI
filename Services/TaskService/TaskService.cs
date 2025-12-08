using MapsterMapper;
using TaskManagementAPI2.Data;
using TaskManagementAPI2.Dtos.TaskDtos;

namespace TaskManagementAPI2.Services.TaskService
{
    public class TaskService : ITaskService
    {
        public readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public TaskService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetTaskDto> CreateTask(CreateTaskDto newTask)
        {
            await _context.AddAsync(newTask.);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetTaskDto>(newTask);
        }

        public Task<GetTaskDto> GetTaskById(int id)
        {

        }
    }
}
