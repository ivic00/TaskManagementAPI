using MapsterMapper;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> CreateTask(CreateTaskDto newTask, int creatorId)
        {
            Models.Task task = _mapper.Map<Models.Task>(newTask);

            task.CreatedById = creatorId;
            task.CreatedAt = DateTime.Now;
            task.UpdatedAt = DateTime.Now;

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GetTaskDto> GetTaskById(int id)
        {
            var task = await _context.Tasks
                .Include("CreatedBy")
                .Include("AssignedTo")
                .Include("Team")
                .FirstOrDefaultAsync(t => t.Id == id);
            if (task == null) return null;

            return _mapper.Map<GetTaskDto>(task);
        }

        public async Task<ICollection<GetTaskDto>> GetMyTasks(int userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.AssignedToId == userId)
                .Include("CreatedBy")
                .Include("AssignedTo")
                .Include("Team")
                .ToListAsync();

            return _mapper.Map<ICollection<GetTaskDto>>(tasks);
        }
    }
}
