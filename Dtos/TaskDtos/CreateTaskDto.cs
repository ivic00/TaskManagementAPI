namespace TaskManagementAPI2.Dtos.TaskDtos
{
    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public Enums.TaskPriority Priority { get; set; }
        public int AssignedToId { get; set; }
        public int TeamId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
