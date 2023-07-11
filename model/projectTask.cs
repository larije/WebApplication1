using System.ComponentModel.DataAnnotations;

namespace WebApplication1.model
{
    public class projectTask
    {
        [Key]


        public string? taskId { get; set; }
        public string? taskName { get; set; }
        public string? description { get; set; }
        public string? taskValue { get; set; }
        public string? remarks { get; set; }
        public string? statusId { get; set; }
        public string? developerId { get; set; }
        public string? projId { get; set; }
    }
}
