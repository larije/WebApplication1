using System.ComponentModel.DataAnnotations;

namespace WebApplication1.model
{
    public class SysUser
    {

        [Key]


        public string? userId { get; set; }
        public string? fullName { get; set; }
        public string? positionTitle { get; set; }
        public string? userName { get; set; }
        public string? password { get; set; }
        public string? roleId { get; set; }
        public string? isActive { get; set; }
    }
}
