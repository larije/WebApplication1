using System.ComponentModel.DataAnnotations;

namespace WebApplication1.model
{
    public class project
    {
        [Key]


        public string? projId { get; set; }
        public string? projTitle { get; set; }
        public string? description { get; set; }
        public int? statusId { get; set; }
        public string? projOwner { get; set; }
        public string? projLeader { get; set; }
        public string? remarks { get; set; }
        public string? transDate { get; set; }
        public string? userId { get; set; }
    }
}
