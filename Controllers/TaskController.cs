using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementAPI2.Dtos.TaskDtos;
using TaskManagementAPI2.Services.TaskService;

namespace TaskManagementAPI2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPut]
        public async Task<ActionResult<GetTaskDto>> CreateTask([FromBody] CreateTaskDto newTask)
        {
            var creatorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _taskService.CreateTask(newTask, int.Parse(creatorId));

            if (res == null) return BadRequest(new { message = "task doesnt exist" });

            return Ok(res);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<GetTaskDto>> GetTaskById(int id)
        {
            var res = await _taskService.GetTaskById(id);

            if (res is null) return BadRequest(new { message = $"task with id={id} does not exist" });

            return Ok(res);
        }

        [HttpGet("mytasks")]
        public async Task<ActionResult<ICollection<GetTaskDto>>> GetMyTasks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var res = await _taskService.GetMyTasks(int.Parse(userId));

            if (res is null || res.Count == 0) return BadRequest(new { message = "tasks not found" });

            return Ok(res);
        }
    }
}
