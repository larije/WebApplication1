using System.ComponentModel.DataAnnotations;

namespace WebApplication1.model
{
    public class transLog
    {
        [Key]


        public string? logId { get; set; }
        public string? logType { get; set; }
        public string? controlID { get; set; }
        public string? trans { get; set; }
        public string? details { get; set; }
        public string? userId { get; set; }
        public string? transDate { get; set; }
    }
}
