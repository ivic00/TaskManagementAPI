using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<GetTaskDto>> CreateTask([FromBody] GetTaskDto newTask)
        {

        }
    }
}
