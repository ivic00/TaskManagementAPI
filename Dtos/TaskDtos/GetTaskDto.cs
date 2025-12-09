namespace TaskManagementAPI2.Dtos.TaskDtos
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public Enums.TaskPriority Priority { get; set; }
        public GetUserDto AssignedTo { get; set; }
        public GetUserDto CreatedBy { get; set; }
        public string TeamName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DueDate { get; set; }
    }
}
